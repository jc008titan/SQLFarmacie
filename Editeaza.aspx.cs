using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace Farmacie1
{
    public partial class Editeaza : Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {if (!Page.IsPostBack) refresh();
            
                //}
            
        }



        private void refresh()
        {
            using (var conn = new SqlConnection("Data Source=DESKTOP-E459JU9\\SQLEXPRESS01;Initial Catalog=farmacie;Integrated Security=True;Encrypt=False"))
            {
                //var cmd = new SqlCommand("select * from Stock", conn);
                //cmd.Parameters.AddWithValue("@bar", 17);
                conn.Open();
                //cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();

                using (var con = new SqlConnection("Data Source=DESKTOP-E459JU9\\SQLEXPRESS01;Initial Catalog=farmacie;Integrated Security=True;Encrypt=False"))
                using (var cmd = new SqlCommand(" SELECT *" + " FROM [farmacie].[dbo].[Stock] WHERE ID=" + Request.QueryString["ID"], con))
                {
                    try
                    {
                        con.Open();
                        dt.Load(cmd.ExecuteReader());
                        adauganume.Value = dt.Rows[0]["Nume"].ToString();
                        adaugadata.Value = DateTime.Parse(dt.Rows[0]["Data_Expirare"].ToString()).ToString("dd/MM/yyyy");
                        adaugapret.Value = dt.Rows[0]["Pret"].ToString();
                        adaugacantitate.Value = dt.Rows[0]["Cantitate"].ToString();


                    }
                    catch (Exception ex)
                    {
                        //(snip) Log Exceptions
                    }
                }
                //}
            }
        }

        protected void adauga_onclick(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection("Data Source=DESKTOP-E459JU9\\SQLEXPRESS01;Initial Catalog=farmacie;Integrated Security=True;Encrypt=False"))
            {
                //var cmd = new SqlCommand("select * from Stock", conn);
                //cmd.Parameters.AddWithValue("@bar", 17);
                conn.Open();
                //cmd.ExecuteNonQuery();
                //DataTable dt = new DataTable();

                using (var con = new SqlConnection("Data Source=DESKTOP-E459JU9\\SQLEXPRESS01;Initial Catalog=farmacie;Integrated Security=True;Encrypt=False"))
                //using (var cmd = new SqlCommand(" SELECT *" + " FROM [farmacie].[dbo].[Stock] WHERE [Nume] LIKE '%" + cautarenume.Value + "%' ", con))
                {
                    try
                    {
                        con.Open();
                        string comandaadaugare = "UPDATE [dbo].[Stock] SET [Nume]='"+ adauganume.Value.ToString() + "', [Data_Expirare]='"+ adaugadata.Value.ToString() + "', [Pret]="+ adaugapret.Value.ToString() + ", [Cantitate]=" + adaugacantitate.Value.ToString() + " WHERE ID=" + Request.QueryString["ID"];
                        //dt.Load(cmd.ExecuteReader());


                        //Response.Write("In stoc exista urmatoarele produse:");
                        //spantest.InnerHtml = "Test";
                        HtmlGenericControl octrl = new HtmlGenericControl("span");
                        //octrl.InnerHtml = "In stoc exista urmatoarele produse:";
                        //divProduse.Controls.Add(new HtmlGenericControl("<span>In stoc exista urmatoarele produse:</span>"));
                        using (var cmd = new SqlCommand(comandaadaugare, con))
                            cmd.ExecuteReader();

                            octrl.InnerText += adauganume.Value.ToString()+" "+adaugadata.Value.ToString()+" "+adaugapret.Value.ToString()+" "+adaugacantitate.Value.ToString();
                        
                            adaugat.Controls.Add(octrl);

                        refresh();
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