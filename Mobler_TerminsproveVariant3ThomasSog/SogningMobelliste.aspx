<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SogningMobelliste.aspx.cs" Inherits="SogningMobelliste" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_SideNavn" Runat="Server">
     <asp:Label ID="Label_SideNavn" runat="server" Text="Møbler"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
    <asp:PlaceHolder ID="PlaceHolder_SogningResultat" Visible="true" runat="server">
        <asp:Repeater ID="Repeater_Mobelliste" ItemType="_Produkt" runat="server">
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink_EtMobelMedBillede" NavigateUrl='<%#"Moblet.aspx?id=" + Item.id %>' runat="server">
                    <asp:Panel ID="Panel_EtMobelMedBillede" CssClass="border_hovereffect" runat="server">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Image ID="Image_MobelBillede"
                                    ImageUrl='<%# "~/Images/" + Item._Serie.serie_navn +"/" + (Item._Billede.billede_sti_120_90.ToString().Length > 0 ? Item._Billede.billede_sti_120_90.ToString() : "not-available.gif")%>'
                                    AlternateText="<%# Item._Billede.billede_navn %>" runat="server" />
                            </div>
                            <div class="col-md-6">
                                <h3>
                                    <asp:Label ID="Label_MobelNavn" runat="server" Text="<%# Item.navn %>"></asp:Label>
                                </h3>
                                <!-- Hvis et emne i listen indeholder mere end 187 tegn, 
                                        så viser vi kun 183 tegn,
                                        tilføjer et mellemrum og tre punktummer-->
                                <asp:Label ID="Label_MobelBeskrivelse" runat="server"
                                    Text='<%# Item.beskrivelse.ToString().Length >=187 ? Item.beskrivelse.ToString().Substring(0,183) + " ..." : Item.beskrivelse.ToString()%>'>
                                </asp:Label>
                            </div>
                        </div>
                    </asp:Panel>
                </asp:HyperLink>
            </ItemTemplate>
        </asp:Repeater>
    </asp:PlaceHolder>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

