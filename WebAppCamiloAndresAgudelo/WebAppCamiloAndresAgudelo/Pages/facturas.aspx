<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="facturas.aspx.cs" Inherits="WebAppCamiloAndresAgudelo.Pages.facturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="breadcrumb" runat="server">
    <h2><i class="fa fa-home"></i>Facturas</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">


    <div class="panel panel-default">
        <div class="panel-heading">
            <div class="panel-btns">
                <a href="#" class="minimize">&minus;</a>
            </div>
            <a id="agregarFacturaOpen" class="btn btn-primary">Agregar Factura</a>
        </div>
        <div class="panel-body">
            <div class="dataTables_wrapper">
                <table class="table" id="tablaFacturas">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Fecha</th>
                            <th>AutoRetenedor</th>
                            <th>Estado</th>
                            <th>Cliente</th>
                            <th>ValorTotal</th>
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




    <div id="modalCrearFactura" class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">Agregar Factura</h4>
                </div>
                <div class="modal-body">
                    <form id="formCrear" onsubmit="return false;">
                        <div class="panel panel-default">
                            <div class="panel-body panel-body-nopadding">
                                <label id="lblMensaje"></label>

                                <div class="form-group">
                                    <label class="col-sm-2 control-label">Fecha:</label>
                                    <div class="input-group col-sm-3">
                                        <input type="text" class="form-control" id="txtFecha" name="Fecha" placeholder="dd/mm/yyyy" required>
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-2 control-label">Estado:</label>
                                    <div class="form-group">
                                        <div class="col-sm-3">
                                            <select id="EstadoSelectCrear" name="Estado" class="form-control input-sm mb15" required>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">Cliente:</label>
                                    <div class="col-sm-5">
                                        <select id="clienteSelectCrear" class="form-control chosen-select" name="Cliente" data-placeholder="Seleccione un Cliente" required>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">Valor Total:</label>
                                    <div class="input-group col-sm-3">
                                        <input type="text" class="form-control" id="txtValorTotalCrear" name="ValorTotal" required>
                                    </div>
                                </div>
                                 <div class="form-group">
                                    <label class="col-sm-2 control-label">AutoRetenedor:</label>
                                    <div class="input-group ckbox ckbox-primary">
                                        <input type="checkbox" value="1" id="AutoRetenedor" name="AutoRetenedor" checked="checked" />
                                        <label for="AutoRetenedor"></label>
                                    </div>
                                </div>
                                <a class="btn btn-success" id="addItemCrear">Agregar Item</a>


                                <div class="dataTables_wrapper">
                                    <table class="table" id="tablaDetalleFactura">
                                        <thead>
                                            <tr>
                                                <th>Descripción</th>
                                                <th>Cantidad</th>
                                                <th>Valor Unitario</th>
                                                <th>Valor Total</th>
                                                <th>Acción</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>

                                    </table>
                                </div>
                                <!-- table-responsive -->

                                <!-- panel-body -->
                                <div class="panel-footer">
                                    <button id="AgregarFacturaCrear" type="submit" class="btn btn-primary">Crear</button>
                                    <button type="reset" class="btn btn-default">Reset</button>
                                </div>
                                <!-- panel-footer -->
                            </div>
                        </div>
                        <!-- panel-default -->
                    </form>

                </div>
                <div class="modal-footer">
                    <button type="button" id="BtnCancelar" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>



    <div id="modalActualizarFactura" class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Actualizar Factura:
                        <label id="NumeroFacturaActualizar"></label>
                    </h4>
                </div>
                <div class="modal-body">
                    <form id="formActualizar" onsubmit="return false;">
                        <div class="panel panel-default">
                            <div class="panel-body panel-body-nopadding">
                                <label id="lblMensajeActualizar"></label>
                                <input type="text" id="txtIdFacturaActualizar" name="txtIdFacturaActualizar"  style="visibility:hidden;">
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">Fecha:</label>
                                    <div class="input-group col-sm-3">
                                        <input type="text" class="form-control" id="txtFechaActualizar" name="Fecha" placeholder="dd/mm/yyyy" required>
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-2 control-label">Estado:</label>
                                    <div class="form-group">
                                        <div class="col-sm-3">
                                            <select id="EstadoSelectActualizar" name="Estado" class="form-control input-sm mb15" required>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">Cliente:</label>
                                    <div class="col-sm-5">
                                        <select id="clienteSelectActualizar" class="form-control " name="Cliente" data-placeholder="Seleccione un Cliente" required>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">Valor Total:</label>
                                    <div class="input-group col-sm-3">
                                        <input type="text" class="form-control" id="txtValorSumaTotalActualizar" name="ValorTotal" required>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">AutoRetenedor:</label>
                                    <div class="input-group ckbox ckbox-primary">
                                        <input type="checkbox" value="1" id="AutoRetenedorActualizar" name="AutoRetenedor" checked="checked" />
                                        <label for="AutoRetenedorActualizar"></label>
                                    </div>
                                </div>
                                <a class="btn btn-success" id="addItemActualizar">Agregar Item</a>


                                <div class="dataTables_wrapper">
                                    <table class="table" id="tablaDetalleFacturaActualizar">
                                        <thead>
                                            <tr>
                                                <th>Descripción</th>
                                                <th>Cantidad</th>
                                                <th>Valor Unitario</th>
                                                <th>Valor Total</th>
                                                <th>Acción</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>

                                    </table>
                                </div>
                                <!-- table-responsive -->

                                <!-- panel-body -->
                                <div class="panel-footer">
                                    <button id="AgregarFacturaActualizar" type="submit" class="btn btn-primary">Actualizar</button>
                                </div>
                                <!-- panel-footer -->
                            </div>
                        </div>
                        <!-- panel-default -->
                    </form>

                </div>
                <div class="modal-footer">
                    <button type="button" id="BtnCancelarActualziar" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
    <script src="../bracket/scripts/facturas.js"></script>
</asp:Content>
