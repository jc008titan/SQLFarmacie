using Microsoft.AspNet.Identity;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Core.Mapping;
using FunctiiSQL;

namespace Farmacie1.Plugins
{
    public partial class MenuUC : System.Web.UI.UserControl
    {
        Functii fct = new Functii();
        public string id="";
        public string cont = "";
        public bool Authenticated=false;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Context.User.Identity.GetUserId();
            cont += Context.User.Identity.GetUserName();
            if (!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
        }
        protected void SignOut(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("~/Login.aspx");
        }
        protected void ExcelExport(object sender, EventArgs e)
        {
            DataTable dt = fct.Cauta("");
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage())
            {
                // Create the worksheet
                ExcelWorksheet ws = package.Workbook.Worksheets.Add("Demo");

                // Load the DataTable into the sheet, starting from cell A1. Print the column names on row 1
                ws.Cells["A1"].LoadFromDataTable(dt, true);

                // Auto-fit the columns (optional, depending on your needs)
                ws.Cells[ws.Dimension.Address].AutoFitColumns();

                // Set response headers and content type for Excel file
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment; filename=ExcelExport.xlsx");

                // Write the Excel file to the response stream
                using (var memoryStream = new System.IO.MemoryStream())
                {
                    package.SaveAs(memoryStream);
                    memoryStream.WriteTo(Response.OutputStream);
                }

                Response.Flush();
                Response.End();
            }
        }

    }
}