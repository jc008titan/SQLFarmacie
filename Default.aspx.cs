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

namespace Farmacie1
{
    public partial class _Default : Page
    {
        Functii fct = new Functii();
        protected void Page_Load(object sender, EventArgs e)
        {
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
                octrl.InnerHtml += "<th>" + "Editeaza" + " </th>";
                octrl.InnerHtml += "<th> " + "</th>" + "</thead>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //octrl.InnerHtml += "<br/>";
                    //octrl.InnerHtml += "<span>" + dt.Rows[i]["Nume"].ToString() + " </span>";
                    //octrl.InnerHtml += "<span>" + dt.Rows[i]["Data_Expirare"].ToString() + " </span>";
                    //octrl.InnerHtml += "<span>" + dt.Rows[i]["Pret"].ToString() + " </span>";
                    //octrl.InnerHtml += "<span>" + dt.Rows[i]["Cantitate"].ToString() + "</span>";
                    octrl.InnerHtml += "<tr>" + "<td>" + dt.Rows[i]["Nume"].ToString() + " </td>";
                    octrl.InnerHtml += "<td>" + DateTime.Parse(dt.Rows[i]["Data_Expirare"].ToString()).ToString("dd/MM/yyyy") + " </td>";
                    octrl.InnerHtml += "<td>" + dt.Rows[i]["Pret"].ToString() + " </td>";
                    octrl.InnerHtml += "<td>" + dt.Rows[i]["Cantitate"].ToString() + "</td>";
                    octrl.InnerHtml += "<td>" + fct.SelectNumeID(Convert.ToInt32(dt.Rows[i]["Categorie"])) + "</td>";
                    octrl.InnerHtml += "<td>" + "<a href='/Editeaza.aspx?id=" + dt.Rows[i]["ID"].ToString() + "'>Editeaza</a>" + "</td>";
                    octrl.InnerHtml += "<td>" + "<a href='?id=" + dt.Rows[i]["ID"].ToString() + "'><img src='Images/Trash.png' width='25' height='25'>" + "</a>" + "</td>" + "</tr>";
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
                        //(snip) Log Exceptions
                    }
                
            

        }

    }

    
}