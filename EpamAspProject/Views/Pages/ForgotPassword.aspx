<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Library.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="EpamAspProject.Views.Pages.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHView" runat="server">
    <asp:MultiView runat="server" ID="MVForgotPass">
        <asp:View runat="server" ID="VStart">
            <table>
                <tr>
                    <td>Enter your e-mail</td>
                    <td><asp:TextBox runat="server" ID="TxtEMail" Text=""/></td>
                    <td>
                        <asp:RequiredFieldValidator runat="server" ID="RfvEMail" Text="*" ValidationGroup="VGFogotPass" ForeColor="Red" ControlToValidate="TxtEMail" ErrorMessage="E-mail not entered" Display="Static"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="RevEMail" Text="*" 
                            ValidationGroup="VGFogotPass" ForeColor="Red" ControlToValidate="TxtEMail" 
                            Display="Static" ErrorMessage="Invalid e-mail" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td><asp:Button runat="server" ID="BtnCreateNewPass" Text="Create new password" OnClick="BtnCreateNewPasswordClick" ValidationGroup="VGFogotPass" CausesValidation="True"/></td>
                    <td><asp:Button runat="server" ID="BtnCancel" Text="Cancel" CausesValidation="False" OnClick="BtnCancelClick"/></td>
                </tr>
            </table>
            <asp:Label runat="server" ID="LblMessage" Text="" ForeColor="Red"></asp:Label>
            <asp:ValidationSummary runat="server" ID="VSFogotPass" ValidationGroup="VGFogotPass" ForeColor="Red"/>
        </asp:View>
        <asp:View runat="server" ID="VSuccess">
            New password was send on your e-mail. <br/>
            <asp:Button runat="server" ID="BtnReturnToMain" Text="Return to main" CausesValidation="False" OnClick="BtnReturnToMainClick"/>
        </asp:View>
    </asp:MultiView>
</asp:Content>
