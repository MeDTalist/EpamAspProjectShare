<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Library.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EpamAspProject.Views.Pages.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHView" runat="server">
    <div><asp:GridView runat="server" ID="GVLibrary" AllowPaging="True" 
        OnPageIndexChanging="GVLibraryPageIndexChange"
        OnSelectedIndexChanging="GVLibrarySelectedIndexChanged">
    <SelectedRowStyle BackColor="#FFFF66" />
    </asp:GridView></div>
    <table>
        <tr>
            <td colspan="2">Find</td>
            <td><asp:Label ID="LBLAction" runat="server" Text="Action"></asp:Label></td>
            <td colspan="2"><asp:Label runat="server" ID="LblQuastion" Text="Are you sure delete selected file?" Visible="False" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td>Find by:</td>
            <td><asp:DropDownList runat="server" ID ="DDLFiterFor" 
                    onselectedindexchanged="DDLFiterFor_SelectedIndexChanged"></asp:DropDownList></td>
            <td><asp:Button runat="server" ID="BTNView" Text = "View" Visible="False" OnClick="BTNViewClick" CausesValidation="False"/></td>
            <td><asp:Button runat="server" ID="BtnYes" Text="Yes" CausesValidation="False" Visible="False" OnClick="BtnYesClick"/></td>
            <td><asp:Button runat="server" ID="BtnNo" Text="No" CausesValidation="False" Visible="False"/></td>
        </tr>
        <tr>
            <td>Contains</td>
            <td><asp:TextBox ID="TxtContains" runat="server" Text="" ></asp:TextBox><asp:RequiredFieldValidator runat="server" ID="RfvContains" Text="*" ValidationGroup="VGFind" ForeColor="Red" ControlToValidate="TxtContains" Display="Static" ErrorMessage="Contains not entered"></asp:RequiredFieldValidator></td>
            <td><asp:Button runat="server" ID = "BtnDownload" Text ="Download" Visible="False" CausesValidation="False" OnClick="DownloadClick"/></td>
        </tr>
        <tr>
            <td><asp:Button runat="server" ID="BtnAll" Text="Show all" CausesValidation="False" OnClick="BtnAllClick"/></td>
            <td><asp:Button runat="server" ID="BTNFind" Text="Find" onclick="BTNFind_Click" CausesValidation="True" ValidationGroup="VGFind"/></td>
            <td><asp:Button runat="server" ID = "BTNAdd" Text="Add" Visible="False" 
                    onclick="BTNAdd_Click"/></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td><asp:Button runat="server" ID = "BTNDelete" Text = "Delete" Visible = "False" 
                    onclick="BTNDelete_Click"/></td>
        </tr>
    </table>
    
    <asp:Label runat="server" ID="LblMessage" Text="" ForeColor="Red"></asp:Label><br/>
    <asp:ValidationSummary runat="server" ID="VSFind" ValidationGroup="VGFind" ForeColor="Red"/>

</asp:Content>
