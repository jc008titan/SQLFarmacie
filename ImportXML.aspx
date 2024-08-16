<%@ Page Title="Import Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImportXML.aspx.cs" Inherits="Farmacie1.ImportXML" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <main>
              <asp:FileUpload ID="fileUploadExcel" runat="server" />
        <br /><br />
        <asp:Button ID="btnUpload" runat="server" Text="Upload XML File" OnClick="btnUpload_Click" />
        <div id="rezultat" runat="server"></div>
    </main>
    

</asp:Content>