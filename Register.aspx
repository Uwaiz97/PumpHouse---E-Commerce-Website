<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PumpHouse.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="center">
            <h1>Register</h1>
            <div method="POST" action="">
                <div class="txt_field">
                    <input type="text" id="username" runat="server" name="Username" required />
                    <span></span>
                    <label>Name</label>
                </div>
                 <div class="txt_field">
                    <input type="text" id="surname" runat="server" name="Surname" required />
                    <span></span>
                    <label>Surname</label>
                </div>
                <div class="txt_field">
                    <input type="email" id="email" runat="server" name="Email" required />
                    <span></span>
                    <label>Email</label>
                </div>
                 <div class="txt_field">
                    <input type="text" id="PhoneNo" runat="server" name="Phone Number" required />
                    <span></span>
                    <label>Contact Number</label>
                </div>
                <div class="txt_field">
                    <input type="password" id="Password" runat="server" name="Password" required />
                    <span></span>
                    <label>Password</label>
                </div>
                <div class="txt_field">
                    <input type="password" id="ConPassword" runat="server" name="cpassword" required />
                    <span></span>
                    <label>Confirm Password</label>
                </div>
                
                <asp:Button ID="btnReg" runat="server" Text="Sign Up" OnClick="btnReg_Click" />
                <div class="signup_link">
                    Have an account ? <a href="Login.aspx">Login Here</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
