<%@ Page Title="Search Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cauta.aspx.cs" Inherits="Farmacie1.Cauta" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <main>
        <script>
            <%--function openpage(page_nr) {
                var url = window.location.href.split("page")[0].replace("&&", "&");

                if (url.indexOf('?') > 0) {
                    window.location.href = url + "&page=" + page_nr + "&cauta=" + document.getElementById("<%=cautarenume.ClientID%>").value;
                }
                else {
                    window.location.href = url + "?page=" + page_nr + "&cauta=" + document.getElementById("<%=cautarenume.ClientID%>").value;
                }
            }--%>
    //        function openpage1(page_nr, sCauta) {
    //            var url = window.location.href.split("page")[0].replace("&&", "&");

    //            if (url.indexOf('?') > 0) {
    //                window.location.href = url + "&page=" + page_nr + "&cauta=" + sCauta;
    //}
    //else {
    //                window.location.href = url + "?page=" + page_nr + "&cauta=" + sCauta;
    //            }
    //        }
            function openpage(page_nr) {
                var url = window.location.href
                    .replace(/&&/g, '&')  // Replace && with &
                    .replace(/(\?|&)page=\d+/g, '') // Remove existing "page" parameters
                    .replace(/(\?|&)cauta=[^&]*/g, '') // Remove existing "cauta" parameters
                    .replace(/&+/g, '&')   // Replace multiple & with a single &
                    .replace(/\?&/, '?')   // Fix if the first parameter was removed, leaving a dangling &
                    .replace(/(\?|&)$/, ''); // Remove trailing ? or &

                if (url.indexOf('?') > 0) {
                    window.location.href = url + (url.endsWith('?') ? "" : "&") + "page=" + page_nr + "&cauta=" + encodeURIComponent(document.getElementById("<%=cautarenume.ClientID%>").value);
                }
                else {
                    window.location.href = url + "?page=" + page_nr + "&cauta=" + encodeURIComponent(document.getElementById("<%=cautarenume.ClientID%>").value);
                }
            }     
            function openpage1(page_nr, sCauta) {
                var url = window.location.href
                    .replace(/&&/g, '&')  // Replace && with &
                    .replace(/(\?|&)page=\d+/g, '') // Remove existing "page" parameters
                    .replace(/(\?|&)cauta=[^&]*/g, '') // Remove existing "cauta" parameters
                    .replace(/&+/g, '&')   // Replace multiple & with a single &
                    .replace(/\?&/, '?')   // Fix if the first parameter was removed, leaving a dangling &
                    .replace(/(\?|&)$/, ''); // Remove trailing ? or &

                if (url.indexOf('?') > 0) {
                    window.location.href = url + (url.endsWith('?') ? "" : "&") + "page=" + page_nr + "&cauta=" + sCauta;
    }
    else {
                    window.location.href = url + "?page=" + page_nr + "&cauta=" + sCauta;
                }
            }  
            
        </script>

        <label for="fname">Cauta medicament dupa nume </label>
         <input type="text" id="cautarenume" runat="server">
        <button runat="server" id="btncauta" onserverclick="cauta_onclick">Cauta</button>
        <div id="rezultatecautare" runat="server"></div>
        <div id="paging" runat="server"></div>

    </main>
    

</asp:Content>
