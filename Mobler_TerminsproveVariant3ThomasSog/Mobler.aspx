<%@ Page Title="Møbler: CMK Møbler" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Mobler.aspx.cs" Inherits="Mobler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_SideNavn" runat="Server">
    <asp:Label ID="Label_SideNavn" runat="server" Text="Møbler"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel_SogBesked" Visible="false" runat="server">
        <p>
            <asp:Label runat="server" Text=" Der er desværre ikke nogen emner der matcherdine kriterier."></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label_SogBesked" runat="server" Text=" Vi anbefaler du udvikler din søgning og prøver igen."></asp:Label>
        </p>
    </asp:Panel>

    <asp:Panel ID="Panel_VarenrSog" CssClass="sogefelter_varnr" runat="server">
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="Label_Varenr" runat="server" Text="Vare nr:"></asp:Label>
            </div>
            <div class="col-md-5">
                <asp:TextBox ID="TextBox_Varenr" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Varenr" runat="server"
                    ErrorMessage="Feltet må ikke være tomt!!"
                    Text="Må ikke være tom!! * "
                    ControlToValidate="TextBox_Varenr"
                    Display="Dynamic"
                    ForeColor="Red"
                    Font-Size="X-Small"
                    ValidationGroup="Varenr">
                </asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <asp:Button ID="Button_SogVarenr" ValidationGroup="Varenr" runat="server" OnClick="Button_SogVarenr_Click" Text="Søg" />
            </div>
        </div>
    </asp:Panel>
    <asp:PlaceHolder ID="PlaceHolder_AvansSog" runat="server">
        <asp:Panel ID="Panel_AvansSog" CssClass="sogefelter" runat="server">
            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="Label_Møbelserie" runat="server" Text="Møbelserie"></asp:Label>
                </div>
                <div class="col-md-9">
                    <asp:CheckBoxList ID="CheckBoxList_Serie"
                        CellPadding="5" CellSpacing="5"
                        RepeatColumns="2"
                        RepeatDirection="Vertical"
                        RepeatLayout="Flow"
                        TextAlign="Left"
                        CssClass="checkboxstyle" runat="server">
                        <%--AutoPostBack="True"--%>
                    </asp:CheckBoxList>

                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel_Designer" CssClass="sogefelter" runat="server">
            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="Label_Designer" runat="server" Text="Designer"></asp:Label>
                </div>
                <div class="col-md-9">
                    <asp:DropDownList ID="DropDownList_Designer" runat="server"></asp:DropDownList>
                </div>
            </div>

        </asp:Panel>

        <asp:Panel ID="Panel_DesignAar" CssClass="sogefelter" runat="server">
            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="Label_DesignAar" runat="server" Text="Design år"></asp:Label>
                </div>
                <div class="col-md-5">
                    <asp:Label ID="Label_MinDesignAar" runat="server" Text="Min:"></asp:Label>
                    <asp:TextBox ID="TextBox_MinDesignAar" runat="server"></asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator_MinAar" runat="server"
                            ValidationGroup="Sogning"
                            ErrorMessage="Indtast venligst et år. F.eks. 2005"
                            ControlToValidate="TextBox_MinDesignAar"
                            Display="Dynamic"
                            ForeColor="Red"
                            Height="5"
                            ValidationExpression="^[0-9]+$">
                        </asp:RegularExpressionValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label_MaxDesignAar" runat="server" Text="Max:"></asp:Label>
                    <asp:TextBox ID="TextBox_MaxDesignAar" runat="server"></asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator_MaxAar" runat="server"
                            ErrorMessage="Indtast venligst et år. F.eks. 2005"
                            ValidationGroup="Sogning"
                            ControlToValidate="TextBox_MaxDesignAar"
                            ForeColor="Red"
                            Display="Dynamic"
                            Height="5"
                            ValidationExpression="^[0-9]+$">
                        </asp:RegularExpressionValidator>
                </div>
            </div>

        </asp:Panel>

        <asp:Panel ID="Panel_Pris" CssClass="sogefelter" runat="server">
            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="Label_Pris" runat="server" Text="Pris"></asp:Label>
                </div>
                <div class="col-md-5">
                    <asp:Label ID="Label_MinPris" runat="server" Text="Min:"></asp:Label>
                    <asp:TextBox ID="TextBox_MinPris" runat="server"></asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator_MinPris" runat="server"
                            ErrorMessage="Indtast venligst kun heltal i dette felt. F.eks. 4500"
                            ValidationGroup="Sogning"
                            ControlToValidate="TextBox_MinPris"
                            ForeColor="Red"
                            Display="Dynamic"
                            Height="5"
                            ValidationExpression="^[0-9]+$">
                        </asp:RegularExpressionValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label_MaxPris" runat="server" Text="Max:"></asp:Label>
                    <asp:TextBox ID="TextBox_MaxPris" runat="server"></asp:TextBox><br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator_MaxPris" runat="server"
                            ErrorMessage="Indtast venligst kun heltal i dette felt. F.eks. 4500"
                            ValidationGroup="Sogning"
                            ControlToValidate="TextBox_MaxPris"
                            ForeColor="Red"
                            Display="Dynamic"
                            Height="5"
                            ValidationExpression="^[0-9]+$">
                        </asp:RegularExpressionValidator>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel_SogKnap" runat="server">
            <div class="row">
                <div class="col-md-4 col-md-offset-8">
                    <asp:Button ID="Button_searchKnap" runat="server"
                        ValidationGroup="Sogning"
                        OnClick="Button_searchKnap_Click" Text="Søg" />
                </div>
            </div>
        </asp:Panel>
    </asp:PlaceHolder>



    <asp:PlaceHolder ID="PlaceHolder_SogningResultat" Visible="false" runat="server">
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

