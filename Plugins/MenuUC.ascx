<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuUC.ascx.cs" Inherits="Farmacie1.Plugins.MenuUC" %>
<div class="navbar" runat="server">
<a href="default.aspx">Home</a>
  <div class="dropdown">
    <asp:Button class="dropbtn" OnClientClick="window.location.href='Stock.aspx'; return false;" Text="Stock" runat="server" CausesValidation="false">
    </asp:Button>
    <div class="dropdown-content">
      <a href="Stock.aspx">Toate</a>
      <a href="Stock.aspx?cat=2">Medicamente fara reteta</a>
      <a href="Stock.aspx?cat=4">Vitamine si suplimente</a>
      <a href="Stock.aspx?cat=5">Frumusete</a>
    </div>
  </div> 
  <a href="Cauta.aspx">Cauta</a>
  <%if (id == "2c3fd8ce-7b56-4763-af75-0a0a31f73288")
      {  %><a href="AdaugareMedicament.aspx">Adauga</a> <% } %>


    <div class="logout">
      <asp:Button class="logoutbtn" ID="LogoutButton" runat="server" OnClick="SignOut" Text="Deconectare" />
</div>

        <div class="cont">
                <span>Cont:</span>
     <%if (id == "2c3fd8ce-7b56-4763-af75-0a0a31f73288")
    {%><span style="color:orange">
        <%=cont%>
       </span><% 
    }
     else
     {%><span style="color:lightgreen">
         <%Response.Write(cont);%>
        </span><% 
     }%>
    </div>
</div><br />