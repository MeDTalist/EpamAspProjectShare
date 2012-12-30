<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Library.Master" AutoEventWireup="true" CodeBehind="ViewRecord.aspx.cs" Inherits="EpamAspProject.Views.Pages.ViewRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            width: 130px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHView" runat="server">
    <table style="top: 0px">
        <tr>
            <td style="vertical-align: top">
                <img runat="server" ID="ImgImage" />
            </td>
            <td style="vertical-align: top">
                <table>
                    <tr>
                        <td class="style3">ID Record</td>
                        <td><asp:Label runat="server" ID="LblIdRecord"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="style3">Name</td>
                        <td><asp:Label runat="server" ID="LblName"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="style3">Author</td>
                        <td><asp:Label runat="server" ID="LblAuthor"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="style3">Year</td>
                        <td><asp:Label runat="server" ID="LblYear"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="style3">Upload by</td>
                        <td><asp:Label runat="server" ID="LblUploadBy"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="style3">Upload date</td>
                        <td><asp:Label runat="server" ID="LblUploadDate"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="style3">Type</td>
                        <td><asp:Label runat="server" ID="LblType"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="style3">Format</td>
                        <td><asp:Label runat="server" ID="LblFormat"></asp:Label></td>
                    </tr>
                    </table>
                    <asp:MultiView runat="server" ID="MVType">
                        <asp:View runat="server" ID="VMusic">
                            <table>
                <tr>
                    <td class="style3">Play time</td> 
                    <td><asp:Label runat="server" ID="LblPlayTime2" Text="" ></asp:Label></td>
                </tr>
	            <tr>
	                <td class="style3">Bit rate(kbps)</td>
                    <td><asp:Label runat="server" ID="LblBitRate" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td class="style3">Album</td>
                    <td><asp:Label runat="server" ID="LblAlbum" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td class="style3">Style</td>
                    <td><asp:Label runat="server" ID="LblStyle" Text=""></asp:Label></td>
                </tr>
            </table>
                        </asp:View>
                        <asp:View runat="server" ID="VMovie">
                            <table>
                <tr>
                    <td class="style3">Play time</td> 
                    <td><asp:Label runat="server" ID="LblPlayTime" Text="" ></asp:Label></td>
                </tr>
	            <tr>
	                <td class="style3">Genre</td>
                    <td><asp:Label runat="server" ID="LblGenre" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td class="style3">Quality</td>
                    <td><asp:Label runat="server" ID="LblQuality" Text=""></asp:Label></td>
                </tr>
            </table>
                        </asp:View>
                        <asp:View runat="server" ID="VBook">
                            <table>
                <tr>
                    <td class="style3">Publishing House</td> 
                    <td><asp:Label runat="server" ID="LblPublishingHouse" Text="" ></asp:Label></td>
                </tr>
	            <tr>
	                <td class="style3">Pages</td>
                    <td><asp:Label runat="server" ID="LblPages" Text=""></asp:Label></td>
                </tr>
               
            </table>
                        </asp:View>
                    </asp:MultiView>
                    <table>
                     <tr>
                    <td class="style3"><asp:Button runat="server" ID="BtnReturn" Text="Return to main" 
                            CausesValidation="False" OnClick="BtnReturnClick"/></td>
                    <td><asp:Button runat="server" ID="BtnDownload" Text="Download" CausesValidation="False" OnClick="BtnDownloadClick"/></td>
                </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
