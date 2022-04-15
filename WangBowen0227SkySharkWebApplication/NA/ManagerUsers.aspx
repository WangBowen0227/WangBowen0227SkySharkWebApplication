<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManagerUsers.aspx.cs" Inherits="WangBowen0227SkySharkWebApplication.NA.ManagerUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Network Administrator
    <style type="text/css">
        .auto-style1 {
            height: 27px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:Menu ID="Menu1" runat="server" BackColor="#F7F6F3" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#7C6F57" Orientation="Horizontal" StaticSubMenuIndent="10px">
            <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#F7F6F3" />
            <DynamicSelectedStyle BackColor="#5D7B9D" />
            <Items>
<<<<<<< Updated upstream
                <asp:MenuItem Selected="True" Text="Manage Users" Value="Manage Users"></asp:MenuItem>
                <asp:MenuItem Text="Manage Database" Value="Manage Database" NavigateUrl="~/NA/ManageDatabase.aspx"></asp:MenuItem>
=======
>>>>>>> Stashed changes
            </Items>
            <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#5D7B9D" />
        </asp:Menu>
        <div class="tabContents">
            <table>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="txtUser" runat="server" Text="Manage User Acount:"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ChangePassword.aspx">Change Password</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Logff.aspx">Logoff</asp:HyperLink>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="True" ></asp:Label>
                    </td>
                    <td></td>

                </tr>

                <tr>
<<<<<<< Updated upstream
                    <td class="auto-style1">
                        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtAddUserName" runat="server" ></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="Label3" runat="server" Text="Delete User"></asp:Label>
                    </td>
                    <td class="auto-style1">
=======
                    </td>
                    </td>
                        <asp:Label ID="Label3" runat="server" Text="Delete User"></asp:Label>
                    </td>
>>>>>>> Stashed changes
                        <asp:TextBox ID="txtDelUserName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td></td>
                    <td>
<<<<<<< Updated upstream
                        <asp:Button ID="btnDelDelete" runat="server" Text="Delete" OnClick="btnDelDelete_Click" />
=======
>>>>>>> Stashed changes
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Confirm Password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Role"></asp:Label>
                    </td>
                    <td>
                        <asp:ListBox ID="lstAddRole" runat="server">
                            <asp:ListItem>BM</asp:ListItem>
                            <asp:ListItem>NA</asp:ListItem>
                            <asp:ListItem>LOB</asp:ListItem>
                        </asp:ListBox>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
<<<<<<< Updated upstream
                        <asp:Button ID="btnAddSubmit" runat="server" Text="Submit" OnClick="btnAddSubmit_Click" />
=======
>>>>>>> Stashed changes
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
          </div>
    </form>
</asp:Content>
