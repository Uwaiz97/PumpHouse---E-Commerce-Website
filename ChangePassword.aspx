<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="PumpHouse.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <label>New Password</label>
    <input type="password" id="NuPassword" placeholder="Your Password" required="required" runat="server" />
    <br />

    <label>Confirm Password </label>
    <input type="password"  id="ConPassword" placeholder="Confirm Password" required="required" runat="server" />
   <br />
    <asp:Button ID="NuPassowrd" runat="server" Text="Change Password" OnClick="NuPassowrd_Click" />
</asp:Content>
