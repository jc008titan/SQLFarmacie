using ClassLibrary1;
using FunctiiSQL;
using Microsoft.AspNet.Identity;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Engineering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;

namespace Farmacie1
{


    [XmlRoot("MedicamenteXML")]
    public class MedicamenteXML
    {
        [XmlElement("MedicamentXML")]
        public List<MedicamentXML> medicamentXML { get; set; }
    }
    public partial class MedicamentXML
    {
        //[Key]
        [XmlElement("Nume")]
        public string Nume { get; set; }
        [XmlElement("Data_Expirare")]
        public string Data_Expirare { get; set; }
        [XmlElement("Pret")]
        public float? Pret { get; set; }
        [XmlElement("Cantitate")]
        public int? Cantitate { get; set; }
        [XmlElement("Categorie")]
        public int? Categorie { get; set; }
    }


    public partial class ImportXML : System.Web.UI.Page
    {
        Medicament medicament = new Medicament();
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
                bool ok = false;
                if (fileUploadExcel.HasFile)
                {
                    filePath = Server.MapPath("~/Files/") + fileUploadExcel.FileName;
                    fileUploadExcel.SaveAs(filePath);
                    if (File.Exists(filePath))
                    {
                        XmlReader reader = XmlReader.Create(filePath);
                        XmlSerializer serializer = new XmlSerializer(typeof(MedicamenteXML));
                        MedicamenteXML medicamenteXML = (MedicamenteXML)serializer.Deserialize(reader);
                        DataTable dt = new DataTable();
                        for (int i = 0; i < medicamenteXML.medicamentXML.Count; i++)
                        {
                            dt = fct.Cauta(medicamenteXML.medicamentXML[i].Nume.Trim());
                            if (medicamenteXML.medicamentXML[i].Nume != "" && medicamenteXML.medicamentXML[i].Data_Expirare != "" && medicamenteXML.medicamentXML[i].Pret != null && medicamenteXML.medicamentXML[i].Cantitate != null && medicamenteXML.medicamentXML[i].Categorie != null)
                            { medicament.Nume = medicamenteXML.medicamentXML[i].Nume.ToString();
                                medicament.Data_Expirare = medicamenteXML.medicamentXML[i].Data_Expirare.ToString();
                                medicament.Pret = medicamenteXML.medicamentXML[i].Pret.ToString();
                                medicament.Cantitate = medicamenteXML.medicamentXML[i].Cantitate.ToString();
                                if (dt.Rows.Count != 0) medicament.id = Convert.ToInt32(dt.Rows[0]["ID"]);
                                medicament.Categorie = Convert.ToInt32(medicamenteXML.medicamentXML[i].Categorie);

                                if (dt.Rows.Count == 0)
                                    fct.Adauga(medicament);
                                else fct.Editeaza(medicament);
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
                        reader.Close();
}
                }
                else
                {
                    HtmlGenericControl octrl = new HtmlGenericControl("span");
                    octrl.InnerText += "Nu s-a putut realiza importarea.";
                    rezultat.Controls.Add(octrl);
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