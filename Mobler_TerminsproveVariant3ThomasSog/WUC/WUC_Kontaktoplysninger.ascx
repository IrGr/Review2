<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_Kontaktoplysninger.ascx.cs" Inherits="WUC_Kontaktoplysninger" %>
<div class="row">
    <div class="col-md-12 venstre_box">
        <h3 id="overskrift_kontaktoplysningerbox" runat="server"></h3>
        <asp:Repeater ID="Repeater_Kontaktoplysninger" ItemType="_Kontaktoplysninger" runat="server">
            <ItemTemplate>
                <p class="bold"><%# Item.navn  %></p>
                <p><%# Item.adresse  %></p>
                <p><%# Item.postnr + "" + Item.byen  %></p>
                <br />
                <p class="bold">Telefon</p>
                <p><%# Item.telefon %></p>
                <p class="bold">Email</p>
                <p><%# Item.email  %></p>
            </ItemTemplate>
        </asp:Repeater>
        
    </div>
</div>
