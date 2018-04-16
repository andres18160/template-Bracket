<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="clientes.aspx.cs" Inherits="WebAppCamiloAndresAgudelo.Pages.clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="breadcrumb" runat="server">
    <h2><i class="fa fa-home"></i>Administración de Clientes</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">
            <div class="panel-btns">
                <a href="#" class="minimize">&minus;</a>
            </div>
            <a id="agregar" class="btn btn-primary">Agregar Cliente</a>
        </div>
        <div class="panel-body">
            <div class="dataTables_wrapper">
                <table class="table" id="tablaClientes">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Nombre</th>
                            <th>Apellidos</th>
                            <th>Cedula</th>
                            <th>Dirección</th>
                            <th>Telefono</th>
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
                    <h4 class="modal-title" id="myModalLabel">Eliminar Cliente</h4>
                </div>
                <div class="modal-body">
                    <label id="labelDeleteClient"></label>
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
                    <h4 class="modal-title" id="myModalAgregar">Agregar Cliente</h4>
                </div>
                <div class="modal-body">
                    <form id="formCrear" onsubmit="return false;">
                        <div class="panel panel-default">
                            <div class="panel-body panel-body-nopadding">
                                <label id="lblMensaje"></label>

                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Nombre:</label>
                                    <div class="col-sm-8">
                                        <input id="txtNombre" type="text" name="Nombres" class="form-control" required maxlength="50" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Apellido:</label>
                                    <div class="col-sm-8">
                                        <input id="txtApellido" type="text" name="Apellido" class="form-control" required maxlength="50" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Cedula:</label>
                                    <div class="col-sm-8">
                                        <input id="txtCedula" type="number" name="Cedula" class="form-control" required maxlength="50" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Direccón:</label>
                                    <div class="col-sm-8">
                                        <input id="txtDireccion" type="text" name="Dirección" class="form-control" required maxlength="100" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Teléfono:</label>
                                    <div class="col-sm-8">
                                        <input id="txtTelefono" type="tel" name="Teléfono" class="form-control" required maxlength="50" />
                                    </div>
                                </div>


                            </div>
                            <!-- panel-body -->
                            <div class="panel-footer">
                                <button id="AgregarCliente" type="submit" class="btn btn-primary">Crear</button>
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
                                        <input id="txtIdActualizar" type="text" name="Id" class="form-control"  maxlength="50" disabled />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Nombre:</label>
                                    <div class="col-sm-8">
                                        <input id="txtNombreActualizar" type="text" name="Nombres" class="form-control" required maxlength="50" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Apellido:</label>
                                    <div class="col-sm-8">
                                        <input id="txtApellidoActualizar" type="text" name="Apellido" class="form-control" required maxlength="50" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Cedula:</label>
                                    <div class="col-sm-8">
                                        <input id="txtCedulaActualizar" type="number" name="Cedula" class="form-control" maxlength="50" disabled />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Direccón:</label>
                                    <div class="col-sm-8">
                                        <input id="txtDireccionActualizar" type="text" name="Dirección" class="form-control" required maxlength="100" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Teléfono:</label>
                                    <div class="col-sm-8">
                                        <input id="txtTelefonoActualizar" type="tel" name="Teléfono" class="form-control" required maxlength="50" />
                                    </div>
                                </div>
                            </div>
                            <!-- panel-body -->
                            <div class="panel-footer">
                                <button id="ActualizarCliente" class="btn btn-primary">Actualizar</button>
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
    <script src="../bracket/scripts/clientes.js"></script>
</asp:Content>
