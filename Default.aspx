<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Farmacie1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <main>
         <a href="AdaugareMedicament.aspx">Adaugare medicament</a>
        <span id="spantest" runat="server"></span>

         <div class="row" id="divProduse" runat="server">

         </div>

        <label for="fname">Cauta medicament dupa nume </label>
         <input type="text" id="cautarenume" runat="server"><br>
        <button runat="server" id="btncauta" onserverclick="cauta_onclick">Cauta</button>
        <div id="rezultatecautare" runat="server"></div>

    </main>
    

</asp:Content>
