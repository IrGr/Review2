<%@ Page Title="Kontakt: CMK Møbler" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Kontakt.aspx.cs" Inherits="Kontakt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content_SideNavn" ContentPlaceHolderID="ContentPlaceHolder_SideNavn" runat="server">
     <asp:Label ID="Label_SideNavn" runat="server" Text="Kontakt"></asp:Label>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h3 id="overskrift_aabningstider" runat="server"></h3>
    <asp:Repeater ID="Repeater_Aabningstider" ItemType="_Aabningstid" runat="server">
        <ItemTemplate>
            <p class="bold"><%# Item.dag %> </p>
            <p><%# Item.aaben + "-" + Item.luk %> </p>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Panel ID="Panel_KontaktFormular" runat="server">
        <div class="input-group">
          <span class="input-group-addon" id="basic-addon1">Navn</span>
          <asp:TextBox ID="TextBox_Navn" CssClass="form-control" runat="server" 
              placeholder="Udfyld venligst" aria-describedby="basic-addon1"></asp:TextBox><br />
        </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_navn" runat="server"
                ErrorMessage="Må ikke være tom!!"
                Text="Må ikke være tom!! * " 
                ControlToValidate="TextBox_Navn"
                Display="Dynamic" 
                ForeColor="Red"
                Font-Size="X-Small"
                ValidationGroup="Kontakt">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator_Navn" 
                runat="server"
                ControlToValidate="TextBox_Navn"
                ValidationExpression =".{3,100}"
                ForeColor="Red"
                Display="Dynamic" 
                ErrorMessage="Skriv dit navn! Der skal være min. 3 bogstaver"
                Font-Size="X-Small"
                ValidationGroup="Kontakt">
            </asp:RegularExpressionValidator>
        
         <div class="input-group">
          <span class="input-group-addon">Adresse</span>
            <asp:TextBox ID="TextBox_Adresse" CssClass="form-control" runat="server" 
                placeholder="Udfyld venligst" aria-describedby="basic-addon1"></asp:TextBox>
        </div>
        <div class="input-group">
          <span class="input-group-addon">Telefon</span>
            <asp:TextBox ID="TextBox_Telefon" CssClass="form-control" runat="server" 
                placeholder="Udfyld venligst" aria-describedby="basic-addon1"></asp:TextBox><br />
           <asp:RegularExpressionValidator ID="RegularExpressionValidator_Tlf"
                ControlToValidate="TextBox_Telefon"
                runat="server"
                ForeColor="Red"
                Display="Dynamic"
                Font-Size="X-Small"
                ValidationGroup="Kontakt"
                ErrorMessage="Telefonnummer er ikke gyldigt (Eks:+45 35 35 35 35)"
                ValidationExpression="^((\(?\+45\)?)?)(\s?\d{2}\s?\d{2}\s?\d{2}\s?\d{2})$"
                ><%--Pass:(+45) 35 35 35 35 ||| +45 35 35 35 35 ||| 35 35 35 35 ||| 35353535
                    Fail:	(45)35353535 ||| 4535353535--%>
            </asp:RegularExpressionValidator>
        </div>
        <div class="input-group">
          <span class="input-group-addon">Email</span>
            <asp:TextBox ID="TextBox_Email" CssClass="form-control" runat="server" 
                placeholder="Udfyld venligst" aria-describedby="basic-addon1"></asp:TextBox><br />
         </div>   
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Email" runat="server"
                ErrorMessage="Må ikke være tom!!"
                Text="Må ikke være tom!! * " 
                ControlToValidate="TextBox_Email"
                Display="Dynamic" 
                ForeColor="Red"
                Font-Size="X-Small"
                ValidationGroup="Kontakt">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator_Email" 
                runat="server"
                ControlToValidate="TextBox_Email"
                ValidationExpression ="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ForeColor="Red"
                Display="Dynamic" 
                ErrorMessage="Skriv din Email! Eks.:bruger@gmail.com"
                Font-Size="X-Small"
                ValidationGroup="Kontakt">
            </asp:RegularExpressionValidator>
        
        <div class="input-group">
          <span class="input-group-addon">Kommentar</span>
            <asp:TextBox ID="TextBox_Kommentar" TextMode="MultiLine" CssClass="form-control" 
                runat="server" placeholder="Udfyld venligst" aria-describedby="basic-addon1"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Besked" runat="server"
            ErrorMessage="Må ikke være tom!!"
            Text="Må ikke være tom!! * " 
            ControlToValidate="TextBox_Kommentar"
            Display="Dynamic" 
            ForeColor="Red"
            Font-Size="X-Small"
            ValidationGroup="Kontakt">
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator_Besked" 
            runat="server"
            ControlToValidate="TextBox_Kommentar"
            ValidationExpression =".{3,1500}"
            ForeColor="Red"
            Display="Dynamic" 
            ErrorMessage="Skriv din besked! Der skal være min. 3 bogstaver"
            Font-Size="X-Small"
            ValidationGroup="Kontakt">
        </asp:RegularExpressionValidator>
        <asp:Button ID="Button_Send" CssClass="btn btn-success pull-left" ValidationGroup="Kontakt"
                    OnClick="Button_Send_Click" runat="server" Text="Send" />
   </asp:Panel>


    <asp:Panel ID="Panel_TakBesked" Visible="false" runat="server">
        <asp:Label ID="Label_TakBesked" runat="server" Text="Tak for din henvendelse. du vil høre fra os hurtigst muligt."></asp:Label>
    </asp:Panel>


        

    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <hr />
    <div class="bottom">
        <ul class="breadcrumb container">
            <li><a href="Default.aspx">Forside</a></li>
            <li class="aktive"><asp:HyperLink ID="HyperLink_BreadCrumb_Kontakt" runat="server">Kontakt</asp:HyperLink></li>
        </ul>
    </div>
</asp:Content>

