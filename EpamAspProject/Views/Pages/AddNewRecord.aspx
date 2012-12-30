<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Library.Master" AutoEventWireup="true" CodeBehind="AddNewRecord.aspx.cs" Inherits="EpamAspProject.Views.Pages.AddNewRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 105px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHView" runat="server">
    <asp:MultiView runat="server" ID="MVNewRecord">
        <asp:View runat="server" ID="VChooseType">
            Please select type of record to add<br/>
            <asp:RadioButton ID="RBMovie" runat="server" Text="Movie" Checked="True" GroupName="GNType"/><br/>
            <asp:RadioButton ID="RBMusic" runat="server" Text="Music" GroupName="GNType" Checked="False"/><br/>
            <asp:RadioButton ID="RBBook" runat="server" Text="Book" GroupName="GNType" Checked="False"/><br/>
            <asp:Button runat="server" ID="BtnSelect" Text="Select" CausesValidation="False" OnClick="BtnSelectClick"/>  
            &nbsp;&nbsp;  
            <asp:Button runat="server" ID="BtnCancel" Text="Cancel" CausesValidation="False" OnClick="BtnCancelClick"/>
        </asp:View>
        <asp:View runat="server" ID="VAdd">
            <table>
                <tr>
                    <td class="style2">Name</td> 
                    <td><asp:TextBox runat="server" ID="TxtName" Text="" ></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator runat="server" ID="RfvName" Text="*" ValidationGroup="VGAddNew" ForeColor="Red" ControlToValidate="TxtName" Display="Static" ErrorMessage="Name not entered"></asp:RequiredFieldValidator></td>  
                </tr>
	            <tr>
	                <td class="style2">Author</td>
                    <td><asp:TextBox runat="server" ID="TxtAuthor" Text=""></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator runat="server" ID="RfvAuthor" Text="*" ValidationGroup="VGAddNew" ForeColor="Red" ControlToValidate="TxtAuthor" Display="Static" ErrorMessage="Author not entered"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="style2">Year</td>
                    <td><asp:TextBox runat="server" ID="TxtYear" Text=""></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator runat="server" ID="RfvYear" Text="*" ValidationGroup="VGAddNew" ForeColor="Red" ControlToValidate="TxtYear" Display="Static" ErrorMessage="Year not entered"></asp:RequiredFieldValidator>
                        <asp:RangeValidator runat="server" ID="RVYear" Text="*" ValidationGroup="VGAddNew" ForeColor="Red" ControlToValidate="TxtYear" Display="Static" ErrorMessage="Incorect year" Type="Integer" MinimumValue="1900" MaximumValue="2013"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">Select image:</td>
                    <td><asp:FileUpload runat="server" ID="FUImage"/></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="style2">Select file: </td>
                    <td><asp:FileUpload runat="server" ID="FUAddNew" /></td>
                    <td></td>
                </tr>
            </table>
            <asp:MultiView runat="server" ID="MVTypeRecord">
                <asp:View runat="server" ID="VMovie">
                    <table>
                <tr>
                    <td class="style2">Play time</td> 
                    <td><asp:TextBox runat="server" ID="TxtPlayTime" Text="" ></asp:TextBox></td>
                    <td>
                        <asp:RegularExpressionValidator ID="RevPlayTime" runat="server" ErrorMessage="Play time must be in HH:MM:SS format" Text="*" ValidationGroup="VGAddNew" ForeColor="Red" ControlToValidate="TxtPlayTime" Display="Static" ValidationExpression="^([0-1]\d|2[0-3])(:[0-5]\d){2}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
	            <tr>
	                <td class="style2">Genre</td>
                    <td><asp:TextBox runat="server" ID="TxtGenre" Text=""></asp:TextBox></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="style2">Quality</td>
                    <td><asp:TextBox runat="server" ID="TxtQuality" Text=""></asp:TextBox></td>
                    <td></td>
                </tr>
            </table>
                </asp:View>
                <asp:View runat="server" ID="VMusic">
                    <table>
                <tr>
                    <td class="style2">Play time</td> 
                    <td><asp:TextBox runat="server" ID="TxtPlayTime2" Text="" ></asp:TextBox></td>
                    <td>
                        <asp:RegularExpressionValidator ID="RevPlayTime2" runat="server" ErrorMessage="Play time must be in MM:SS format" Text="*" ValidationGroup="VGAddNew" ForeColor="Red" ControlToValidate="TxtPlayTime2" Display="Static" ValidationExpression="^([0-5]\d)(:[0-5]\d)$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
	            <tr>
	                <td class="style2">Bit rate(kbps)</td>
                    <td><asp:TextBox runat="server" ID="TxtBitRate" Text=""></asp:TextBox></td>
                    <td>
                        <asp:RegularExpressionValidator ID="RevBitRate" runat="server" ErrorMessage="Bit rate is invalid" Text="*" ValidationGroup="VGAddNew" ForeColor="Red" ControlToValidate="TxtBitRate" Display="Static" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td class="style2">Album</td>
                    <td><asp:TextBox runat="server" ID="TxtAlbum" Text=""></asp:TextBox></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="style2">Style</td>
                    <td><asp:TextBox runat="server" ID="TxtStyle" Text=""></asp:TextBox></td>
                    <td></td>
                </tr>
            </table>
                </asp:View>
                <asp:View runat="server" ID="VBook">
                    <table>
                <tr>
                    <td class="style2">Publishing House</td> 
                    <td><asp:TextBox runat="server" ID="TxtPublishingHouse" Text="" ></asp:TextBox></td>
                </tr>
	            <tr>
	                <td class="style2">Pages</td>
                    <td><asp:TextBox runat="server" ID="TxtPages" Text=""></asp:TextBox></td>
                    <td>
                        <asp:RegularExpressionValidator ID="RevPages" runat="server" ErrorMessage="Pages is invalid" Text="*" ValidationGroup="VGAddNew" ForeColor="Red" ControlToValidate="TxtPages" Display="Static" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator></td>
                </tr>
            </table>
                </asp:View>
            </asp:MultiView>
        <asp:Button runat="server" ID="BtnAdd" Text="Add" ValidationGroup="VGAddNew" CausesValidation="True" OnClick="BtnAddClick"/>
        &nbsp;
        &nbsp;
        <asp:HyperLink runat="server" ID="HLReturnToMain" Text="Return to main" NavigateUrl="~/Views/Pages/Default.aspx"/>
        <br/>
            <asp:Label runat="server" ID="LblMessage" Text="" ForeColor="Red"></asp:Label>
            <br/>
            <asp:ValidationSummary ID="VSAddNew" runat="server" ValidationGroup="VGAddNew" ForeColor="Red" />
        </asp:View>
        <asp:View runat="server" ID="VSuccess">
            Record successfuly added
            <br/>
            <asp:Button runat="server" ID="BtnReturnToMain" Text="Return to main" CausesValidation="False" OnClick="ReturnToMainClick"/>
        </asp:View>
    </asp:MultiView>
</asp:Content>
