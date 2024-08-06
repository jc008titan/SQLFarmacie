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
        <div id="validarenume"><label>Eroare</label></div>
    </td>
    <td>
    <input type="text" id="adaugadata" runat="server"><br>
        <div id="validaredata"><label>Eroare</label></div>
    </td>
    <td>
    <input type="text" id="adaugapret" runat="server"><br>
        <div id="validarepret"><label>Eroare</label></div>
    </td>
    <td>
    <input type="text" id="adaugacantitate" runat="server"><br>
        <div id="validarecantitate"><label>Eroare</label></div>
    </td>
    </tr>
</table>
        <br>
           <asp:button id="btnadauga" usesubmitbehavior="true" Text="Adauga" onclientclick="javascript:return valideazadate()" runat="server" onclick="adauga_onclick" />
        <div id="adaugat" runat="server"></div>
    </main>
</asp:Content>
