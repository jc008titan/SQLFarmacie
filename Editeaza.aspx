<%@ Page Title="Edit Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editeaza.aspx.cs"  Inherits="Farmacie1.Editeaza" %>




<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="Scripts/scripts1.js"></script>

        <style>
       @media screen and (max-width: 900px) {

    .tblresults,
    .tblresults thead,
    .tblresults tbody,
    .tblresults th,
    .tblresults td,
    .tblresults tr {
        display: block;
    }

    .tblresults thead tr {
        position: absolute;
        top: -9999px;
        left: -9999px;
    }

        .tblresults tr {
            max-width:360px;
            margin-bottom: 20px;
            border: solid 1px blue;
        }

    .tblresults td {
        position: relative;
        padding-left: 50%;
    }

        .tblresults td:before {
            position: absolute;
            left: 6px;
            content: attr(data-label);
            font-weight: bold;
        }
}
    </style>
    <main aria-labelledby="title">
      Editeaza

<table class='tblresults'>
  <thead>
      <tr>
    <th>Nume medicament</th>
    <th>Data expirare</th>
    <th>Pret</th>
    <th>Cantitate</th>
      <th>Categorie</th>
          </tr>
  </thead>
   <tr>
      <td data-label="Nume">
<input type="text"  id="adauganume" runat="server"><br>
       <div id="validarenume">Error</div>
   </td>
   <td data-label="Data_Expirare">
   <input type="text"   id="adaugadata" runat="server"><br>
       <div id="validaredata">Error</div>
   </td>
   <td data-label="Pret">
   <input type="text"  id="adaugapret" runat="server"><br>
       <div id="validarepret">Error</div>
   </td>
   <td data-label="Cantitate">
   <input type="text"  id="adaugacantitate" runat="server"><br>
       <div id="validarecantitate">Error</div>
   </td>
       <td data-label="Categorie">
           <asp:DropDownList ID="adaugacategorie" runat="server"></asp:DropDownList>
    <div id="validarecategorie">Error</div>
           </td>
   </tr>
</table>
        <br>
           <asp:button id="btnadauga" usesubmitbehavior="true" Text="Modifica" onclientclick="javascript:return validarejavascript()" runat="server" onclick="adauga_onclick" />
        <div id="adaugat" runat="server"></div>
    </main>
</asp:Content>
