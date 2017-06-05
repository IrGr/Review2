<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="RetNyheder.aspx.cs" Inherits="RetNyheder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container">
        <h2>Redigere nyheden</h2>
        <hr />
        <div class="row form-group">
            <!--Overskrift-->
            <asp:Label ID="Label_Overskrift" runat="server" CssClass="col-md-1 col-md-offset-1 form-control-label" Text="Overskrift"></asp:Label>
            <div class="col-md-4">
                <asp:TextBox ID="TextBox_Overskrift" runat="server" class="form-control" ValidationGroup="nyhed"></asp:TextBox>
                <asp:HiddenField ID="HiddenField_NyhedId" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Overskrift" runat="server"
                    ErrorMessage="Må ikke være tom!!"
                    Text="Må ikke være tom!! * "
                    ControlToValidate="TextBox_Overskrift"
                    Display="Dynamic"
                    ForeColor="Red"
                    Font-Size="X-Small"
                    ValidationGroup="Nyhed">
                </asp:RequiredFieldValidator>
            </div>
        </div>

        <!--Tekst-->
        <div class="form-group row">
            <asp:Label ID="Label_Tekst" runat="server" CssClass="col-md-1 col-md-offset-1 form-control-label" Text="Tekst"></asp:Label>
            <div class="col-md-4">
                <asp:TextBox ID="TextBox_Tekst" class="topalign form-control" runat="server" TextMode="MultiLine" ValidationGroup="Nyhed"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Tekst" runat="server"
                    ErrorMessage="Må ikke være tom!!"
                    Text="Må ikke være tom!! * "
                    ControlToValidate="TextBox_Tekst"
                    Display="Dynamic"
                    ForeColor="Red"
                    Font-Size="X-Small"
                    ValidationGroup="Nyhed">
                </asp:RequiredFieldValidator>
            </div>
        </div>
        <!--Forfatter-->
        <div class="form-group row">
            <asp:Label ID="Label_Forfatter" runat="server" CssClass="col-md-1 col-md-offset-1 form-control-label" Text="Forfatter"></asp:Label>
            <div class="col-md-4">
                <asp:TextBox ID="TextBox_Forfatter" class="form-control" runat="server" ValidationGroup="Nyhed"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Forfatter" runat="server"
                    ErrorMessage="Må ikke være tom!!"
                    Text="Må ikke være tom!! * "
                    ControlToValidate="TextBox_Forfatter"
                    Display="Dynamic"
                    ForeColor="Red"
                    Font-Size="X-Small"
                    ValidationGroup="Nyhed">
                </asp:RequiredFieldValidator>
            </div>
        </div>
        <asp:Button ID="Button_GemNyhed" runat="server" 
            class="col-md-2 col-md-offset-3" OnClick="Button_GemNyhed_Click" 
            Text="Gem" ValidationGroup="Nyhed" />
        <asp:Label ID="Label_Fejl" Visible="false" runat="server" Text="Label"></asp:Label>
    </div>

    
</asp:Content>

