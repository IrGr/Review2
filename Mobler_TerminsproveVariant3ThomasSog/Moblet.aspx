<%@ Page Title="CMK Møbler" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Moblet.aspx.cs" Inherits="Moblet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>
        <asp:Literal ID="LiteralPageTitle" runat="server"></asp:Literal>
    </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_SideNavn" runat="Server">
    <asp:Repeater ID="Repeater_SideNavn" ItemType="_Produkt" runat="server">
        <ItemTemplate>
            <asp:Label ID="Label_SideNavn" runat="server" Text='<%#Item.navn %>'></asp:Label>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Repeater ID="Repeater_EtMobel" ItemType="FuldProdukt" runat="server">
        <ItemTemplate>
            <!--Carousel-->
            <div id="myCarousel" class="carousel slide" data-ride="carousel">
                <!-- Wrapper for slides -->
                <div class="carousel-inner" role="listbox">
                    <div class="item active">
                        <img src='<%# "Images/"+ Item._Serie.serie_navn+ "/" + Item._Billede.billede_sti_300_225 %>' alt="Chania">
                    </div>
                    <asp:Repeater ID="Repeater_Carousel" DataSource="<%# Item.Billeder %>" ItemType="_Billede" runat="server">
                        <ItemTemplate>
                            <div class="item">
                                <img src="<%# "Images/" + ((FuldProdukt)((RepeaterItem)Container.Parent.Parent).DataItem)._Serie.serie_navn  + "/" + Item.billede_sti_300_225 %>" alt="<%# Item.billede_navn %>">
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                    <!-- Left and right controls -->
                    <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>

                <div class="moblet">
                    <h1><%# Item.navn %></h1>
                    <asp:Label ID="Label_Beskrivelse" runat="server" Text="<%# Item.beskrivelse %>"></asp:Label>
                    <h1 id="Detaljer_Overskrift" runat="server">Detaljer</h1>
                    <ul>
                        <li>Designer: <%# Item.designer %></li>
                        <li>Design år: <%# Item.design_aar %></li>
                        <li>Varenr: <%# Item.varenr %></li>
                        <li>Pris: <%# Item.pris %></li>
                    </ul>
                    <h1 id="Varianter_Overskrift" runat="server">Varianter</h1>
                    <asp:Repeater ID="Repeater_VarianterBilleder" DataSource="<%# Item.Billeder %>" ItemType="_Billede" runat="server">
                        <ItemTemplate>

                            <a data-lightbox="roadtrip"
                                href='<%# "~/Images/" + ((FuldProdukt)((RepeaterItem)Container.Parent.Parent).DataItem)._Serie.serie_navn  + "/" + Item.billede_sti_300_225.ToString() %>'
                                runat="server">
                                <asp:Image ID="Image_VarianterBillede"
                                    ImageUrl='<%# "~/Images/" + ((FuldProdukt)((RepeaterItem)Container.Parent.Parent).DataItem)._Serie.serie_navn  + "/" + (Item.billede_sti_120_90.ToString().Length > 0 ? Item.billede_sti_120_90.ToString() : "not-available.gif") %>'
                                    AlternateText="<%# Item.billede_navn %>" Width="50" Height="50" runat="server" />
                            </a>


                        </ItemTemplate>
                    </asp:Repeater>
                </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script>
        $('#carousel-example-generic').carousel({
            interval: 5000
        });</script>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <div class="bottom">
        <ul class="breadcrumb">
            <li><a href="Default.aspx">Forside</a></li>
            <li>
                <asp:HyperLink ID="HyperLink_BreadCrumb_Serie" runat="server"></asp:HyperLink></li>
            <li class="active">
                <asp:Literal ID="Literal_BreadCrumb_MobelTitle" runat="server"></asp:Literal></li>
        </ul>
    </div>
</asp:Content>
