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
using FunctiiSQL;

namespace Farmacie1
{
    public partial class Editeaza : Page
    {
        Functii fct = new Functii();
        protected void Page_Load(object sender, EventArgs e)
        {if (!Page.IsPostBack) refresh();
            
                //}
            
        }



        private void refresh()
        {
            
                    try
                    {
                        DataTable dt = fct.SelectID(Convert.ToInt32(Request.QueryString["ID"]));
                        adauganume.Value = dt.Rows[0]["Nume"].ToString();
                        adaugadata.Value = DateTime.Parse(dt.Rows[0]["Data_Expirare"].ToString()).ToString("dd/MM/yyyy");
                        adaugapret.Value = dt.Rows[0]["Pret"].ToString();
                        adaugacantitate.Value = dt.Rows[0]["Cantitate"].ToString();


                    }
                    catch (Exception ex)
                    {
                        //(snip) Log Exceptions
                    }
               
                //}
            
        }

        protected void adauga_onclick(object sender, EventArgs e)
        {

                //var cmd = new SqlCommand("select * from Stock", conn);
                //cmd.Parameters.AddWithValue("@bar", 17);
                //cmd.ExecuteNonQuery();
                //DataTable dt = new DataTable();

                
                //using (var cmd = new SqlCommand(" SELECT *" + " FROM [farmacie].[dbo].[Stock] WHERE [Nume] LIKE '%" + cautarenume.Value + "%' ", con))
                
                    try
                    {
                        fct.Adauga(adauganume.Value.ToString(),adaugadata.Value.ToString(),adaugapret.Value.ToString(),adaugacantitate.Value.ToString());
                        
                        //dt.Load(cmd.ExecuteReader());


                        //Response.Write("In stoc exista urmatoarele produse:");
                        //spantest.InnerHtml = "Test";
                        HtmlGenericControl octrl = new HtmlGenericControl("span");
                        //octrl.InnerHtml = "In stoc exista urmatoarele produse:";
                        //divProduse.Controls.Add(new HtmlGenericControl("<span>In stoc exista urmatoarele produse:</span>"));

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