<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuUC.ascx.cs" Inherits="Farmacie1.Plugins.MenuUC" %>
<div class="navbar" runat="server">
<a href="default.aspx">Home</a>
  <div class="dropdown">
    <button class="dropbtn" onclick="window.location.href='Stock.aspx'">Stock
    </button>
    <div class="dropdown-content">
      <a href="Stock.aspx">Toate</a>
      <a href="Stock.aspx?cat=2">Medicamente fara reteta</a>
      <a href="Stock.aspx?cat=4">Vitamine si suplimente</a>
      <a href="Stock.aspx?cat=5">Frumusete</a>
    </div>
  </div> 
  
  <a href="Cauta.aspx">Cauta</a>
  <a href="AdaugareMedicament.aspx">Adauga</a>
</div><br />