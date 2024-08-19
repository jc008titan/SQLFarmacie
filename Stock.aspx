<%@ Page Title="Stock Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="Farmacie1.Stock" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <main>
        <script>
            function removeOption() {
                var x = document.getElementById("MainContent_adaugacategorie");
                    if (x.options[0].innerHTML != "Toate") {
                        x.remove(0);
                    }
            }
            function showStock(str) {
                removeOption();
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
            function openpage(page_nr) {
                var url = window.location.href.split("page")[0].replace("&", "");

                if (url.indexOf('?') > 0) {
                    window.location.href = url + "&page=" + page_nr;
                }
                else
                {
                    window.location.href = url + "?page=" + page_nr;
                }
            }
            function hidepaging() {
                document.getElementById("MainContent_paging").style.display = "none";
            }
        </script>
        <asp:DropDownList ID="adaugacategorie" runat="server" onchange="showStock(this.value);hidepaging()"></asp:DropDownList>
        <br /> <br /> 
         <div id="stock" runat="server"></div>
        <div id="paging" runat="server"><!--a herf="javascript:OpenPage('1')" /><a herf="javascript:OpenPage('2')" /--></div>

    </main>
    

</asp:Content>
