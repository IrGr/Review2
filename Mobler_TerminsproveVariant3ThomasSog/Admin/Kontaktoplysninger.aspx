<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="Kontaktoplysninger.aspx.cs" Inherits="Admin_Kontaktoplysninger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <asp:PlaceHolder ID="PlaceHolder_Kontaktoplysninger" runat="server">
                <br />
                <div class="row col-md-6 custyle">
                    <div class="table-responsive">
                        <table class="table table-striped custab table-hover">
                            <thead>
                                <tr>
                                    <th>Addresse</th>
                                    <th>Postnr</th>
                                    <th>Byen</th>
                                    <th>Email</th>
                                    <th>Telefon</th>
                                    <th class="text-center">Action</th>
                                </tr>
                            </thead>

                            <asp:Repeater ID="Repeater_Kontaktoplysninger" ItemType="_Kontaktoplysninger" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td class="topalign"><%# Item.adresse %></td>
                                        <td class="topalign"><%# Item.postnr %></td>
                                        <td class="topalign"><%# Item.byen %></td>
                                        <td class="topalign"><%# Item.email %></td>
                                        <td class="topalign"><%# Item.telefon %></td>
                                        <td class="text-center topalign">
                                            <asp:LinkButton ID="LinkButton_Ret"
                                                class='btn btn-info btn-xs'
                                                href='<%#"RetKontaktoplysninger.aspx?id=" + Item.id %>'
                                                runat="server"> 
                                            <span class="glyphicon glyphicon-edit"></span> Ret</asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </div>
            </asp:PlaceHolder>


            <asp:PlaceHolder ID="PlaceHolder_Aabningstid" runat="server">
                <br />
                <div class="row col-md-6 custyle">
                    <div class="table-responsive">
                        <table class="table table-striped custab table-hover">
                            <thead>
                                <tr>
                                    <th>Dag</th>
                                    <th>Åben</th>
                                    <th>Luk</th>
                                    <th class="text-center">Action</th>
                                </tr>
                            </thead>
                            <asp:Repeater ID="Repeater_Aabningstid" ItemType="_Aabningstid" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td class="topalign"><%# Item.dag %></td>
                                        <td class="topalign"><%# Item.aaben%></td>
                                        <td class="topalign"><%# Item.luk%></td>
                                        <td class="text-center topalign">
                                            <asp:LinkButton ID="LinkButton_Ret"
                                                class='btn btn-info btn-xs'
                                                href='<%#"RetAabningstid.aspx?id=" + Item.id %>'
                                                runat="server"> 
                                            <span class="glyphicon glyphicon-edit"></span>Ret</asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </div>
            </asp:PlaceHolder>
        </div>
    </div>
</asp:Content>

