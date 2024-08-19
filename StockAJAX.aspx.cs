using FunctiiSQL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Farmacie1
{
    public partial class StockAJAX : System.Web.UI.Page
    {
        Functii fct = new Functii();
        protected void Page_Load(object sender, EventArgs e)
        {


            /*int iPageNumber = 1;
            if (Request.QueryString["page"] != null)
                if (int.Parse(Request.QueryString["page"].ToString()) > 0)
                    iPageNumber = int.Parse(Request.QueryString["page"].ToString());*/
            /*DataTable dt = new DataTable();
            if (Request.QueryString["cat"] != null)
            {
                dt = fct.SelectCategorieNumePagina(Convert.ToInt32(Request.QueryString["cat"]), iPageNumber);
                paging.Controls.Clear();
                for (int i = 0; i < fct.NrPaginiCategorie(Convert.ToInt32(Request.QueryString["cat"]), iPageNumber); i++)
                {
                    paging.InnerHtml += "<a href=\"javascript:openpage('" + (i + 1).ToString() + "')\">" + (i + 1).ToString() + "</a>";
                }
            }
            else
            {
                paging.Controls.Clear();
                for (int i = 0; i < fct.NrPagini(); i++)
                {
                    paging.InnerHtml += "<a href=\"javascript:openpage('" + (i + 1).ToString() + "')\">" + (i + 1).ToString() + "</a>";
                }
                //dt = fct.Cauta("");
                dt = fct.PaginaNr(iPageNumber);
            }*/


            /*DataTable dt = new DataTable();
            if (Request.QueryString["cat"] != null)
            {
                if (int.Parse(Request.QueryString["cat"].ToString()) > 0)
                {
                    dt = fct.SelectCategorieNumePagina(Convert.ToInt32(Request.QueryString["cat"]), iPageNumber);
                    paging.Controls.Clear();
                    for (int i = 0; i < fct.NrPaginiCategorie(Convert.ToInt32(Request.QueryString["cat"]), iPageNumber); i++)
                    {
                        paging.InnerHtml += "<a href=\"javascript:openpage('" + (i + 1).ToString() + "')\">" + (i + 1).ToString() + "</a>";
                    }
                }
                else
                {
                    paging.Controls.Clear();
                    for (int i = 0; i < fct.NrPagini(); i++)
                    {
                        paging.InnerHtml += "<a href=\"javascript:openpage('" + (i + 1).ToString() + "')\">" + (i + 1).ToString() + "</a>";
                    }
                    //dt = fct.Cauta("");
                    dt = fct.PaginaNr(iPageNumber);
                }
            }
            else
            {
                paging.Controls.Clear();
                for (int i = 0; i < fct.NrPagini(); i++)
                {
                    paging.InnerHtml += "<a href=\"javascript:openpage('" + (i + 1).ToString() + "')\">" + (i + 1).ToString() + "</a>";
                }
                //dt = fct.Cauta("");
                dt = fct.PaginaNr(iPageNumber);
            }*/

            DataTable dt = new DataTable();
            if (Request.QueryString["cat"] != null)
            {
                if (int.Parse(Request.QueryString["cat"].ToString()) > 0)
                {
                    dt = fct.SelectCategorieNume(Convert.ToInt32(Request.QueryString["cat"]));
                }
                else
                {
                    dt = fct.Cauta("");
                }
            }
            else
            {
                dt = fct.Cauta("");
            }




            stock.Controls.Clear();
            HtmlGenericControl octrl = new HtmlGenericControl("span");
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
            stock.Controls.Add(octrl);
        }
    }
}