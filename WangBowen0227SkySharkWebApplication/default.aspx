<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WangBowen0227SkySharkWebApplication._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    HOME
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Welcome to Shyshark Airline Home Page</h1>
    <asp:Image ID="Image1" runat="server"  ImageUrl="~/skyShark.png" Width="1000px"/>
    <p>
        Launched in 1999,skyshark Airlines is a United States-based airline that has rapidly grown in the past years.
        <form id="form1" runat="server">
            <div>
                <table>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </td>
                        <td></td>
                       
                    </tr>
                    <tr>
                        <td>
                            &nbsp;<asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage="Please pectify a valid user name."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please pectify a valid password."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>

                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                </table>
            </div>

        </form>
    </p>
</asp:Content>
