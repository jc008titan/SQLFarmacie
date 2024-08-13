using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using FunctiiSQL;
using ClassLibrary1;
using System.Text;
using System.Web.Services.Description;
using System.Diagnostics;
using System.IO;
using System.Security.Claims;
using System.Configuration;
using Microsoft.AspNet.Identity;

namespace Farmacie1
{
    public partial class AdaugareMedicament : Page
    {
        Functii fct = new Functii();
        ErrorLogs err= new ErrorLogs();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.GetUserId() != "2c3fd8ce-7b56-4763-af75-0a0a31f73288")
                    Response.Redirect("~/Default.aspx");
            DataTable dt = new DataTable();
            dt=fct.SelectCategorie();
            adaugacategorie.DataSource = dt;
            adaugacategorie.DataBind();
            adaugacategorie.DataTextField = "Nume";
            adaugacategorie.DataValueField = "ID";
            adaugacategorie.DataBind();
        }
        protected void adauga_onclick(object sender, EventArgs e)
        {
            
                    try
                    {
                        //dt.Load(cmd.ExecuteReader());


                        //Response.Write("In stoc exista urmatoarele produse:");
                        //spantest.InnerHtml = "Test";
                        HtmlGenericControl octrl = new HtmlGenericControl("span");
                //octrl.InnerHtml = "In stoc exista urmatoarele produse:";
                //divProduse.Controls.Add(new HtmlGenericControl("<span>In stoc exista urmatoarele produse:</span>"));
                fct.Adauga(adauganume.Value.ToString(), adaugadata.Value.ToString(), adaugapret.Value.ToString(), adaugacantitate.Value.ToString(),Convert.ToInt32(adaugacategorie.SelectedValue));

                            octrl.InnerText += adauganume.Value.ToString()+" "+adaugadata.Value.ToString()+" "+adaugapret.Value.ToString()+" "+adaugacantitate.Value.ToString() + " " + adaugacategorie.SelectedValue.ToString();
                        
                            adaugat.Controls.Add(octrl);


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