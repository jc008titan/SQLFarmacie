using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Farmacie1
{
    public partial class AdaugareMedicament : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                        //dt.Load(cmd.ExecuteReader());


                        //Response.Write("In stoc exista urmatoarele produse:");
                        //spantest.InnerHtml = "Test";
                        HtmlGenericControl octrl = new HtmlGenericControl("span");
                        string comandaadaugare = "INSERT INTO [dbo].[Stock]([Nume], [Data_Expirare], [Pret], [Cantitate]) VALUES ('" + adauganume.Value.ToString() + "','" + adaugadata.Value.ToString() + "'," + adaugapret.Value.ToString() + "," + adaugacantitate.Value.ToString() + ")";
                        //octrl.InnerHtml = "In stoc exista urmatoarele produse:";
                        //divProduse.Controls.Add(new HtmlGenericControl("<span>In stoc exista urmatoarele produse:</span>"));
                        using (var cmd = new SqlCommand(comandaadaugare, con))
                            cmd.ExecuteReader();

                            octrl.InnerText += adauganume.Value.ToString()+" "+adaugadata.Value.ToString()+" "+adaugapret.Value.ToString()+" "+adaugacantitate.Value.ToString();
                        
                            adaugat.Controls.Add(octrl);


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