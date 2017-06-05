<%@ Page Title="Forsiden: CMK Møbler" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content_SideNavn" ContentPlaceHolderID="ContentPlaceHolder_SideNavn" runat="server">
     <asp:Label ID="Label_SideNavn" runat="server" Text="Forside"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Repeater ID="Repeater_Nyheder" ItemType="_Nyhed" runat="server">
        <ItemTemplate>
            <h1><%#Item.overskrift %></h1>
            <p>af <asp:Label ID="Label_Forfatter" CssClass="forfatter_color" runat="server" Text="<%#Item._Forfatter.forfatter_name %>"> </asp:Label></p>
            <asp:LinkButton ID="LinkButton_Frameld" runat="server"><span class="glyphicon glyphicon-time"></span><%# " " + Item.dato.ToString("dd.MMMM yyyy") %> </asp:LinkButton>
            <hr />
            <article><%# Item.tekst %> </article>
            <hr />
        </ItemTemplate>
    </asp:Repeater>
   

</asp:Content>

