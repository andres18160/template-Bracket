<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="usuarios_admin.aspx.cs" Inherits="WebAppCamiloAndresAgudelo.Pages.usuarios_admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="breadcrumb" runat="server">
    <h2><i class="fa fa-home"></i>Administración de Usuarios</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">
            <div class="panel-btns">
                <a href="#" class="minimize">&minus;</a>
            </div>
            <a id="agregar" class="btn btn-primary">Agregar usuario</a>
        </div>
        <div class="panel-body">
            <div class="dataTables_wrapper">
                <table class="table" id="tablaUsuarios">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Nombre</th>
                            <th>Usuario</th>
                            <th>Acción</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                   
                </table>
            </div>
            <!-- table-responsive -->
        </div>
        <!-- panel-body -->
    </div>
    <!-- panel -->
    <!-- Modal -->
    <div class="modal fade" id="ModalDelete" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">Eliminar usuario</h4>
                </div>
                <div class="modal-body">
                    Estas seguro de eliminar el usuario
                    <label id="labelDeleteUser"></label>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                    <button type="button" id="delete" class="btn btn-primary">Si</button>
                </div>
            </div>
            <!-- modal-content -->
        </div>
        <!-- modal-dialog -->
    </div>
    <!-- modal -->


    <div class="modal fade" id="ModalAgregar" tabindex="-1" role="dialog" aria-labelledby="myModalAgregar" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalAgregar">Agregar Usuario</h4>
                </div>
                <div class="modal-body">
                    <form id="formCrear" onsubmit="return false;">
                        <div class="panel panel-default">
                            <div class="panel-body panel-body-nopadding">
                                <label id="lblMensaje"></label>
                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Nombre:</label>
                                    <div class="col-sm-8">
                                        <input id="txtNombre" type="text" name="Nombre" class="form-control" required maxlength="50" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Usuario:</label>
                                    <div class="col-sm-8">
                                        <input id="txtUsuario" type="text" name="Usuario" class="form-control" required maxlength="20" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Password:</label>
                                    <div class="col-sm-8">
                                        <input id="txtPassword" type="password" name="Password" class="form-control" required maxlength="20" />
                                    </div>
                                </div>
                            </div>
                            <!-- panel-body -->
                            <div class="panel-footer">
                                <button id="AgregarUsuario" class="btn btn-primary">Crear</button>
                                <button type="reset" class="btn btn-default">Reset</button>
                            </div>
                            <!-- panel-footer -->
                        </div>
                        <!-- panel-default -->
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>

                </div>
            </div>
            <!-- modal-content -->
        </div>
        <!-- modal-dialog -->
    </div>
    <!-- modal -->





    <div class="modal fade" id="ModalActualizar" tabindex="-1" role="dialog" aria-labelledby="myModalActualizar" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalActualizar"></h4>
                </div>
                <div class="modal-body">
                    <form id="formActualizar" onsubmit="return false;">
                        <div class="panel panel-default">
                            <div class="panel-body panel-body-nopadding">
                                <label id="lblMensajeActualizar"></label>
                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Id:</label>
                                    <div class="col-sm-2">
                                        <input id="txtIdActualizar" type="text" name="Id" class="form-control" disabled />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Nombre:</label>
                                    <div class="col-sm-8">
                                        <input id="txtNombreActualizar" type="text" name="Nombre" class="form-control" required maxlength="50" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Usuario:</label>
                                    <div class="col-sm-8">
                                        <input id="txtUsuarioActualizar" type="text" name="Usuario" class="form-control" required maxlength="20" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Password:</label>
                                    <div class="col-sm-8">

                                        <input id="txtPasswordActualizar" type="password" name="Password" class="form-control" required maxlength="20" />
                                    </div>
                                </div>
                            </div>
                            <!-- panel-body -->
                            <div class="panel-footer">
                                <button id="ActualizarUsuario" class="btn btn-primary">Actualizar</button>
                                <button type="reset" class="btn btn-default">Reset</button>
                            </div>
                            <!-- panel-footer -->
                        </div>
                        <!-- panel-default -->
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>

                </div>
            </div>
            <!-- modal-content -->
        </div>
        <!-- modal-dialog -->
    </div>
    <!-- modal -->












</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
    <script src="../bracket/scripts/usuarios_admin.js"></script>
</asp:Content>
