<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Logff.aspx.cs" Inherits="WangBowen0227SkySharkWebApplication.Logff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    HOME
<style type="text/css">
    #TextArea1 {
        height: 218px;
        width: 1178px;
    }
</style>
    <style type="text/css">
        #TextArea1 {
            height: 115px;
            width: 1183px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div>
        <textarea id="TextArea1">
            Thank you for using SkyShark Airline.
            Looking forward for serving you again.
        </textarea>

        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/default.aspx">Click here to logon</asp:HyperLink>

    </div>
</form>
</asp:Content>
