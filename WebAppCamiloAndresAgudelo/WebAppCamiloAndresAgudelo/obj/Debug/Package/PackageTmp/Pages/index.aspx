<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebAppCamiloAndresAgudelo.Pages.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="breadcrumb" runat="server">
    <h2><i class="fa fa-home"></i> Index <span>Pagina Principal</span></h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="row">
        <div class="col-sm-12">
          <div class="panel panel-primary">
            <div class="panel-heading">
              <div class="panel-btns">
                <a href="#" class="panel-close">&times;</a>
                <a href="#" class="minimize">&minus;</a>
              </div><!-- panel-btns -->
              <h3 class="panel-title">Información de la prueba</h3>
            </div>
            <div class="panel-body">
             <p><h3>1). Los Modulos de Administración de usuarios y de Administración de Clientes funcionan con comunicación directa a la base de datos (sin API).</h3></p>
             <p><h3>2). El modulo de factura funciona utilizado la API desarrollada en .net Web API 2.</h3></p>
            </div>
          </div><!-- panel -->
        </div><!-- col-sm-6 -->
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
        <script src="../bracket/scripts/index.js"></script>
</asp:Content>
