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
using System.Diagnostics;
using System.Text;
using Microsoft.AspNet.Identity;
using ClassLibrary1;

namespace Farmacie1
{
    public partial class _Default : Page
    {
        Functii fct = new Functii();
        ErrorLogs err = new ErrorLogs();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    Response.Redirect("~/Login.aspx");
            //}
            //if (!Page.IsPostBack)
            //{

            try
                        {

                        if (Request.QueryString["ID"] != null)
                            sterge_onclick(Convert.ToInt32(Request.QueryString["ID"]));

                
                DataTable dt = fct.Select();

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
                    divProduse.Controls.Add(octrl);

                    //divProduse.Controls.Add(new HtmlGenericControl("<br/>"));
                    //divProduse.Controls.Add(new HtmlGenericControl("<span>" + dt.Rows[i]["Nume"].ToString() + "</span>"));
                    // divProduse.InnerText += dt.Rows[i]["Nume"] ;
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
                //(snip) Log Exceptions
            }
                    
                //}
            

        }

        protected void sterge_onclick(int id)
        {

                    try
                    {
                        fct.Sterge(id);

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
                //(snip) Log Exceptions
            }
                
               //}
            

        }


        protected void cauta_onclick(object sender, EventArgs e) 
        {
            
                
                    try
                    {
                        DataTable dt = fct.Cauta(cautarenume.Value.ToString());
                        rezultatecautare.Controls.Clear();



                        //Response.Write("In stoc exista urmatoarele produse:");
                        //spantest.InnerHtml = "Test";
                        HtmlGenericControl octrl = new HtmlGenericControl("span");
                /*HtmlTable otbl= new HtmlTable();
                otbl.Attributes.Add("class", "tsblresults");


                HtmlTableRow oheader = new HtmlTableRow();
                HtmlTableCell ocell = new HtmlTableCell();
                ocell.InnerText = "Nume";
                oheader.Cells.Add(ocell);
                ocell = new HtmlTableCell();
                ocell.InnerText = "Data Expirare";
                oheader.Cells.Add(ocell);
                ocell = new HtmlTableCell();
                ocell.InnerText = "Pret";
                oheader.Cells.Add(ocell);
                ocell = new HtmlTableCell();
                ocell.InnerText = "Cantitate";
                oheader.Cells.Add(ocell);
                ocell = new HtmlTableCell();
                ocell.InnerText = "Editeaza";
                oheader.Cells.Add(ocell);
                ocell = new HtmlTableCell();
                oheader.Cells.Add(ocell);
                otbl.Controls.Add(oheader);*/



                //octrl.InnerHtml = "In stoc exista urmatoarele produse:";
                //divProduse.Controls.Add(new HtmlGenericControl("<span>In stoc exista urmatoarele produse:</span>"));
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
                    //rezultatecautare.Controls.Add(octrl);

                    //divProduse.Controls.Add(new HtmlGenericControl("<br/>"));
                    //divProduse.Controls.Add(new HtmlGenericControl("<span>" + dt.Rows[i]["Nume"].ToString() + "</span>"));
                    // divProduse.InnerText += dt.Rows[i]["Nume"] ;
                    /* oheader = new HtmlTableRow();
                     ocell = new HtmlTableCell();
                    ocell.InnerText = dt.Rows[i]["Nume"].ToString();
                    oheader.Cells.Add(ocell);
                    ocell = new HtmlTableCell();
                    ocell.InnerText = DateTime.Parse(dt.Rows[i]["Data_Expirare"].ToString()).ToString("dd/mm/yyyy");
                    oheader.Cells.Add(ocell);
                    ocell = new HtmlTableCell();
                    ocell.InnerText = dt.Rows[i]["Pret"].ToString();
                    oheader.Cells.Add(ocell);
                    ocell = new HtmlTableCell();
                    ocell.InnerText = dt.Rows[i]["Cantitate"].ToString();
                    oheader.Cells.Add(ocell);
                    ocell = new HtmlTableCell();
                    ocell.InnerHtml = "<a href = '/Editeaza.aspx?id=" + dt.Rows[i]["ID"].ToString() + "' > Editeaza </a >";
                    oheader.Cells.Add(ocell);



                    ocell = new HtmlTableCell();
                    Button img = new Button();
                    //img.ImageUrl = "Images/Trash.png";
                    img.ID = "delicon" + dt.Rows[i]["ID"].ToString();
                   // img.Attributes.Add("width","25");
                   // img.Attributes.Add("height", "25");
                    img.Click +=new EventHandler(sterge_onclick);
                    ocell.Controls.Add(img);
                    oheader.Cells.Add(ocell);
                    otbl.Controls.Add(oheader);*/
                }


                octrl.InnerHtml += "</table>";
                        rezultatecautare.Controls.Add(octrl);
                        //rezultatecautare.Controls.Add(otbl);

                        /*Button img1 = new Button();
                        Page.RegisterRequiresRaiseEvent(img1);
                        //img.ImageUrl = "Images/Trash.png";
                        img1.ID = "test";
                        // img.Attributes.Add("width","25");
                        // img.Attributes.Add("height", "25");
                        img1.CausesValidation = false;
                        img1.Click += new EventHandler(sterge_onclick);
                        rezultatecautare.Controls.Add(img1);*/

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
                //(snip) Log Exceptions
            }
                
            

        }

    }

    
}