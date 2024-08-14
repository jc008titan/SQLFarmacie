using ClassLibrary1;
using FunctiiSQL;
using Microsoft.AspNet.Identity;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Engineering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Farmacie1
{
    public partial class ImportExcel : System.Web.UI.Page
    {
        Functii fct = new Functii();
        ErrorLogs err = new ErrorLogs();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.GetUserId() != "2c3fd8ce-7b56-4763-af75-0a0a31f73288")
                Response.Redirect("~/Default.aspx");
        }
       

protected void btnUpload_Click(object sender, EventArgs e)
    {
            try
            {
                string filePath = "";
                // Previous code for file upload
                if (fileUploadExcel.HasFile)
                {
                    filePath = Server.MapPath("~/Files/") + fileUploadExcel.FileName;
                    fileUploadExcel.SaveAs(filePath);

                    // Further processing steps will be added to read the uploaded Excel file.
                }
                else
                {
                    // Handle case where no file is selected for upload.
                }
                if (File.Exists(filePath))
                {
                    string nume = "";
                    string data = "";
                    string pret = "";
                    string cantitate = "";
                    int cat = 0;
                    bool ok = false;
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelPackage package = new ExcelPackage(new FileInfo(filePath));
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming data is in the first sheet

                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;
                    DataTable dt = new DataTable();

                    for (int row = 1; row <= rowCount - 1; row++)
                    {
                        nume = "";
                        data = "";
                        pret = "";
                        cantitate = "";
                        cat = 0;
                        for (int col = 1; col <= colCount; col++)
                        {
                            if (worksheet.Cells[row + 1, col].Value != null)
                            {
                                if (worksheet.Cells[1, col].Value.ToString() == "Nume")
                                    nume = worksheet.Cells[row + 1, col].Value.ToString();
                                if (worksheet.Cells[1, col].Value.ToString() == "Data_Expirare")
                                    data = worksheet.Cells[row + 1, col].Value.ToString();
                                if (worksheet.Cells[1, col].Value.ToString() == "Pret")
                                    pret = worksheet.Cells[row + 1, col].Value.ToString();
                                if (worksheet.Cells[1, col].Value.ToString() == "Cantitate")
                                    cantitate = worksheet.Cells[row + 1, col].Value.ToString();
                                if (worksheet.Cells[1, col].Value.ToString() == "Categorie")
                                    cat = Convert.ToInt32(worksheet.Cells[row + 1, col].Value);
                            }
                            else  break; 
                        }
                        dt = fct.Cauta(nume.Trim());
                        if (nume != "" && data != "" && pret != "" && cantitate != "" && cat != 0)
                        {
                            if (dt.Rows.Count == 0)
                                fct.Adauga(nume, data, pret, cantitate, cat);
                            else fct.Editeaza(nume, data, pret, cantitate, Convert.ToInt32(dt.Rows[0]["ID"]), cat);
                            ok = true;
                        }
                        
                    }
                    if (ok == false)
                    {
                        HtmlGenericControl octrl = new HtmlGenericControl("span");
                        octrl.InnerText += "Nu s-a putut realiza importarea.";
                        rezultat.Controls.Add(octrl);
                    }
                    else
                    {
                        HtmlGenericControl octrl = new HtmlGenericControl("span");
                        octrl.InnerText += "Importare realizata cu succes!";
                        rezultat.Controls.Add(octrl);
                    }

                    package.Dispose(); // Dispose the package after use

                    
                }
                else
                {
                    HtmlGenericControl octrl = new HtmlGenericControl("span");
                    octrl.InnerText += "Nu s-a putut realiza importarea.";
                    rezultat.Controls.Add(octrl);
                    // Handle case where the file does not exist
                }
            }
            catch (Exception ex)
            {
                err.WriteLogException(ex);
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