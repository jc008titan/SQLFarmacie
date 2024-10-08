﻿<%@  Page Title="Stock Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="Farmacie1.Stock"%>

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
            /*function openpage(page_nr) {
                var url = window.location.href
                    .replace(/&&/g, '&')  // Replace && with &
                    .replace(/(\?|&)page=\d+(&|$)/g, '$2') // Remove all "page" parameters
                    .replace(/&+/g, '&')   // Replace multiple & with a single &
                    .replace(/\?&/, '?')   // Fix if the first parameter was removed, leaving a dangling &
                    .replace(/(\?|&)$/, ''); // Remove trailing ? or &

                // Append the new page parameter
                if (url.indexOf('?') > 0) {
                    // If URL already has parameters, append with &
                    window.location.href = url + (url.endsWith('?') ? '' : '&') + "page=" + page_nr;
                } else {
                    // If no parameters, start with ?
                    window.location.href = url + "?page=" + page_nr;
                }
            }*/
            //function sortglobal(criteriu, ad) {
            //    var url = window.location.href
            //        .replace(/&&/g, '&')  // Replace && with &
            //        .replace(/(\?|&)criteriu=[^&]*/g, '') // Remove all "criteriu" parameters
            //        .replace(/&+/g, '&')   // Replace multiple & with a single &
            //        .replace(/\?&/, '?')   // Fix if the first parameter was removed, leaving a dangling &
            //        .replace(/(\?|&)$/, ''); // Remove trailing ? or &

            //    // Append the new criteriu parameter
            //    if (url.indexOf('?') > 0) {
            //        // If URL already has parameters, append with &
            //        window.location.href = url + (url.endsWith('?') ? '' : '&') + "criteriu=" + criteriu + ad;
            //    } else {
            //        // If no parameters, start with ?
            //        window.location.href = url + "?criteriu=" + criteriu + ad;
            //    }
            //}
            function openpage(page_nr) {
                let url = new URL(window.location.href);
                let params = new URLSearchParams(url.search);

                // Set or update the page parameter
                params.set('page', page_nr);

                // Update the URL with the new parameters
                url.search = params.toString();

                // Redirect to the updated URL
                window.location.href = url.toString();
            }
            function sortglobal(criteriu, ad) {
                let url = new URL(window.location.href);
                let params = new URLSearchParams(url.search);

                // Set or update the criteriu parameter
                params.set('criteriu', criteriu + ad);

                // Update the URL with the new parameters
                url.search = params.toString();

                // Redirect to the updated URL
                window.location.href = url.toString();
            }
            function openpage1(page_nr, cat,criteriu) {
               // var url = window.location.href.split("?")[0];
             //   window.location.href = url + "?page=" + page_nr + "&cat=" + sCauta;

                var xhttp;
                xhttp = new XMLHttpRequest();
                xhttp.onreadystatechange = function () {
                    if (this.readyState == 4 && this.status == 200) {
                        document.getElementById("<%=stock.ClientID%>").innerHTML = this.responseText;
                    }
                };
                if (page_nr == "") page_nr = 1;
                if (cat == "0") cat = '';
                if (cat.trim() == '')
                    if (criteriu.trim() == '')
                        xhttp.open("GET", "StockAJAX.aspx?page=" + page_nr, true);
                    else
                        xhttp.open("GET", "StockAJAX.aspx?page=" + page_nr + "&criteriu=" + criteriu, true);
                else
                    if (criteriu.trim() == '')
                        xhttp.open("GET", "StockAJAX.aspx?cat=" + cat + "&page=" + page_nr, true);
                    else
                        xhttp.open("GET", "StockAJAX.aspx?cat=" + cat + "&page=" + page_nr + "&criteriu=" + criteriu, true);
                xhttp.send();
                
            }
            function hidepaging() {
                document.getElementById("MainContent_paging").style.display = "none";
            }
        </script>
        <asp:DropDownList  ID="adaugacategorie" runat="server" onchange="showStock(this.value);hidepaging()"></asp:DropDownList>
        <br /> <br /> 
         <div id="stock" runat="server"></div>
        <br/>
        <div style="margin-left:220px" id="paging" runat="server"><!--a herf="javascript:OpenPage('1')" /><a herf="javascript:OpenPage('2')" /--></div>

    </main>
    

</asp:Content>
