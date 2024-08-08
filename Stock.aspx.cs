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
    public partial class Stock : Page
    {
        Functii fct = new Functii();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{

            try
            {


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

    }

    
}