<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateRes.aspx.cs" Inherits="WangBowen0227SkySharkWebApplication.LOB.CreateRes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Business Executive
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:Menu ID="Menu1" runat="server" BackColor="#F7F6F3" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#7C6F57" Orientation="Horizontal" StaticSubMenuIndent="10px">
            <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#F7F6F3" />
            <DynamicSelectedStyle BackColor="#5D7B9D" />
            <Items>
                <asp:MenuItem Text="Create Reservation" Value="Create Reservation" Selected="True"></asp:MenuItem>
                <asp:MenuItem Text="Cancle Reservation" Value="Cancle Reservation" NavigateUrl="~/LOB/CancleRes.aspx"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/LOB/QuaryStat.aspx" Text="Quary Status" Value="Quary Status"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/LOB/ConfirmRes.aspx" Text="Confirm Reservation" Value="Confirm Reservation"></asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#5D7B9D" />
        </asp:Menu>
        <div class="tabContents">
            <table>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="txtUser" runat="server" Text="Make a new reservation:"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ChangePassword.aspx">Change Password</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Logff.aspx">Logoff</asp:HyperLink>
                    </td>
                </tr>
            </table>
            <asp:Wizard ID="Wizard1" runat="server" BackColor="#F7F6F3" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ActiveStepIndex="0" OnFinishButtonClick="Wizard1_FinishButtonClick" OnNextButtonClick="Wizard1_NextButtomClick1">
                <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Left" />
                <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="White" />
                <SideBarStyle BackColor="#7C6F57" BorderWidth="0px" Font-Size="0.9em" VerticalAlign="Top" />
                <StepStyle BorderWidth="0px" ForeColor="#5D7B9D" />
                <WizardSteps>
                    <asp:WizardStep ID="WizardStep1" runat="server" Title="Search Flight">
                        <table>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label1" runat="server" Text="Step 1:Specofy Ticket Details"></asp:Label></td>
                                <td></td>         
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblMessageStep1" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Flight Number"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtFltNo" runat="server"></asp:TextBox></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Class"></asp:Label></td>
                                <td>
                                    <asp:ListBox ID="lstClass" runat="server">
                                        <asp:ListItem Value="Exec">Executive</asp:ListItem>
                                        <asp:ListItem Value="Busi">Business</asp:ListItem>
                                    </asp:ListBox></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Date"></asp:Label></td>
                                <td>
                                    <asp:Calendar ID="Cal1" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Double" Border="2px" DayNameFormat="FirstTwoLetters"></asp:Calendar>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td>
                                    &nbsp;</td>
                                <td></td>
                            </tr>

                        </table>
                    </asp:WizardStep>
                    <asp:WizardStep ID="WizardStep2" runat="server" Title="Find Flight Fare &amp; Status ">
                        <table>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="Label5" runat="server" Text="Step2: Confirm flight fare & status with customer"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Ticket No"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtTNo" runat="server"></asp:TextBox></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Fare"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtFare" runat="server"></asp:TextBox></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Status"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtStatus" runat="server"></asp:TextBox></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Origin"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtOrg" runat="server"></asp:TextBox></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Destination"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtDest" runat="server"></asp:TextBox></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text="Departure Time"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtDepTime" runat="server"></asp:TextBox></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                   </td>
                                <td>
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
                    </asp:WizardStep>
                    <asp:WizardStep runat="server" Title="Make Reservation" ID="WizardStep3">
                        <table>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label12" runat="server" Text="Step3: Confirm Booking"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan ="2">
                                 <asp:Label ID="lblMessageStep3" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label></td>
                            </tr>
                           
                            <tr>
                                <td>
                                    <asp:Label ID="Label13" runat="server" Text="Name"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="Email"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtEMail" runat="server"></asp:TextBox></td>
                                <td></td>

                            </tr>
                            </table>
                    </asp:WizardStep>
                </WizardSteps>
            </asp:Wizard>
        </div>
        </form>
</asp:Content>
