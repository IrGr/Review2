<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="RetAabningstid.aspx.cs" Inherits="Admin_RetAabningstid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
             <asp:PlaceHolder ID="PlaceHolder_RedIndhold" runat="server">
                <h2>Redigere åbningstid</h2>
                <hr />
                <div class="form-group row">
                    <asp:Label ID="Label_Dag" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text="Dag"></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox ID="TextBox_Dag" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Dag" runat="server"
                            ErrorMessage="Må ikke være tom!!"
                            Text="Må ikke være tom!! * "
                            ControlToValidate="TextBox_Dag"
                            Display="Dynamic"
                            ForeColor="Red"
                            Font-Size="X-Small"
                            CssClass="pull-right"
                            ValidationGroup="AabningsTid">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <asp:Label ID="Label_Aaben" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text="Åben"></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox ID="TextBox_Aaben" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Aaben" runat="server"
                            ErrorMessage="Må ikke være tom!!"
                            Text="Må ikke være tom!! * "
                            ControlToValidate="TextBox_Aaben"
                            Display="Dynamic"
                            ForeColor="Red"
                            Font-Size="X-Small"
                            CssClass="pull-right"
                            ValidationGroup="AabningsTid">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <asp:Label ID="Label_Luk" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text="Luk"></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox ID="TextBox_Luk" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Luk" runat="server"
                            ErrorMessage="Må ikke være tom!!"
                            Text="Må ikke være tom!! * "
                            ControlToValidate="TextBox_Luk"
                            Display="Dynamic"
                            ForeColor="Red"
                            Font-Size="X-Small"
                            CssClass="pull-right"
                            ValidationGroup="AabningsTid">
                        </asp:RequiredFieldValidator>
                        <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator_Addresse" 
                            runat="server"
                            ControlToValidate="TextBox_Luk"
                            ValidationExpression ="/^\d*\.?\d*$/"
                            ForeColor="Red"
                            Display="Dynamic" 
                            ErrorMessage="Skriv kun cifre!"
                            Font-Size="X-Small"
                            CssClass="pull-right"
                            ValidationGroup="AabningsTid"
                            >
                        </asp:RegularExpressionValidator>--%>
                    </div>
                </div>
                <br />
                <div class="form-group row">
                    <asp:Button ID="Button_Aabningstid" ValidationGroup="AabningsTid"
                        CssClass="btn form col-md-offset-5 "
                        OnClick="Button_Aabningstid_Click"
                        runat="server" Text="Redigere" />
                </div>

            </asp:PlaceHolder>
        </div>
    </div>



</asp:Content>

