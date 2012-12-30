<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLogin.ascx.cs" Inherits="EpamAspProject.Views.UC.UCLogin" %>
<div align="center" style="width: 320px; height: 130px; padding: 0px; margin: 0px">
    <asp:MultiView runat="server" ID="MVLogin">
        <asp:View runat="server" ID="VNoLogin">
            <table >
                <tr>
                    <th>Login</th>
                    <th><asp:TextBox runat="server" ID="TXTLogin"></asp:TextBox></th>
                    <th><asp:RequiredFieldValidator runat="server" ID="RFVLogin" 
                            ControlToValidate="TXTLogin" Text="*" ValidationGroup="VGLogin" 
                            ErrorMessage="Login is empty" ForeColor="Red"></asp:RequiredFieldValidator></th>
                </tr>
                <tr>
                    <th>Password</th>
                    <th><asp:TextBox runat="server" ID="TXTPassword" TextMode="Password"></asp:TextBox></th>
                    <th><asp:RequiredFieldValidator runat="server" ID="RFVPassword" 
                            ControlToValidate="TXTPassword" Text="*" ValidationGroup="VGLogin" 
                            ErrorMessage="Password is empty" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="REVPassword" runat="server" 
                            ControlToValidate="TXTPassword" ErrorMessage="Password is not valid" 
                            ValidationExpression="^(?=.*[^a-zA-Z])(?=.*[a-z])(?=.*[A-Z])\S{8,}$" 
                            ValidationGroup="VGLogin" ForeColor="Red">*</asp:RegularExpressionValidator>
                    </th>
                </tr>
                <tr >
                    <th>
                        <asp:LinkButton ID="LBRegistration" runat="server" Text="Registration" 
                            CausesValidation="False" onclick="LBRegistration_Click"></asp:LinkButton></th>
                    <th>
                        <asp:Button runat="server" ID="BTNLogin" ValidationGroup="VGLogin" 
                            Text="Login" onclick="BTNLogin_Click"/></th>
                    <th>&nbsp;</th>
                </tr>
                <tr>
                    <th><asp:LinkButton runat="server" ID="LBFgotPassword" Text="Fogot a password?" 
                            CausesValidation="False" onclick="LBFgotPassword_Click"></asp:LinkButton></th>
                    <th><asp:Label runat="server" ID="LblMessage" ForeColor="Red"></asp:Label></th>
                </tr>
            </table>
        </asp:View>

        <asp:View runat="server" ID="VLoginIsSuccess">
            <br/>
            <p style="padding: 0px; margin: 0px">Hello, <asp:Label runat="server" ID="LBLUserName"></asp:Label></p>
            <br/>
            <p style="padding: 0px; margin: 0px"><asp:HyperLink runat="server" ID="HlChangePass" Text="Change password" NavigateUrl="~/Views/Pages/ChangePassword.aspx"></asp:HyperLink></p>
            <br/>
            <p style="padding: 0px; margin: 0px"><asp:LinkButton runat="server" ID="LBExit" Text="Exit" CausesValidation="False" 
                    onclick="LBExit_Click"></asp:LinkButton></p>
            <br/>
        </asp:View>
        <asp:View runat="server" ID="VExit">
            <table >
            <tr><td colspan="2">Are yuo sure want to exit?</td></tr>
            <tr>
                <td><asp:Button runat="server" ID="BTNYes" Text="Yes" onclick="BTNYes_Click"/></td>
                <td><asp:Button runat="server" ID="BTNNo" Text="No" onclick="BTNNo_Click"/></td>
            </tr>
            </table>
        </asp:View>

        <asp:View runat="server" ID="VDisable">
            <img src="/Images/Lock.jpg" alt=""/>
        </asp:View>
    </asp:MultiView>
</div>
</>