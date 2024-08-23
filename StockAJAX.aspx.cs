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
            //if (!User.Identity.IsAuthenticated)
            //{
            //    Response.Redirect("~/Login.aspx");
            //}

            int iPageNumber = 1;
            if (Request.QueryString["page"] != null)
                    iPageNumber = int.Parse(Request.QueryString["page"].ToString());
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


            DataTable dt = new DataTable();
            if (Request.QueryString["cat"] != null)
            {
                if (int.Parse(Request.QueryString["cat"].ToString()) > 0)
                {
                    if (Request.QueryString["criteriu"] != null)
                        dt = fct.GlobalSortCat(Request.QueryString["criteriu"].ToString(), iPageNumber,Convert.ToInt32(Request.QueryString["cat"]));
                    else
                        dt = fct.SelectCategorieNumePagina(Convert.ToInt32(Request.QueryString["cat"]), iPageNumber);
                    paging.Controls.Clear();
                    if (Request.QueryString["criteriu"] != null)
                    {
                        for (int i = 0; i < fct.NrPaginiCategorie(Convert.ToInt32(Request.QueryString["cat"])); i++)
                        {
                            paging.InnerHtml += "<a style=\"border:solid 1px;padding:5px;border-radius:4px;margin-right:5px\" href=\"javascript:openpage1('" + (i + 1).ToString() + "','" + Request.QueryString["cat"].ToString() + "','" + Request.QueryString["criteriu"].ToString() + "')\">" + (i + 1).ToString() + "</a>";
                        }
                    }
                    else
                        for (int i = 0; i < fct.NrPaginiCategorie(Convert.ToInt32(Request.QueryString["cat"])); i++)
                    {
                        paging.InnerHtml += "<a style=\"border:solid 1px;padding:5px;border-radius:4px;margin-right:5px\" href=\"javascript:openpage1('" + (i + 1).ToString() + "','" + Request.QueryString["cat"].ToString() + "','" + "" + "')\">" + (i + 1).ToString() + "</a>";
                    }
                }
                else
                {
                    paging.Controls.Clear();
                    if (Request.QueryString["criteriu"] != null)
                    {
                        for (int i = 0; i < fct.NrPagini(); i++)
                        {
                            paging.InnerHtml += "<a style=\"border:solid 1px;padding:5px;border-radius:4px;margin-right:5px\" href=\"javascript:openpage1('" + (i + 1).ToString() + "','" + "" + "','" + Request.QueryString["criteriu"].ToString() + "')\">" + (i + 1).ToString() + "</a>";
                        }
                        dt = fct.GlobalSort(Request.QueryString["criteriu"].ToString(), iPageNumber);
                    }
                    else
                    {
                        for (int i = 0; i < fct.NrPagini(); i++)
                        {
                            paging.InnerHtml += "<a style=\"border:solid 1px;padding:5px;border-radius:4px;margin-right:5px\" href=\"javascript:openpage1('" + (i + 1).ToString() + "','" + "" + "','" + "" + "')\">" + (i + 1).ToString() + "</a>";
                        }
                        //dt = fct.Cauta("");
                        dt = fct.PaginaNr(iPageNumber);
                    }
                }
            }
            else
            {
                paging.Controls.Clear();
                if (Request.QueryString["criteriu"] != null)
                {
                    for (int i = 0; i < fct.NrPagini(); i++)
                    {
                        paging.InnerHtml += "<a style=\"border:solid 1px;padding:5px;border-radius:4px;margin-right:5px\" href=\"javascript:openpage1('" + (i + 1).ToString() + "','" + "" + "','" + Request.QueryString["criteriu"].ToString() + "')\">" + (i + 1).ToString() + "</a>";
                    }
                    dt = fct.GlobalSort(Request.QueryString["criteriu"].ToString(), iPageNumber);
                }
                else
                {
                    for (int i = 0; i < fct.NrPagini(); i++)
                    {
                        paging.InnerHtml += "<a style=\"border:solid 1px;padding:5px;border-radius:4px;margin-right:5px\" href=\"javascript:openpage1('" + (i + 1).ToString() + "','" + "" + "','" + "" + "')\">" + (i + 1).ToString() + "</a>";
                    }
                    //dt = fct.Cauta("");
                    dt = fct.PaginaNr(iPageNumber);
                }
            }

            //DataTable dt = new DataTable();
            //if (Request.QueryString["cat"] != null)
            //{
            //    if (int.Parse(Request.QueryString["cat"].ToString()) > 0)
            //    {
            //        dt = fct.SelectCategorieNume(Convert.ToInt32(Request.QueryString["cat"]));
            //    }
            //    else
            //    {
            //        dt = fct.Cauta("");
            //    }
            //}
            //else
            //{
            //    dt = fct.Cauta("");
            //}
            string page = "";
            string cat = "";
            if (Request.QueryString["page"] != null)
              page  = Request.QueryString["page"].ToString();
            if (Request.QueryString["cat"] != null)
                cat = Request.QueryString["cat"].ToString();

            stock.Controls.Clear();
            HtmlGenericControl octrl = new HtmlGenericControl("span");
            octrl.InnerHtml += "<table class='tblresults' id='myTable'>" + "<thead>" + "<th onclick='sortTable(0)'>" + "<a href=\"javascript:openpage1('" + page+ "','"+ cat + "','" + "numea" +"')\">^</a>" + " Nume " + "<a href=\"javascript:openpage1('" + page + "','" + cat + "','" + "numed"+"')\">v</a>" + " </th>";
                octrl.InnerHtml += "<th onclick='sortTableDate(1)'>" + "<a href=\"javascript:openpage1('" + page + "','" + cat + "','" + "data_expirarea" + "')\">^</a>" + " Data_Expirare " + "<a href=\"javascript:openpage1('" + page + "','" + cat + "','" + "data_expirared" + "')\">v</a>" + " </th>";
                octrl.InnerHtml += "<th onclick='sortTableNr(2)'>" + "<a href=\"javascript:openpage1('" +page + "','" + cat + "','" + "preta" + "')\">^</a>" + " Pret " + "<a href=\"javascript:openpage1('" + page + "','" + cat + "','" + "pretd" + "')\">v</a>" + " </th>";
                octrl.InnerHtml += "<th onclick='sortTableNr(3)'>" + "<a href=\"javascript:openpage1('" + page + "','" + cat + "','" + "cantitatea" + "')\">^</a>" + " Cantitate " + "<a href=\"javascript:openpage1('" + page + "','" + cat + "','" + "cantitated" + "')\">v</a>" + " </th>";
                octrl.InnerHtml += "<th onclick='sortTable(4)'>" + "<a href=\"javascript:openpage1('" + page + "','" + cat + "','" + "categoriea" + "')\">^</a>" + " Categorie " + "<a href=\"javascript:openpage1('" + page + "','" + cat + "','" + "categoried" + "')\">v</a>" + " </th>";
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