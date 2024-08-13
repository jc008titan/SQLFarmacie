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
using System.Diagnostics;
using System.Text;
using Microsoft.AspNet.Identity;

namespace Farmacie1
{
    public partial class Editeaza : Page
    {
        Functii fct = new Functii();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.GetUserId() != "2c3fd8ce-7b56-4763-af75-0a0a31f73288")
                Response.Redirect("~/Default.aspx");
            if (!Page.IsPostBack) refresh();
            
                //}
            
        }



        private void refresh()
        {
            
                    try
                    {
                DataTable dtc = new DataTable();
                dtc = fct.SelectCategorie();
                adaugacategorie.DataSource = dtc;
                adaugacategorie.DataBind();
                adaugacategorie.DataTextField = "Nume";
                adaugacategorie.DataValueField = "ID";
                adaugacategorie.DataBind();



                DataTable dt = fct.SelectID(Convert.ToInt32(Request.QueryString["ID"]));
                        adauganume.Value = dt.Rows[0]["Nume"].ToString();
                        adaugadata.Value = DateTime.Parse(dt.Rows[0]["Data_Expirare"].ToString()).ToString("MM/dd/yyyy");
                        adaugapret.Value = dt.Rows[0]["Pret"].ToString();
                        adaugacantitate.Value = dt.Rows[0]["Cantitate"].ToString();
                        adaugacategorie.SelectedValue = dt.Rows[0]["Categorie"].ToString();

            }
                    catch (Exception ex)
                    {
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

        protected void adauga_onclick(object sender, EventArgs e)
        {

                //var cmd = new SqlCommand("select * from Stock", conn);
                //cmd.Parameters.AddWithValue("@bar", 17);
                //cmd.ExecuteNonQuery();
                //DataTable dt = new DataTable();

                
                //using (var cmd = new SqlCommand(" SELECT *" + " FROM [farmacie].[dbo].[Stock] WHERE [Nume] LIKE '%" + cautarenume.Value + "%' ", con))
                
                    try
                    {
                        fct.Editeaza(adauganume.Value.ToString(),adaugadata.Value.ToString(),adaugapret.Value.ToString(),adaugacantitate.Value.ToString(),Convert.ToInt32(Request.QueryString["ID"]), Convert.ToInt32(adaugacategorie.SelectedValue));
                        
                        //dt.Load(cmd.ExecuteReader());


                        //Response.Write("In stoc exista urmatoarele produse:");
                        //spantest.InnerHtml = "Test";
                        HtmlGenericControl octrl = new HtmlGenericControl("span");
                        //octrl.InnerHtml = "In stoc exista urmatoarele produse:";
                        //divProduse.Controls.Add(new HtmlGenericControl("<span>In stoc exista urmatoarele produse:</span>"));

                            octrl.InnerText += adauganume.Value.ToString()+" "+adaugadata.Value.ToString()+" "+adaugapret.Value.ToString()+" "+adaugacantitate.Value.ToString() + " " + adaugacategorie.SelectedValue.ToString();
                        
                            adaugat.Controls.Add(octrl);

                        refresh();
                    }
                    catch (Exception ex)
                    {
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