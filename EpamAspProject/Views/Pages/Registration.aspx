<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Library.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="EpamAspProject.Views.Pages.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHView" runat="server">
    <div>
        <asp:MultiView runat="server" ID = "MVRegistration" >
            <asp:View runat="server" ID="VDefault">
    <table>
        <tr><td colspan="3" align="center">Wecome to user registration page</td></tr>
        <tr><td colspan="3" align="center">Please enter information need to registration</td></tr>
        <tr>
            <td>E-mail:</td>
            <td><asp:TextBox runat="server" ID="TxtEmail"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RfvEmail" runat="server" 
                    ControlToValidate="TxtEmail" ErrorMessage="E-mail is not entered" 
                    ForeColor="Red" ValidationGroup="VGRegistration">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RevEmail" runat="server" 
                    ControlToValidate="TxtEmail" ErrorMessage="Not Email entered" ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ValidationGroup="VGRegistration">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Login:</td>
            <td><asp:TextBox runat="server" ID="TxtLogin"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RfvLogin" runat="server" 
                    ControlToValidate="TxtLogin" ErrorMessage="Login is not entered" 
                    ForeColor="Red" ValidationGroup="VGRegistration">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Password:</td>
            <td><asp:TextBox runat="server" ID="TxtPassword" TextMode="Password"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RFVPassword" runat="server" 
                    ControlToValidate="TxtPassword" ErrorMessage="Password is not entered" 
                    ForeColor="Red" ValidationGroup="VGRegistration">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RevPassword" runat="server" 
                    ControlToValidate="TxtPassword" EnableTheming="True" 
                    ErrorMessage="Password must be without white-space characters, minimum length of 8, wih one non-alpha character, one upper case character and one lower case character" 
                    ForeColor="Red" 
                    ValidationExpression="^(?=.*[^a-zA-Z])(?=.*[a-z])(?=.*[A-Z])\S{8,}$" 
                    ValidationGroup="VGRegistration">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Confirm password:</td>
            <td><asp:TextBox runat="server" ID="TxtConfirmPassword" TextMode="Password"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RfvConfirmPassword" runat="server" 
                    ControlToValidate="TxtConfirmPassword" 
                    ErrorMessage="Confirm password is not entered" ForeColor="Red" 
                    ValidationGroup="VGRegistration">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CvConfirmPassword" runat="server" 
                    ControlToCompare="TxtPassword" ControlToValidate="TxtConfirmPassword" 
                    ErrorMessage="Password and confirm password  must be the same" 
                    ForeColor="Red" ValidationGroup="VGRegistration">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Button runat="server" ID="BtnRegisration" Text="Registation" 
                    ValidationGroup="VGRegistration" onclick="BtnRegisration_Click"/></td>
            <td><asp:Button runat="server" ID="BtnCancel" Text="Cancel" 
                    CausesValidation="False" onclick="BtnCancel_Click"/></td>
            <td></td>
        </tr>
        <tr><td colspan="3"><asp:Label runat="server" ID="LblMessage" ForeColor="Red"></asp:Label></td></tr>
    </table>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ValidationGroup="VGRegistration" ForeColor="Red" />
    </asp:View>
    <asp:View runat="server" ID="VEmailValidation">
        <div>
            <table>
                <tr>
                    <td colspan="2" >On your e-mail was send the letters.</td>
                </tr>
                <tr>
                    <td colspan="2" >Please enter a secret key from it.</td>
                </tr>
                <tr>
                    <td><asp:TextBox runat="server" ID ="TxtSecretKey" TextMode="Password" Width="75px"></asp:TextBox>
                        </td>
                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="Secret key not imput" ControlToValidate="TxtSecretKey" 
                            ForeColor="Red" ValidationGroup="VGSecretKey">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RevSecretKey" runat="server" 
                            ErrorMessage="Secret key must contain 5 digits" 
                            ControlToValidate="TxtSecretKey" ForeColor="Red" 
                            ValidationGroup="VGSecretKey" ValidationExpression="\d{5}">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr><td>
                    <asp:Button runat="server" ID="BtnSendKey" Text="Send key" 
                        onclick="BtnSendKey_Click" ValidationGroup="VGSecretKey"/></td>
                        <td><asp:Button runat="server" ID="BtnCancel2" Text="Return to start page" onclick="BtnReturn_Click"/></td>
                        </tr>
            </table>
            <asp:Label runat="server" ID="LblErrMessage" ForeColor="Red"></asp:Label>
            <asp:ValidationSummary ID="VsSecretKey" runat="server" ForeColor="Red" 
                ValidationGroup="VGSecretKey" />
            <br />

        </div>
    </asp:View>
    <asp:View runat="server" ID = "VSuccess">
        <table>
            <tr><td>Registration complite success</td></tr>
            <tr><td><asp:Button runat="server" ID="BtnReturn" Text="Return to start page" 
                    onclick="BtnReturn_Click"/></td></tr>
        </table>
    </asp:View>
    </asp:MultiView>
    </div>
</asp:Content>
