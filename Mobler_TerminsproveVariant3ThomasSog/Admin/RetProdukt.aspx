<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="RetProdukt.aspx.cs" Inherits="Admin_RetProdukt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">
        <h2>Redigere produkt</h2>
        <hr />
        <!--Navn-->
        <div class="row form-group">
            <asp:Label ID="Label_Navn" runat="server" CssClass="col-md-1 col-md-offset-1 form-control-label" Text="Navn"></asp:Label>
            <div class="col-md-4">
                <asp:TextBox ID="TextBox_Navn" runat="server" class="form-control" ValidationGroup="Produkt"></asp:TextBox>
            </div>
        </div>
        <!--Varenummer-->
        <div class="row form-group">
            <asp:Label ID="Label_Varenummer" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text="Varenummer"></asp:Label>
            <div class="col-md-4">
                <asp:TextBox ID="TextBox_Varenummer" runat="server" class="form-control" ValidationGroup="Produkt"></asp:TextBox>
            </div>
        </div>
        <!--Pris-->
        <div class="row form-group">
            <asp:Label ID="Label_Pris" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text="Pris"></asp:Label>
            <div class="col-md-4">
                <asp:TextBox ID="TextBox_Pris" runat="server" class="form-control" ValidationGroup="Produkt"></asp:TextBox>

            </div>
        </div>
        <!--Designer-->
        <div class="row form-group">
            <asp:Label ID="Label_Designer" runat="server" CssClass="col-md-1 col-md-offset-1 form-control-label" Text="Designer"></asp:Label>
            <div class="col-md-4">
                <asp:TextBox ID="TextBox_Designer" runat="server" class="form-control" ValidationGroup="Produkt"></asp:TextBox>
            </div>
        </div>
        <!--Design År-->
        <div class="row form-group">
            <asp:Label ID="Label_Designaar" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text="Design år"></asp:Label>
            <div class="col-md-4">
                <asp:TextBox ID="TextBox_Designaar" runat="server" class="form-control" ValidationGroup="Produkt"></asp:TextBox>
            </div>
        </div>

        <!--Beskrivelse-->
        <div class="form-group row">
            <asp:Label ID="Label_Beskrivelse" runat="server" CssClass="col-md-1 col-md-offset-1 form-control-label" Text="Beskrivelse"></asp:Label>
            <div class="col-md-4">
                <asp:TextBox ID="TextBox_Beskrivelse" class="topalign form-control" runat="server" TextMode="MultiLine" ValidationGroup="Produkt"></asp:TextBox>
            </div>
        </div>

        <!--Serie-->
        <div class="form-group row">
            <asp:Label ID="Label_Serie" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text="Serie"></asp:Label>
            <div class="col-md-4">
                <asp:DropDownList ID="DropDownList_Serie" runat="server" AutoPostBack="true" ValidationGroup="Produkt"></asp:DropDownList>
            </div>
        </div>


        <!--Upload et billede-->
        <div class="form-group row">
            <asp:Label ID="Label_Billede" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text=""></asp:Label>
            <div class="col-md-4">
                <asp:FileUpload ID="FileUpload_Billede" runat="server" />
            </div>
        </div>


        <!--UpdatePanel1-->
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ScriptManager runat="server"></asp:ScriptManager>
                <!--PrimBillede-->
                <div class="form-group row">
                    <asp:Label ID="Label_PrimBillede" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text="Primært billede"></asp:Label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="DropDownList_PrimBillede" runat="server"
                            AutoPostBack="true" OnSelectedIndexChanged="DropDownList_PrimBillede_SelectedIndexChanged"
                            ValidationGroup="Produkt">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group col-md-offset-1">
                    <asp:Image ID="Image_PrimertBillede" ImageUrl="#" Width="200" Height="100" runat="server" />
                </div>




                <asp:CheckBoxList ID="CheckBoxList_ProduktBilleder"
                    RepeatDirection="Horizontal"
                    TextAlign="Right"
                    RepeatColumns="5"
                    OnDataBound="CheckBoxList_ProduktBilleder_DataBound"
                    runat="server">
                </asp:CheckBoxList>


            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DropDownList_PrimBillede" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>




        <asp:Button ID="Button_SletBilleder" runat="server" OnClick="Button_SletBilleder_Click" Text="SletBilleder" />

        <div class="form-group">
            <asp:Button ID="Button_GemProdukt" runat="server" CssClass="pull-center btn"
                OnClick="Button_GemProdukt_Click" Text="Gem" ValidationGroup="Produkt" />
        </div>
    </div>


</asp:Content>

