<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="MoblerAdmin.aspx.cs" Inherits="Admin_MoblerAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <!--PlaceHolder_ProdukterList start -->
                <asp:PlaceHolder ID="PlaceHolder_ProdukterList" runat="server">
                    <div class="row col-md-12 custyle">
                        <div class="table-responsive">
                            <table id="ProdukterTabel" class="table table-striped custab table-hover">
                                <thead>
                                    <asp:LinkButton ID="LinkButton_AddProdukt" OnClick="LinkButton_AddProdukt_Click"
                                        class="btn btn-xs pull-right" ForeColor="White"
                                        runat="server"><b>+</b>Tiljøj nyt produkt</asp:LinkButton>
                                    <tr>
                                        <th>ID</th>
                                        <th>Navn</th>
                                        <th>Varenr.</th>
                                        <th>Serie</th>
                                        <th>Pris</th>
                                        <th>Designer</th>
                                        <th>Designer år</th>
                                        <th>Beskrivelse</th>
                                        <th>Billeder</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                <asp:PlaceHolder ID="PlaceHolder_ProdukterTabel" runat="server">
                                    <asp:Repeater ID="Repeater_ProdukterTabel" ItemType="_Produkt"
                                        OnItemCommand="Repeater_ProdukterTabel_ItemCommand"
                                        runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="topalign"><%# Item.id %></td>
                                                <td class="topalign"><%# Item.navn %></td>
                                                
                                                <td>
                                                    <%# Item.varenr %>
                                                </td>
                                                <td>
                                                    <%# Item._Serie.serie_navn%>
                                                </td>
                                                <td class="topalign">
                                                    <%# Item.pris %>
                                                </td>
                                                <td class="topalign">
                                                    <%# Item.designer %>
                                                </td>
                                                <td class="topalign">
                                                    <%# Item.design_aar %>
                                                </td>
                                                <td class="topalign">
                                                    <%# Item.beskrivelse.ToString().Length >= 450 ? Item.beskrivelse.ToString().Substring(0,450) + "..." : Item.beskrivelse.ToString() %>
                                                </td>
                                                <td class="topalign">
                                                   <%-- <asp:Image ID="Image_Billede" Width="50" Height="50"
                                                         ImageUrl='<%# Item._Billede.billede_sti_120_90.Length > 0 ? "../Images/" +Item._Serie.serie_navn +"/"+ Item._Billede.billede_sti_120_90 :"~/Images/not-available.gif" %>' runat="server" />--%>
                                                 <asp:Image ID="Image_Billede" Width="50" Height="50"
                                                         ImageUrl='<%# Item._Billede !=null ? "../Images/" +Item._Serie.serie_navn +"/"+ Item._Billede.billede_sti_120_90 :"~/Images/not-available.gif" %>' runat="server" />
                                                </td>

                                                <td class="text-center topalign col-xs-2">
                                                    <asp:HyperLink ID="HyperLink_Ret" CssClass=" btn btn-info btn-xs"
                                                        NavigateUrl='<%# "~/Admin/RetProdukt.aspx?id=" + Item.id %>'
                                                        runat="server"><span class="glyphicon glyphicon-edit"></span>Ret</asp:HyperLink>
                                                    <asp:LinkButton ID="LinkButton_Slet" class="btn btn-danger btn-xs" runat="server"
                                                        CommandArgument='<%# Item.id %>' CommandName="Slet"
                                                        OnClientClick="return confirm ('Er du sikker??');">
                                                            <span class="glyphicon glyphicon-remove"></span>Slet</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </asp:PlaceHolder>
                            </table>
                        </div>
                        <%--/.table-responsive--%>
                    </div>
                    <%--/.row col-md-12 custyle--%>
                </asp:PlaceHolder>
            </div>
        </div>
    </div>

</asp:Content>

