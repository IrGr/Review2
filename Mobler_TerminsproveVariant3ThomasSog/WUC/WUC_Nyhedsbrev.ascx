<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_Nyhedsbrev.ascx.cs" Inherits="WUC_WebUserControl" %>
<div class="row">
    <div class="col-md-12 venstre_box">
        <h3 id="overskrift_nyhedsbrevbox" runat="server"></h3>
        <asp:TextBox ID="TextBox_Nyhedsbrevbox" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Email" runat="server"
                ErrorMessage="Må ikke være tom!!"
                Text="Må ikke være tom!! * " 
                ControlToValidate="TextBox_Nyhedsbrevbox"
                Display="Dynamic" 
                ForeColor="Red"
                Font-Size="X-Small"
                ValidationGroup="NyhedBrev">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator_Email" 
                runat="server"
                ControlToValidate="TextBox_Nyhedsbrevbox"
                ValidationExpression =".{3,500}"
                ForeColor="Red"
                Display="Dynamic" 
                ErrorMessage="Skriv din Email! Eks.:bruger@gmail.com"
                Font-Size="X-Small"
                ValidationGroup="NyhedBrev">
            </asp:RegularExpressionValidator>
        <asp:Label ID="Label_NyhBrevTilm" runat="server" Visible="false" Text="Tak for din tilmelding"></asp:Label>
        <asp:Label ID="Label__NyhBrevFram" runat="server" Visible="false"></asp:Label>

        <p>
            <asp:LinkButton ID="LinkButton_Tilmeld" class="btn btn-default btn-xs"
                runat="server" OnClick="LinkButton_Tilmeld_Click"  
                ValidationGroup="NyhedBrev">Tilmeld <span class="glyphicon glyphicon-ok"></span>
            </asp:LinkButton>

            <asp:LinkButton ID="LinkButton_Frameld" class="btn btn-default btn-xs"
                runat="server" OnClick="LinkButton_Frameld_Click">Frameld <span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
        </p>
    </div>
</div>
