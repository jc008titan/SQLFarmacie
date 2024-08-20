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
                    dt = fct.SelectCautaNumePagina(sCauta, iPageNumber);
                    paging.Controls.Clear();
                    for (int i = 0; i < fct.NrPaginiCauta(sCauta); i++)
                    {
                        paging.InnerHtml += "<a href=\"javascript:openpage1('" + (i + 1).ToString() +"','"+sCauta+"')\">" + (i + 1).ToString() + "</a>";
                    }

                    HtmlGenericControl octrl = new HtmlGenericControl("span");
                    if (dt.Rows.Count > 0)
                    {
                        octrl.InnerHtml += "<table class='tblresults' id='myTable'>" + "<thead>" + "<th onclick='sortTable(0)'>" + "Nume" + " </th>";
                        octrl.InnerHtml += "<th onclick='sortTableDate(1)'>" + "Data_Expirare" + " </th>";
                        octrl.InnerHtml += "<th onclick='sortTableNr(2)'>" + "Pret" + " </th>";
                        octrl.InnerHtml += "<th onclick='sortTableNr(3)'>" + "Cantitate" + " </th>";
                        octrl.InnerHtml += "<th onclick='sortTable(4)'>" + "Categorie" + " </th>";
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


                dt = fct.SelectCautaNumePagina(sCauta,1);
                paging.Controls.Clear();
                for (int i = 0; i < fct.NrPaginiCauta(sCauta); i++)
                {
                    paging.InnerHtml += "<a href=\"javascript:openpage('" + (i + 1).ToString() + "')\">" + (i + 1).ToString() + "</a>";
                }

                HtmlGenericControl octrl = new HtmlGenericControl("span");
                if (dt.Rows.Count>0){octrl.InnerHtml += "<table class='tblresults' id='myTable'>" + "<thead>" + "<th onclick='sortTable(0)'>" + "Nume" + " </th>";
                octrl.InnerHtml += "<th onclick='sortTableDate(1)'>" + "Data_Expirare" + " </th>";
                octrl.InnerHtml += "<th onclick='sortTableNr(2)'>" + "Pret" + " </th>";
                octrl.InnerHtml += "<th onclick='sortTableNr(3)'>" + "Cantitate" + " </th>";
                octrl.InnerHtml += "<th onclick='sortTable(4)'>" + "Categorie" + " </th>";
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