<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebFormsIdentity.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-family: Arial, Helvetica, sans-serif; font-size: small">
    <script>
        function ConfirmareParola() {
            if (document.getElementById("<%=Password.ClientID%>").value == document.getElementById("<%=ConfirmPassword.ClientID%>").value)
                return true;
            else
            {
                document.getElementById("eroare").style.display = "block"
            return false;
            }
        }
    </script>
    <form id="form1" runat="server">
    <div>
        <h4 style="font-size: medium">Inregistreaza un nou utilizator</h4>
        <hr />
        <p>
            <asp:Literal runat="server" ID="StatusMessage" />
        </p>                
        <div style="margin-bottom:10px">
            <asp:Label runat="server" AssociatedControlID="UserName">Nume utilizator</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="UserName" />                
            </div>
        </div>
        <div style="margin-bottom:10px">
            <asp:Label runat="server" AssociatedControlID="Password">Parola</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="Password" TextMode="Password" />                
            </div>
        </div>
        <div style="margin-bottom:10px">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirma parola</asp:Label>
            
            <div>
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />                
            </div>
            <label id="eroare" style="color:red;display:none;">Parola nu este aceeasi</label>
        </div>
        <div>
            <div>
                <asp:Button runat="server" UseSubmitBehavior="true" onclientclick="return ConfirmareParola()" OnClick="CreateUser_Click" Text="Inregistreaza" />
            </div>
        </div>
    </div>
        <span>Ai deja cont?</span> <a href="Login.aspx">Conecteaza-te</a>
    </form>
</body>
</html>