<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PumpHouse.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="container">
      <div class="center">
          <h1>Login</h1>
          <div action="" method="POST">
              <div class="txt_field">
                  <label>E-mail</label>
                  <input type="text" id="Email" runat="server" name="Email" required>
                  <span></span>
                  
              </div>
              <div class="txt_field">
                  <label>Password</label>
                  <input type="password" id="User_Password" runat="server" name="password" required>
                  <span></span>
                  
              </div>
              <div class="pass">Forget Password?</div>
              <asp:Button ID="login" runat="server" Text="Login" OnClick="login_Click" />
              <div class="signup_link">
                  Not a Member ? <a href="Register.aspx">Signup</a>
              </div>
        </div>
      </div>
    </div>
  
</asp:Content>
