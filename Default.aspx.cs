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

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            octrl.InnerHtml += "<br/>";
                            octrl.InnerHtml += "<span>" + dt.Rows[i]["Nume"].ToString() + " </span>";
                            octrl.InnerHtml += "<span>" + dt.Rows[i]["Data_Expirare"].ToString() + " </span>";
                            octrl.InnerHtml += "<span>" + dt.Rows[i]["Pret"].ToString() + " </span>";
                            octrl.InnerHtml += "<span>" + dt.Rows[i]["Cantitate"].ToString() + "</span>";

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