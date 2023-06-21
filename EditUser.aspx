<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="PumpHouse.EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="center">
            <h1>Edit Details</h1>
            <div method="POST" action="">
                <div class="txt_field">
                    <input type="text" id="username" runat="server" name="Username" />
                    <span></span>
                    <label>Username</label>
                </div>
                <div class="txt_field">
                    <input type="email" id="email" runat="server" name="Email" />
                    <span></span>
                    <label>Email</label>
                </div>
                <div class="txt_field">
                    <input type="text" id="PhoneNo" runat="server" name="Phone Number" />
                    <span></span>
                    <label>Contact Number</label>
                </div>
               <asp:Button ID="btnEdit" runat="server" Text="Submit Changes" OnClick="btnEdit_Click" /> 
            </div>
        </div>
    </div>
</asp:Content>
