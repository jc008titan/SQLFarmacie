<%@ Page Title="Stock Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="Farmacie1.Stock" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <main>
        <script>
            function showStock(str) {
                var xhttp;
                xhttp = new XMLHttpRequest();
                xhttp.onreadystatechange = function () {
                    if (this.readyState == 4 && this.status == 200) {
                        document.getElementById("<%=stock.ClientID%>").innerHTML = this.responseText;
                    }
                };
                xhttp.open("GET", "StockAJAX.aspx?cat=" + str, true);
                xhttp.send();
            }
        </script>
        <asp:DropDownList ID="adaugacategorie" runat="server" onchange="showStock(this.value)"></asp:DropDownList>
        <br /> <br /> 
         <div id="stock" runat="server"></div>

    </main>
    

</asp:Content>
