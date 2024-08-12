using FunctiiSQL;
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
            octrl.InnerHtml += "<th>" + "Editeaza" + " </th>";
            octrl.InnerHtml += "<th> " + "</th>" + "</thead>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                octrl.InnerHtml += "<tr>" + "<td data-label=\"Nume\">" + dt.Rows[i]["Nume"].ToString() + " </td>";
                octrl.InnerHtml += "<td data-label=\"Data_Expirare\">" + DateTime.Parse(dt.Rows[i]["Data_Expirare"].ToString()).ToString("dd/MM/yyyy") + " </td>";
                octrl.InnerHtml += "<td data-label=\"Pret\">" + dt.Rows[i]["Pret"].ToString() + " </td>";
                octrl.InnerHtml += "<td data-label=\"Cantitate\">" + dt.Rows[i]["Cantitate"].ToString() + "</td>";
                octrl.InnerHtml += "<td data-label=\"Categorie\">" + fct.SelectNumeID(Convert.ToInt32(dt.Rows[i]["Categorie"])) + "</td>";
                octrl.InnerHtml += "<td data-label=\"Editeaza\">" + "<a href='/Editeaza.aspx?id=" + dt.Rows[i]["ID"].ToString() + "'>Editeaza</a>" + "</td>";
                octrl.InnerHtml += "<td data-label=\"\">" + "<a href='?id=" + dt.Rows[i]["ID"].ToString() + "'><img src='Images/Trash.png' width='25' height='25'>" + "</a>" + "</td>" + "</tr>";

            }


            octrl.InnerHtml += "</table>";
            stock.Controls.Add(octrl);
        }
    }
}