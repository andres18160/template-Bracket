<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/login.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebAppCamiloAndresAgudelo.Pages.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="col-md-5">
        <form id="formLogin" runat="server">
            <div class="panel panel-default">
                <div class="panel-body">
                    <h4 class="nomargin">Ingresar</h4>
                    <p class="mt5 mb20">Ingreso al sistema...</p>
                    <asp:TextBox ID="txtUsuario" runat="server" class="form-control uname" placeholder="Usuario" MaxLength="20" required ></asp:TextBox>
                    <asp:TextBox ID="txtclave" type="password" runat="server" class="form-control pword" placeholder="Contraseña" MaxLength="20" required ></asp:TextBox>
                    <asp:Button ID="bntLogin"  class="btn btn-success btn-block" runat="server" Text="Ingresar" OnClick="bntLogin_Click" />
                    <asp:Label ID="lblMensaje" runat="server" Text=" "></asp:Label>
                </div>
            </div>
        </form>
    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="scripts" runat="server">
    <script src="../bracket/scripts/login.js"></script>
</asp:Content>

