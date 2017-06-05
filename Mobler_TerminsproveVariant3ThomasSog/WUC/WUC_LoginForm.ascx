<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_LoginForm.ascx.cs" Inherits="WUC_WUC_LoginForm" %>
<div class="container">
    <asp:PlaceHolder ID="PlaceHolderLoginOpretForm" runat="server">
        <div class="row">
            <div class="col-md-8">
                <div class="well login-box">
                    <div>
                        <legend>Login</legend>
                        <div class="form-group">
                            <asp:TextBox ID="TextBox_Brugernavn" placeholder="admin" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="TextBox_Password" placeholder="1234" TextMode="Password" class="form-control password" runat="server"></asp:TextBox>
                       
                        </div>
                        <div class="form-group">
                            <asp:Button ID="Button_Login" 
                                        class="btn btn-success btn-login-submit "
                                        OnClick="Button_Login_Click" 
                                        runat="server" Text="Login" />
                        </div>
                    </div>
                </div>
                <asp:Label ID="Label_Error" Visible="false" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </asp:PlaceHolder>

</div>