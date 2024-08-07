<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdaugareMedicament.aspx.cs"  Inherits="Farmacie1.AdaugareMedicament" %>




<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="Scripts/scripts.js"></script>
    <main aria-labelledby="title">
      Adaugare Medicament

<table class='tblresults'>
  <thead>
    <th>Nume medicament</th>
    <th>Data expirare</th>
    <th>Pret</th>
    <th>Cantitate</th>
  </thead>
  <tr>
    <td>
 <input type="text" id="adauganume" runat="server"><br>
        <div id="validarenume">Error</div>
    </td>
    <td>
    <input type="text" id="adaugadata" runat="server"><br>
        <div id="validaredata">Error</div>
    </td>
    <td>
    <input type="text" id="adaugapret" runat="server"><br>
        <div id="validarepret">Error</div>
    </td>
    <td>
    <input type="text" id="adaugacantitate" runat="server"><br>
        <div id="validarecantitate">Error</div>
    </td>
    </tr>
</table>
        <br>
           <asp:button id="btnadauga" usesubmitbehavior="true" Text="Adauga" onclientclick="javascript:return validarejavascript()" runat="server" onclick="adauga_onclick" />
        <div id="adaugat" runat="server"></div>
    </main>
</asp:Content>
