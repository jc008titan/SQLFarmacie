<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebFormsIdentity.Register" %>
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-family: Arial, Helvetica, sans-serif; font-size: small;background-color:gray">
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
         <div class="w3-container" style="width:700px;margin: auto;margin-top:60px;"> 
        <div class="w3-container w3-card-4 w3-light-grey">
    <div>
        <h2 style="text-align:center;font-family:'Calibri'">Inregistreaza un nou utilizator</h2>
        <hr />
        <div style="color:red;font-size: 16px;">
        <p>
            <asp:Literal runat="server" ID="StatusMessage" />
            <label id="eroare" style="color:red;font-size: 16px;display:none">Parola nu este aceeasi</label>
        </p>                
            </div>
        <div style="margin-bottom:10px">
            <h4>
            <asp:Label runat="server" AssociatedControlID="UserName">Nume utilizator</asp:Label>
            </h4>
                <div>
                <asp:TextBox class="w3-input w3-border" style="width:600px;font-size:18px" runat="server" ID="UserName" />                
            </div>
        </div>
        <div style="margin-bottom:10px">
            <h4>
            <asp:Label runat="server" AssociatedControlID="Password">Parola</asp:Label>
                </h4>
            <div>
                
                <asp:TextBox class="w3-input w3-border" style="width:600px;font-size:18px" runat="server" ID="Password" TextMode="Password" />                
                
                    </div>
        </div>
        <div style="margin-bottom:10px">
            <h4>
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirma parola</asp:Label>
            </h4>
            
            <div>
                
                <asp:TextBox class="w3-input w3-border" style="width:600px;font-size:18px" runat="server" ID="ConfirmPassword" TextMode="Password" />                
                
                    </div>
            <br/>
            
        </div>
        <div>
            <div>
                <asp:Button style="border-radius: 8px;padding: 4px;text-align: center;cursor:pointer;background-color:darkgray;font-size: 20px;width:120px;font-family:'Calibri'" runat="server" UseSubmitBehavior="true" onclientclick="return ConfirmareParola()" OnClick="CreateUser_Click" Text="Inregistreaza" />
            </div>
        </div>
    </div>
            <br/>
        <span style="font-size:16px">Ai deja cont?</span> <a style="font-size:16px;color:#0000EE;" href="Login.aspx">Conecteaza-te</a>
    </div>
             </div>
    </form>
</body>
</html>