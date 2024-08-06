<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdaugareMedicament.aspx.cs"  Inherits="Farmacie1.AdaugareMedicament" %>




<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
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
    </td>
    <td>
    <input type="text" id="adaugadata" runat="server"><br>
    </td>
    <td>
    <input type="text" id="adaugapret" runat="server"><br>
    </td>
    <td>
    <input type="text" id="adaugacantitate" runat="server"><br>
    </td>
    </tr>
</table>
        <br>
        <button runat="server" id="btnadauga" onserverclick="adauga_onclick">Adauga</button>
        <div id="adaugat" runat="server"></div>
    </main>
</asp:Content>
