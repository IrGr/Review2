<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_Møbler.ascx.cs" Inherits="WUC_WUC_Møbler" %>
<div class="row">
    <div id="mobler_box" class="col-md-12 venstre_box">
        <h3 id="overskrift_moblerbox" runat="server"></h3>
        <asp:Repeater ID="Repeater_RandomProdukt" ItemType="_Produkt" runat="server">
            <ItemTemplate>
                <asp:Image ID="Image_Moblet" ImageUrl='<%# "~/Images/" + Item._Serie.serie_navn + "/" + Item._Billede.billede_sti_300_225 %>' runat="server" />
                <p class="bold">Møbelserie</p>
                <p><%# Item._Serie.serie_navn %></p>
                <p class="bold">Designer</p>
                <p><%# Item.designer %></p>
                <p class="bold">Design år</p>
                <p><%# Item.design_aar %></p>
                <p class="bold">Pris:</p>
                <p><%# Item.pris.ToString()%></p>
            </ItemTemplate>
        </asp:Repeater>


    </div>
</div>
