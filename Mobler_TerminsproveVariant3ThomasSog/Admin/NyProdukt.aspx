<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="NyProdukt.aspx.cs" Inherits="Admin_NyProdukt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">
        <h2>Opret et nyt produkt</h2>
        <hr />
        <!--Navn-->
        <div class="row form-group">
            <asp:Label ID="Label_Navn" runat="server" CssClass="col-md-1 col-md-offset-1 form-control-label" Text="Navn"></asp:Label>
            <div class="col-md-4">
                <asp:TextBox ID="TextBox_Navn" runat="server" class="form-control" ValidationGroup="Produkt"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Navn" runat="server"
                    ErrorMessage="Må ikke være tom!!"
                    Text="Må ikke være tom!! * "
                    ControlToValidate="TextBox_Navn"
                    Display="Dynamic"
                    ForeColor="Red"
                    Font-Size="X-Small"
                    ValidationGroup="Produkt">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator_Navn"
                    runat="server"
                    ControlToValidate="TextBox_Navn"
                    ValidationExpression=".{3,100}"
                    ForeColor="Red"
                    Display="Dynamic"
                    ErrorMessage="Skriv et navn! Der skal være min. 3 bogstaver"
                    Font-Size="X-Small"
                    ValidationGroup="Produkt">
                </asp:RegularExpressionValidator>
            </div>
        </div>
        <!--Varenummer-->
        <div class="row form-group">
            <asp:Label ID="Label_Varenummer" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text="Varenummer"></asp:Label>
            <div class="col-md-4">
                <asp:TextBox ID="TextBox_Varenummer" runat="server" class="form-control" ValidationGroup="Produkt"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Varenummer" runat="server"
                    ErrorMessage="Må ikke være tom!!"
                    Text="Må ikke være tom!! * "
                    ControlToValidate="TextBox_Varenummer"
                    Display="Dynamic"
                    ForeColor="Red"
                    Font-Size="X-Small"
                    ValidationGroup="Produkt">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator_Varenummer"
                    runat="server"
                    ControlToValidate="TextBox_Varenummer"
                    ValidationExpression="[0-9]+"
                    ErrorMessage="Der kan kun være cifre"
                    ForeColor="Red"
                    Display="Dynamic"
                    Font-Size="X-Small"
                    ValidationGroup="Produkt">
                </asp:RegularExpressionValidator>
            </div>
        </div>
        <!--Pris-->
        <div class="row form-group">
            <asp:Label ID="Label_Pris" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text="Pris"></asp:Label>
            <div class="col-md-4">
                <asp:TextBox ID="TextBox_Pris" runat="server" class="form-control" ValidationGroup="Produkt"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Pris" runat="server"
                    ErrorMessage="Må ikke være tom!!"
                    Text="Må ikke være tom!! * "
                    ControlToValidate="TextBox_Pris"
                    Display="Dynamic"
                    ForeColor="Red"
                    Font-Size="X-Small"
                    ValidationGroup="Produkt">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator_Pris"
                    runat="server"
                    ControlToValidate="TextBox_Pris"
                    ValidationExpression="^\d{0,8}(\.\d{1,4})?$"
                    ForeColor="Red"
                    Display="Dynamic"
                    ErrorMessage="Der kan kun være cifre"
                    Font-Size="X-Small"
                    ValidationGroup="Produkt">
                </asp:RegularExpressionValidator>
            </div>
        </div>
        <!--Designer-->
        <div class="row form-group">
            <asp:Label ID="Label_Designer" runat="server" CssClass="col-md-1 col-md-offset-1 form-control-label" Text="Designer"></asp:Label>
            <div class="col-md-4">
                <asp:TextBox ID="TextBox_Designer" runat="server" class="form-control" ValidationGroup="Produkt"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Designer" runat="server"
                    ErrorMessage="Må ikke være tom!!"
                    Text="Må ikke være tom!! * "
                    ControlToValidate="TextBox_Designer"
                    Display="Dynamic"
                    ForeColor="Red"
                    Font-Size="X-Small"
                    ValidationGroup="Produkt">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator_Designer"
                    runat="server"
                    ControlToValidate="TextBox_Designer"
                    ValidationExpression=".{3,100}"
                    ForeColor="Red"
                    Display="Dynamic"
                    ErrorMessage="Skriv et designersnavn. Der skal være min. 3 bogstaver"
                    Font-Size="X-Small"
                    ValidationGroup="Produkt">
                </asp:RegularExpressionValidator>
            </div>
        </div>
        <!--Design År-->
        <div class="row form-group">
            <asp:Label ID="Label_Designaar" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text="Design år"></asp:Label>
            <div class="col-md-4">
                <asp:TextBox ID="TextBox_Designaar" runat="server" class="form-control" ValidationGroup="Produkt"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Designaar" runat="server"
                    ErrorMessage="Må ikke være tom!!"
                    Text="Må ikke være tom!! * "
                    ControlToValidate="TextBox_Designaar"
                    Display="Dynamic"
                    ForeColor="Red"
                    Font-Size="X-Small"
                    ValidationGroup="Produkt">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator_Designaar"
                    runat="server"
                    ControlToValidate="TextBox_Designaar"
                    ValidationExpression="^\d{0,8}(\.\d{1,4})?$"
                    ForeColor="Red"
                    Display="Dynamic"
                    ErrorMessage="Der kan kun være cifre"
                    Font-Size="X-Small"
                    ValidationGroup="Produkt">
                </asp:RegularExpressionValidator>
            </div>
        </div>

        <!--Beskrivelse-->
        <div class="form-group row">
            <asp:Label ID="Label_Beskrivelse" runat="server" CssClass="col-md-1 col-md-offset-1 form-control-label" Text="Beskrivelse"></asp:Label>
            <div class="col-md-4">
                <asp:TextBox ID="TextBox_Beskrivelse" class="topalign form-control" runat="server" TextMode="MultiLine" ValidationGroup="Produkt"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Beskrivelse" runat="server"
                    ErrorMessage="Må ikke være tom!!"
                    Text="Må ikke være tom!! * "
                    ControlToValidate="TextBox_Beskrivelse"
                    Display="Dynamic"
                    ForeColor="Red"
                    Font-Size="X-Small"
                    ValidationGroup="Produkt">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator_Beskrivelse"
                    runat="server"
                    ControlToValidate="TextBox_Beskrivelse"
                    ValidationExpression=".{3,100}"
                    ForeColor="Red"
                    Display="Dynamic"
                    ErrorMessage="Skriv et designersnavn. Der skal være min. 3 bogstaver"
                    Font-Size="X-Small"
                    ValidationGroup="Produkt">
                </asp:RegularExpressionValidator>
            </div>
        </div>

        <!--Serie-->
        <div class="form-group row">
            <asp:Label ID="Label_Serie" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text="Serie"></asp:Label>
            <div class="col-md-4">
                <asp:DropDownList ID="DropDownList_Serie" runat="server" AutoPostBack="true" ValidationGroup="Produkt"></asp:DropDownList>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator_DdlSerie" runat="server" ValidationGroup="Produkt"
                    ControlToValidate="DropDownList_Serie" InitialValue="" ForeColor="Red" Font-Size="X-Small"
                    ErrorMessage="Vælg en værdi fra listen." Display="Dynamic" />
            </div>
        </div>


        <!--Upload et billede-->
        <div class="form-group row">
            <asp:Label ID="Label_Billede" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text=""></asp:Label>
            <div class="col-md-4">
                <asp:FileUpload ID="FileUpload_Billede" runat="server" />
                <%-- <asp:Label ID="Label_FejlUpload" runat="server" Visible="false" ForeColor="Red" Text="Produktet skal have et billede"></asp:Label>--%>
                <asp:RequiredFieldValidator ErrorMessage="Required"
                    ControlToValidate="FileUpload_Billede"
                    runat="server"
                    ValidationGroup="Produkt"
                    Display="Dynamic"
                    ForeColor="Red" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator_FileUpload"
                    ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.jpg|.JPG|.png|.PNG|.jpeg|.JPEG|.GIF|.gif)$"
                    ControlToValidate="FileUpload_Billede"
                    runat="server"
                    ForeColor="Red"
                    ErrorMessage="Please select a valid Word or PDF File file."
                    Display="Dynamic"
                    ValidationGroup="Produkt" />

            </div>


            <asp:Button ID="Button_NytProdukt" runat="server" CssClass="pull-center btn" OnClick="Button_NytProdukt_Click" Text="Gem" ValidationGroup="Produkt" />
        </div>
    </div>

</asp:Content>

