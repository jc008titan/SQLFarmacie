<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFormsIdentity.Login" %>
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
</head>
<body style="font-family: Arial, Helvetica, sans-serif; font-size: small;background-color:gray">
   <form id="form1" runat="server">
       <div class="w3-container" style="width:700px;margin: auto;margin-top:60px;"> 
      <div class="w3-container w3-card-4 w3-light-grey">
         <h2 style="text-align:center;font-family:'Calibri'">Conecteaza-te</h2>
          <div style="color:red;font-size: 16px;">
         <asp:PlaceHolder runat="server" ID="LoginStatus" Visible="false">
             
            <p>
               <asp:Literal runat="server" ID="StatusText" />
            </p>
         </asp:PlaceHolder>
              </div>
         <asp:PlaceHolder runat="server" ID="LoginForm" Visible="false">
             
            <div style="margin-bottom: 10px">
               <h4>
                <asp:Label runat="server" AssociatedControlID="UserName">Nume utilizator</asp:Label>
               </h4>
                   <div>
                  <asp:TextBox class="w3-input w3-border" style="width:600px;font-size:18px" runat="server" ID="UserName" />
               </div>
            </div>
            <div style="margin-bottom: 10px">
                <h4>
               <asp:Label runat="server" AssociatedControlID="Password">Parola</asp:Label>
               </h4>
                    <div>
                  <asp:TextBox runat="server" class="w3-input w3-border" style="width:600px;font-size:18px" ID="Password" TextMode="Password" />
                       </div>
            </div>
            <div style="margin-bottom: 10px">
                <br/>
               <div>
                  <asp:Button runat="server" style="border-radius: 8px;padding: 4px;text-align: center;cursor:pointer;background-color:darkgray;font-size: 20px;width:120px;font-family:'Calibri'" OnClick="SignIn" Text="Conectare" />
               </div>
            </div>
         </asp:PlaceHolder>
          <br/>
         <asp:PlaceHolder runat="server" ID="LogoutButton" Visible="false">
            <div>
               <div>
                  <asp:Button runat="server" OnClick="SignOut" Text="Deconectare" />
               </div>
            </div>
         </asp:PlaceHolder>
           <span style="font-size:16px">Nu ai cont?</span> <a style="font-size:16px;color:#0000EE;" href="Register.aspx">Inregistreaza-te</a>
      </div>
           </div>
   </form>
</body>
</html>