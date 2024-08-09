﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using FunctiiSQL;

namespace Farmacie1
{
    public partial class Stock : Page
    {
        Functii fct = new Functii();
        /*protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{

            try
            {
                DataTable dt;
                if (Request.QueryString["ID"]!=null)
                    dt = fct.SelectCategorieNume(Convert.ToInt32(Request.QueryString["ID"]));
                else
                dt = fct.Select();

                divProduse.Controls.Clear();

                //Response.Write("In stoc exista urmatoarele produse:");
                //spantest.InnerHtml = "Test";
                HtmlGenericControl octrl = new HtmlGenericControl("span");
                octrl.InnerHtml = "In stoc exista urmatoarele produse:";
                //divProduse.Controls.Add(new HtmlGenericControl("<span>In stoc exista urmatoarele produse:</span>"));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    octrl.InnerHtml += "<br/>";
                    octrl.InnerHtml += "<span>" + dt.Rows[i]["Nume"].ToString() + "</span>";
                    

                    //divProduse.Controls.Add(new HtmlGenericControl("<br/>"));
                    //divProduse.Controls.Add(new HtmlGenericControl("<span>" + dt.Rows[i]["Nume"].ToString() + "</span>"));
                    // divProduse.InnerText += dt.Rows[i]["Nume"] ;
                }
                divProduse.Controls.Add(octrl);

            }
            catch (Exception ex)
            {
                //(snip) Log Exceptions
            }

            //}


        }*/


        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                if (Request.QueryString["ID"] != null)
                    fct.Sterge(Convert.ToInt32(Request.QueryString["ID"]));
                DataTable dt;
                if (Request.QueryString["cat"] != null)
                    dt = fct.SelectCategorieNume(Convert.ToInt32(Request.QueryString["cat"]));
                else
                    dt = fct.Cauta("");
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
                    octrl.InnerHtml += "<tr>" + "<td>" + dt.Rows[i]["Nume"].ToString() + " </td>";
                    octrl.InnerHtml += "<td>" + DateTime.Parse(dt.Rows[i]["Data_Expirare"].ToString()).ToString("dd/MM/yyyy") + " </td>";
                    octrl.InnerHtml += "<td>" + dt.Rows[i]["Pret"].ToString() + " </td>";
                    octrl.InnerHtml += "<td>" + dt.Rows[i]["Cantitate"].ToString() + "</td>";
                    octrl.InnerHtml += "<td>" + fct.SelectNumeID(Convert.ToInt32(dt.Rows[i]["Categorie"])) + "</td>";
                    octrl.InnerHtml += "<td>" + "<a href='/Editeaza.aspx?id=" + dt.Rows[i]["ID"].ToString() + "'>Editeaza</a>" + "</td>";
                    octrl.InnerHtml += "<td>" + "<a href='?id=" + dt.Rows[i]["ID"].ToString() + "'><img src='Images/Trash.png' width='25' height='25'>" + "</a>" + "</td>" + "</tr>";

                }


                octrl.InnerHtml += "</table>";
                stock.Controls.Add(octrl);

            }
            catch (Exception ex)
            {
                //(snip) Log Exceptions
            }



        }

    }

    
}