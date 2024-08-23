using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using FunctiiSQL;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNet.Identity;
using ClassLibrary1;
using System.Xml.Linq;

namespace Farmacie1
{
    public partial class Cauta : Page
    {
        Functii fct = new Functii();
        ErrorLogs err = new ErrorLogs();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //if (!User.Identity.IsAuthenticated)
            //{
            //    Response.Redirect("~/Login.aspx");
            //}
            try
            {

                if (Request.QueryString["ID"] != null)
                    fct.Sterge(Convert.ToInt32(Request.QueryString["ID"]));
                string sCauta="";

                if (Request.QueryString["page"] != null)
                {
                    int iPageNumber = 1;
                        if (int.Parse(Request.QueryString["page"].ToString()) > 0)
                            iPageNumber = int.Parse(Request.QueryString["page"].ToString());

                    DataTable dt = new DataTable();
                    rezultatecautare.Controls.Clear();
                    if (Request.QueryString["cauta"] == null)
                        sCauta = "";
                    else
                    sCauta = Request.QueryString["cauta"].ToString();
                    if (Request.QueryString["criteriu"] != null)
                        dt = fct.GlobalSortCauta(Request.QueryString["criteriu"].ToString(), iPageNumber, sCauta);
                    else
                        dt = fct.SelectCautaNumePagina(sCauta, iPageNumber);
                    paging.Controls.Clear();
                    for (int i = 0; i < fct.NrPaginiCauta(sCauta); i++)
                    {
                        paging.InnerHtml += "<a style=\"border:solid 1px;padding:5px;border-radius:4px;margin-right:5px\" href=\"javascript:openpage1('" + (i + 1).ToString() +"','"+sCauta+"')\">" + (i + 1).ToString() + "</a>";
                    }

                    HtmlGenericControl octrl = new HtmlGenericControl("span");
                    if (dt.Rows.Count > 0)
                    {
                        octrl.InnerHtml += "<table class='tblresults' id='myTable'>" + "<thead>" + "<th onclick='sortTable(0)'>" + "<a href=\"javascript:sortglobal1('" + "nume" + "','" + "a" + "','" + sCauta +  "')\">^</a>" + " Nume " + "<a href=\"javascript:sortglobal1('" + "nume" + "','" + "d" + "','" + sCauta  + "')\">v</a>" + " </th>";
                        octrl.InnerHtml += "<th onclick='sortTableDate(1)'>" + "<a href=\"javascript:sortglobal1('" + "data_expirare" + "','" + "a" + "','" + sCauta  + "')\">^</a>" + " Data_Expirare " + "<a href=\"javascript:sortglobal1('" + "data_expirare" + "','" + "d" + "','" + sCauta  + "')\">v</a>" + " </th>";
                        octrl.InnerHtml += "<th onclick='sortTableNr(2)'>" + "<a href=\"javascript:sortglobal1('" + "pret" + "','" + "a" + "','" + sCauta + "')\">^</a>" + " Pret " + "<a href=\"javascript:sortglobal1('" + "pret" + "','" + "d" + "','" + sCauta + "')\">v</a>" + " </th>";
                        octrl.InnerHtml += "<th onclick='sortTableNr(3)'>" + "<a href=\"javascript:sortglobal1('" + "cantitate" + "','" + "a" + "','" + sCauta + "')\">^</a>" + " Cantitate " + "<a href=\"javascript:sortgloba1l('" + "cantitate" + "','" + "d" + "','" + sCauta  + "')\">v</a>" + " </th>";
                        octrl.InnerHtml += "<th onclick='sortTable(4)'>" + "<a href=\"javascript:sortglobal1('" + "categorie" + "','" + "a" + "','" + sCauta +  "')\">^</a>" + " Categorie " + "<a href=\"javascript:sortglobal1('" + "categorie" + "','" + "d" + "','" + sCauta +  "')\">v</a>" + " </th>";
                        if (User.Identity.GetUserId() == "2c3fd8ce-7b56-4763-af75-0a0a31f73288") octrl.InnerHtml += "<th>" + "Editeaza" + " </th>";
                        if (User.Identity.GetUserId() == "2c3fd8ce-7b56-4763-af75-0a0a31f73288") octrl.InnerHtml += "<th> " + "</th>";
                        octrl.InnerHtml += "</thead>";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            octrl.InnerHtml += "<tr>" + "<td data-label=\"Nume\">" + dt.Rows[i]["Nume"].ToString() + " </td>";
                            octrl.InnerHtml += "<td data-label=\"Data_Expirare\">" + DateTime.Parse(dt.Rows[i]["Data_Expirare"].ToString()).ToString("dd/MM/yyyy") + " </td>";
                            octrl.InnerHtml += "<td data-label=\"Pret\">" + dt.Rows[i]["Pret"].ToString() + " </td>";
                            octrl.InnerHtml += "<td data-label=\"Cantitate\">" + dt.Rows[i]["Cantitate"].ToString() + "</td>";
                            octrl.InnerHtml += "<td data-label=\"Categorie\">" + fct.SelectNumeID(Convert.ToInt32(dt.Rows[i]["Categorie"])) + "</td>";
                            if (User.Identity.GetUserId() == "2c3fd8ce-7b56-4763-af75-0a0a31f73288") octrl.InnerHtml += "<td data-label=\"Editeaza\">" + "<a href='/Editeaza.aspx?id=" + dt.Rows[i]["ID"].ToString() + "'>Editeaza</a>" + "</td>";
                            if (User.Identity.GetUserId() == "2c3fd8ce-7b56-4763-af75-0a0a31f73288") octrl.InnerHtml += "<td data-label=\"\">" + "<a href='?id=" + dt.Rows[i]["ID"].ToString() + "'><img src='Images/Trash.png' width='25' height='25'>" + "</a>" + "</td>";
                            octrl.InnerHtml += "</tr>";
                        }


                        octrl.InnerHtml += "</table>";
                    }
                    else octrl.InnerText += "Nu s-a gasit nimic.";
                    rezultatecautare.Controls.Add(octrl);
                }

            }
            catch (Exception ex)
            {
                err.WriteLogException(ex);
                var st = new StackTrace(ex, true);
                var frame = st.GetFrame(0);
                var line = frame.GetFileLineNumber();
                var path = frame.GetFileName();
                StringBuilder sb = new StringBuilder();
                sb.Append("$(document).ready(function (){");
                sb.Append("showMessage(\"Eroare\");");
                sb.Append("});");
                ScriptManager.RegisterStartupScript(this, GetType(), "YourUniqueScriptKey",
                sb.ToString(), true);
            }
        }


        protected void cauta_onclick(object sender, EventArgs e) 
        {


            try
            {


                DataTable dt = new DataTable();
                rezultatecautare.Controls.Clear();

                string sCauta = cautarenume.Value.ToString();

                if (Request.QueryString["criteriu"] != null)
                    dt = fct.GlobalSortCauta(Request.QueryString["criteriu"].ToString(),1,sCauta);
                else
                dt = fct.SelectCautaNumePagina(sCauta,1);
                paging.Controls.Clear();
                for (int i = 0; i < fct.NrPaginiCauta(sCauta); i++)
                {
                    paging.InnerHtml += "<a style=\"border:solid 1px;padding:5px;border-radius:4px;margin-right:5px\" href=\"javascript:openpage('" + (i + 1).ToString() + "')\">" + (i + 1).ToString() + "</a>";
                }

                HtmlGenericControl octrl = new HtmlGenericControl("span");
                if (dt.Rows.Count>0){
                    octrl.InnerHtml += "<table class='tblresults' id='myTable'>" + "<thead>" + "<th onclick='sortTable(0)'>" + "<a href=\"javascript:sortglobal('" + "nume" + "','" + "a" +  "')\">^</a>" + " Nume " + "<a href=\"javascript:sortglobal('" + "nume" + "','" + "d" +  "')\">v</a>" + " </th>";
                    octrl.InnerHtml += "<th onclick='sortTableDate(1)'>" + "<a href=\"javascript:sortglobal('" + "data_expirare" + "','" + "a" +  "')\">^</a>" + " Data_Expirare " + "<a href=\"javascript:sortglobal('" + "data_expirare" + "','" + "d" +  "')\">v</a>" + " </th>";
                    octrl.InnerHtml += "<th onclick='sortTableNr(2)'>" + "<a href=\"javascript:sortglobal('" + "pret" + "','" + "a" + "')\">^</a>" + " Pret " + "<a href=\"javascript:sortglobal('" + "pret" + "','" + "d" +  "')\">v</a>" + " </th>";
                    octrl.InnerHtml += "<th onclick='sortTableNr(3)'>" + "<a href=\"javascript:sortglobal('" + "cantitate" + "','" + "a" +  "')\">^</a>" + " Cantitate " + "<a href=\"javascript:sortglobal('" + "cantitate" + "','" + "d" +  "')\">v</a>" + " </th>";
                    octrl.InnerHtml += "<th onclick='sortTable(4)'>" + "<a href=\"javascript:sortglobal('" + "categorie" + "','" + "a"+  "')\">^</a>" + " Categorie " + "<a href=\"javascript:sortglobal('" + "categorie" + "','" + "d" + "')\">v</a>" + " </th>";
                    if (User.Identity.GetUserId() == "2c3fd8ce-7b56-4763-af75-0a0a31f73288") octrl.InnerHtml += "<th>" + "Editeaza" + " </th>";
                    if (User.Identity.GetUserId() == "2c3fd8ce-7b56-4763-af75-0a0a31f73288") octrl.InnerHtml += "<th> " + "</th>";
                    octrl.InnerHtml += "</thead>";
                    for (int i = 0; i < dt.Rows.Count; i++)
                {
                    octrl.InnerHtml += "<tr>" + "<td data-label=\"Nume\">" + dt.Rows[i]["Nume"].ToString() + " </td>";
                    octrl.InnerHtml += "<td data-label=\"Data_Expirare\">" + DateTime.Parse(dt.Rows[i]["Data_Expirare"].ToString()).ToString("dd/MM/yyyy") + " </td>";
                    octrl.InnerHtml += "<td data-label=\"Pret\">" + dt.Rows[i]["Pret"].ToString() + " </td>";
                    octrl.InnerHtml += "<td data-label=\"Cantitate\">" + dt.Rows[i]["Cantitate"].ToString() + "</td>";
                    octrl.InnerHtml += "<td data-label=\"Categorie\">" + fct.SelectNumeID(Convert.ToInt32(dt.Rows[i]["Categorie"])) + "</td>";
                    if (User.Identity.GetUserId() == "2c3fd8ce-7b56-4763-af75-0a0a31f73288") octrl.InnerHtml += "<td data-label=\"Editeaza\">" + "<a href='/Editeaza.aspx?id=" + dt.Rows[i]["ID"].ToString() + "'>Editeaza</a>" + "</td>";
                    if (User.Identity.GetUserId() == "2c3fd8ce-7b56-4763-af75-0a0a31f73288") octrl.InnerHtml += "<td data-label=\"\">" + "<a href='?id=" + dt.Rows[i]["ID"].ToString() + "'><img src='Images/Trash.png' width='25' height='25'>" + "</a>" + "</td>";
                    octrl.InnerHtml += "</tr>";
                }


                octrl.InnerHtml += "</table>";
            }
            else octrl.InnerText += "Nu s-a gasit nimic.";
            rezultatecautare.Controls.Add(octrl);

        }
                    catch (Exception ex)
                    {
                err.WriteLogException(ex);
                var st = new StackTrace(ex, true);
                var frame = st.GetFrame(0);
                var line = frame.GetFileLineNumber();
                var path = frame.GetFileName();
                StringBuilder sb = new StringBuilder();
                sb.Append("$(document).ready(function (){");
                sb.Append("showMessage(\"Eroare\");");
                sb.Append("});");
                ScriptManager.RegisterStartupScript(this, GetType(), "YourUniqueScriptKey",
                sb.ToString(), true);
            }
                
            

        }

    }

    
}