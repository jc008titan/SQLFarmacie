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

namespace Farmacie1
{
    public partial class AdaugareMedicament : Page
    {
        Functii fct = new Functii();
        
        protected void Page_Load(object sender, EventArgs e)
        {
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
                        //(snip) Log Exceptions
                    }
                
        }
    }
}