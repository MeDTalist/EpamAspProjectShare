<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Library.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="EpamAspProject.Views.Pages.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHView" runat="server">
    <asp:MultiView runat="server" ID="MVChangePass">
        <asp:View runat="server" ID="VChangingPass">
    <table>
        <tr>
            <td>Enter your old password</td>
            <td><asp:TextBox runat="server" ID="TxtOldPass" TextMode="Password"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator runat="server" ID ="RfvOldPass" Text="*" 
                    ControlToValidate="TxtOldPass" Enabled="True" 
                    ErrorMessage="Old password not entered" ValidationGroup="VGChangePass" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ID="RevOldPass" Text="*" 
                    ControlToValidate="TxtOldPass" ErrorMessage="Old password is invalid" 
                    ValidationExpression="^(?=.*[^a-zA-Z])(?=.*[a-z])(?=.*[A-Z])\S{8,}$" 
                    ValidationGroup="VGChangePass" ForeColor="Red"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Enter new password</td>
            <td><asp:TextBox runat="server" ID="TxtNewPass" TextMode="Password"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator runat="server" ID ="RfvNewPass" Text="*" 
                    ControlToValidate="TxtNewPass" Enabled="True" 
                    ErrorMessage="New password not entered" ValidationGroup="VGChangePass" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ID="RevNewPass" Text="*" 
                    ControlToValidate="TxtNewPass" 
                    ErrorMessage="New password must be without white-space characters, minimum length of 8, with one non-alpha character, one upper case character and one lower case character" 
                    ValidationExpression="^(?=.*[^a-zA-Z])(?=.*[a-z])(?=.*[A-Z])\S{8,}$" 
                    ValidationGroup="VGChangePass" ForeColor="Red"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Confirm password</td>
            <td><asp:TextBox runat="server" ID="TxtConfirmPass" TextMode="Password"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator runat="server" ID ="RfvConfirmPass" Text="*" 
                    ControlToValidate="TxtConfirmPass" Enabled="True" 
                    ErrorMessage="Confirm password not entered" ValidationGroup="VGChangePass" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator runat="server" ID="CvNewPass" Text="*" 
                    ControlToCompare="TxtNewPass" ControlToValidate="TxtConfirmPass" 
                    ErrorMessage="New password and confirm password must be the same" 
                    ValidationGroup="VGChangePassword" ForeColor="Red"></asp:CompareValidator></td>
        </tr>
        <tr>
            <td><asp:Button runat="server" ID="BtnChange" Text="Change Password" ValidationGroup="VGChangePass" onclick="BtnChangeClick"/></td>
            <td><asp:Button runat="server" ID="BtnCancel" Text ="Cancel" 
                    CausesValidation="False" 
                    onclick="BtnCancelClick"/></td>
            <td></td>
        </tr>
    </table>
    <asp:Label runat="server" ID="LblMessage" Text="" ForeColor="Red"></asp:Label>
    <asp:ValidationSummary runat="server" ID="VSChangePass" 
        ValidationGroup = "VGChangePass" ForeColor="Red"/>
    </asp:View>
    <asp:View runat="server" ID="VSuccess">
            <table>
            <tr><td>Password change success</td></tr>
            <tr><td><asp:Button runat="server" ID="BtnReturn" Text="Return to start page" 
                    onclick="BtnReturnClick"/></td></tr>
        </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
