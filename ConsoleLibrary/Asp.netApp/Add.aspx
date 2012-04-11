<%@ Page Title="Add Contact" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="Asp.netApp.Add" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 align = "center">
         Drumbi Add Account
    </h2 >
    <h4 align = "center">
        <asp:Table ID="tableAdd" runat="server" BorderWidth = "2px" CellPadding = "2" CellSpacing = "4"
         GridLines="Both" >
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                <asp:Label ID="Label1" runat="server" Text="FirstName"></asp:Label>
                
</asp:TableCell>
                <asp:TableCell runat="server">
                 <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                
</asp:TableCell>
            </asp:TableRow>


            
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                <asp:Label ID="Label2" runat="server" Text="MiddleName"></asp:Label>
                </asp:TableCell>
                <asp:TableCell runat="server">
                <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow ID="TableRow2" runat="server">
                <asp:TableCell ID="TableCell1" runat="server">
                <asp:Label ID="Label3" runat="server" Text="LastName"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="TableCell2" runat="server">
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow3" runat="server">
                <asp:TableCell ID="TableCell3" runat="server">
                <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="TableCell4" runat="server">
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow4" runat="server">
                <asp:TableCell ID="TableCell5" runat="server">
                <asp:Label ID="Label5" runat="server" Text="City"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="TableCell6" runat="server">
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow1" runat="server">
                <asp:TableCell ID="TableCell7" runat="server">
                <asp:Label ID="Label6" runat="server" Text="Province"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="TableCell8" runat="server">
                <asp:TextBox ID="txtProvince" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow ID="TableRow5" runat="server">
                <asp:TableCell ID="TableCell9" runat="server">
                <asp:Label ID="Label7" runat="server" Text="ZipCode"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="TableCell10" runat="server">
                <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow6" runat="server">
                <asp:TableCell ID="TableCell11" runat="server">
                <asp:Label ID="Label8" runat="server" Text="Telephone Number"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="TableCell12" runat="server">
                <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow7" runat="server">
                <asp:TableCell ID="TableCell13" runat="server">
                <asp:Label ID="Label9" runat="server" Text="Mobile Number"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="TableCell14" runat="server">
                <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow8" runat="server">
                <asp:TableCell ID="TableCell15" runat="server">
                <asp:Label ID="Label10" runat="server" Text="Email"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="TableCell16" runat="server">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            
            
        </asp:Table>
   </h4 >
   <h2 align = "center">
       <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" 
           Width="60px"  />
   </h2>
</asp:Content>
