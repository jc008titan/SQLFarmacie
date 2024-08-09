<%@ Page Title="Search Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cauta.aspx.cs" Inherits="Farmacie1.Cauta" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <main>
        <label for="fname">Cauta medicament dupa nume </label>
         <input type="text" id="cautarenume" runat="server">
        <button runat="server" id="btncauta" onserverclick="cauta_onclick">Cauta</button>
        <div id="rezultatecautare" runat="server"></div>

    </main>
    

</asp:Content>
