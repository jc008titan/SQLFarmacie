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
                let url = new URL(window.location.href);
                let params = new URLSearchParams(url.search);

                // Get the value for the "cauta" parameter from a DOM element
                let cautaValue = encodeURIComponent(document.getElementById("<%=cautarenume.ClientID%>").value);

                // Set or update the "page" and "cauta" parameters
                params.set('page', page_nr);
                params.set('cauta', cautaValue);

                // Update the URL with the new parameters
                url.search = params.toString();

                // Redirect to the updated URL
                window.location.href = url.toString();
            }
            function openpage1(page_nr, sCauta) {
                let url = new URL(window.location.href);
                let params = new URLSearchParams(url.search);

                // Set or update the "page" and "cauta" parameters
                params.set('page', page_nr);
                params.set('cauta', sCauta);

                // Update the URL with the new parameters
                url.search = params.toString();

                // Redirect to the updated URL
                window.location.href = url.toString();
            }
            function sortglobal(criteriu, ad) {
                let url = new URL(window.location.href);
                let params = new URLSearchParams(url.search);

                // Retrieve and encode the value for the "cauta" parameter from a DOM element
                let cautaElement = document.getElementById("<%=cautarenume.ClientID%>");
                let cautaValue = cautaElement ? encodeURIComponent(cautaElement.value) : '';

                // Set or update the parameters
                params.set('page', 1);          // Update or add the "page" parameter
                params.set('criteriu', criteriu + ad); // Update or add the "criteriu" parameter
                params.set('cauta', cautaValue);       // Update or add the "cauta" parameter

                // Update the URL with the new parameters
                url.search = params.toString();

                // Redirect to the updated URL
                window.location.href = url.toString();
            }
            function sortglobal1(criteriu, ad, sCauta) {
                let url = new URL(window.location.href);
                let params = new URLSearchParams(url.search);

                // Set or update the parameters
                //params.set('page', page_nr);          // Update or add the "page" parameter
                params.set('criteriu', criteriu + ad); // Update or add the "criteriu" parameter
                params.set('cauta', sCauta);           // Update or add the "cauta" parameter

                // Update the URL with the new parameters
                url.search = params.toString();

                // Redirect to the updated URL
                window.location.href = url.toString();
            }
            
        </script>

        <label for="fname">Cauta medicament dupa nume </label>
         <input type="text" id="cautarenume" runat="server">
        <button runat="server" id="btncauta" onserverclick="cauta_onclick">Cauta</button>
        <div id="rezultatecautare" runat="server"></div>
        <div id="paging" runat="server"></div>

    </main>
    

</asp:Content>
