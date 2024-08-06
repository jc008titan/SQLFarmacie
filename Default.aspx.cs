using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace Farmacie1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
                using (var conn = new SqlConnection("Data Source=DESKTOP-E459JU9\\SQLEXPRESS01;Initial Catalog=farmacie;Integrated Security=True;Encrypt=False"))
                {
                    //var cmd = new SqlCommand("select * from Stock", conn);
                    //cmd.Parameters.AddWithValue("@bar", 17);
                    conn.Open();
                    //cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();

                    using (var con = new SqlConnection("Data Source=DESKTOP-E459JU9\\SQLEXPRESS01;Initial Catalog=farmacie;Integrated Security=True;Encrypt=False"))
                    using (var cmd = new SqlCommand(" SELECT [Nume]" + " FROM [farmacie].[dbo].[Stock] ", con))
                    {
                        try
                        {
                            con.Open();
                            dt.Load(cmd.ExecuteReader());
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
                    }
                //}
            }

        }

        protected void cauta_onclick(object sender, EventArgs e) 
        {
            using (var conn = new SqlConnection("Data Source=DESKTOP-E459JU9\\SQLEXPRESS01;Initial Catalog=farmacie;Integrated Security=True;Encrypt=False"))
            {
                //var cmd = new SqlCommand("select * from Stock", conn);
                //cmd.Parameters.AddWithValue("@bar", 17);
                conn.Open();
                //cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();

                using (var con = new SqlConnection("Data Source=DESKTOP-E459JU9\\SQLEXPRESS01;Initial Catalog=farmacie;Integrated Security=True;Encrypt=False"))
                using (var cmd = new SqlCommand(" SELECT *" + " FROM [farmacie].[dbo].[Stock] WHERE [Nume] LIKE '%"+cautarenume.Value+"%' ", con))
                {
                    try
                    {
                        con.Open();
                        dt.Load(cmd.ExecuteReader());


                        //Response.Write("In stoc exista urmatoarele produse:");
                        //spantest.InnerHtml = "Test";
                        HtmlGenericControl octrl = new HtmlGenericControl("span");
                        //octrl.InnerHtml = "In stoc exista urmatoarele produse:";
                        //divProduse.Controls.Add(new HtmlGenericControl("<span>In stoc exista urmatoarele produse:</span>"));
                        octrl.InnerHtml += "<table class='tblresults'>" + "<thead>" +"<th>" + "Nume" + " </th>";
                        octrl.InnerHtml += "<th>" + "Data_Expirare" + " </th>";
                        octrl.InnerHtml += "<th>" + "Pret" + " </th>";
                        octrl.InnerHtml += "<th>" + "Cantitate" + " </th>"+ "</thead>";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //octrl.InnerHtml += "<br/>";
                            //octrl.InnerHtml += "<span>" + dt.Rows[i]["Nume"].ToString() + " </span>";
                            //octrl.InnerHtml += "<span>" + dt.Rows[i]["Data_Expirare"].ToString() + " </span>";
                            //octrl.InnerHtml += "<span>" + dt.Rows[i]["Pret"].ToString() + " </span>";
                            //octrl.InnerHtml += "<span>" + dt.Rows[i]["Cantitate"].ToString() + "</span>";
                            octrl.InnerHtml += "<tr>" + "<td>" + dt.Rows[i]["Nume"].ToString() + " </td>";
                            octrl.InnerHtml += "<td>" + DateTime.Parse(dt.Rows[i]["Data_Expirare"].ToString()).ToString("dd/mm/yyyy") + " </td>";
                            octrl.InnerHtml += "<td>" + dt.Rows[i]["Pret"].ToString() + " </td>";
                            octrl.InnerHtml += "<td>" + dt.Rows[i]["Cantitate"].ToString() + "</td>"+ "</tr>";
                            octrl.InnerHtml += "</table>";
                            rezultatecautare.Controls.Add(octrl);

                            //divProduse.Controls.Add(new HtmlGenericControl("<br/>"));
                            //divProduse.Controls.Add(new HtmlGenericControl("<span>" + dt.Rows[i]["Nume"].ToString() + "</span>"));
                            // divProduse.InnerText += dt.Rows[i]["Nume"] ;
                        }


                    }
                    catch (Exception ex)
                    {
                        //(snip) Log Exceptions
                    }
                }
            }

        }
    }

    
}