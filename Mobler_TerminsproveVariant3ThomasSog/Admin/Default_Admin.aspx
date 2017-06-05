<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="Default_Admin.aspx.cs" Inherits="Admin_Default_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <strong><i class="glyphicon glyphicon-dashboard"></i>Mit Dashboard</strong>
        <hr />
        <div class="row">
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4>Det nyeste produkt</h4>
                    </div>
                    <div class="panel-body">
                        <!--PlaceHolder_Produktstart -->
                        <asp:Repeater ID="Repeater_ForsFilm" ItemType="_Produkt" runat="server">
                            <ItemTemplate>
                                <div class="row">
                                    <div class="col-md-4 col-xs-4">
                                        <asp:Image ID="Image_Prod" CssClass="img-responsive" 
                                            ImageUrl='<%# Item._Billede !=null ? "../Images/"+ Item._Serie.serie_navn +"/"+ Item._Billede.billede_sti_120_90  :"~/Images/not-available.gif" %>' runat="server" />
                                    </div>
                                    <div class="col-md-8 col-xs-8">
                                        <h1 runat="server">
                                            <p>
                                                <asp:Label ID="Label_ProdNavn" runat="server" ForeColor="Black" Text='<%# "Navn: "+ Item.navn %>'></asp:Label>
                                            </p>
                                            <p>
                                                <asp:Label ID="Label_ProdVarenr" runat="server" ForeColor="Black" Text='<%# "Varenr.: " + Item.varenr %>'></asp:Label>
                                            </p>
                                            <p>
                                                <asp:Label ID="Label_ProdPris" runat="server" ForeColor="Black" Text='<%# "Pris: " + Item.pris %>'></asp:Label>
                                            </p>
                                            
                                        </h1>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>

            <!--/col-->
            <div class="col-md-6">
                <asp:PlaceHolder ID="PlaceHolder_NyhedTab" runat="server">
                    <div class="table-responsive">
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>Nyhed</th>
                                    <th>Dato</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="Repeater_NyhedTab" ItemType="_Nyhed" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Item.nyhed_id%></td>
                                            <td><%# Item.overskrift %></td>
                                            <td><%# Item.dato.ToLongDateString() %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </asp:PlaceHolder>
            </div>
            <!--/col-span-6-->





        </div>
    </div>



</asp:Content>

