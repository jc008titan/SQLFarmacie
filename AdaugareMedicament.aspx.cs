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
                fct.Adauga(adauganume.Value.ToString(), adaugadata.Value.ToString(), adaugapret.Value.ToString(), adaugacantitate.Value.ToString());

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