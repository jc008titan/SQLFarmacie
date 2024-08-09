<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editeaza.aspx.cs"  Inherits="Farmacie1.Editeaza" %>




<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="Scripts/scripts1.js"></script>
    <main aria-labelledby="title">
      Editeaza

<table class='tblresults'>
  <thead>
    <th>Nume medicament</th>
    <th>Data expirare</th>
    <th>Pret</th>
    <th>Cantitate</th>
      <th>Categorie</th>
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
       <td>
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
