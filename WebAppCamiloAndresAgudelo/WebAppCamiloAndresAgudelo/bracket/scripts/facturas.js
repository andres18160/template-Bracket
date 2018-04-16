var clientes;
var facturas;
jQuery(document).ready(function () {
    jQuery("#formCrear").validate({
        highlight: function (element) {
            jQuery(element).closest('.form-group').removeClass('has-success').addClass('has-error');
        },
        success: function (element) {
            jQuery(element).closest('.form-group').removeClass('has-error');
        }
    });
    $('#liFacturas').addClass('active');
    jQuery('#txtFecha').datepicker({ dateFormat: 'dd/mm/yy' }); 
    jQuery('#txtFechaActualizar').datepicker({ dateFormat: 'dd/mm/yy' }); 

    jQuery(".chosen-select").chosen({ 'width': '100%', 'white-space': 'nowrap' });

    $("#agregarFacturaOpen").click(function () {
        $(".otrasFilas").remove();
        $("#modalCrearFactura").modal("show");
    });



    $("#addItemCrear").click(function () {
        var itemNum = $("#tablaDetalleFactura >tbody >tr").length;
        itemNum++;
        var item = "";
        item += "<tr class='otrasFilas'>";
        item += '<td><input type="text" class="form-control txtDescripcion" id="txtDecripcion' + itemNum + '" name="Descripcion' + itemNum + '" required  maxlength="50"></td>';
        item += '<td><input type="text" class="form-control txtCantidad input-number" id="txCantidad' + itemNum + '" name="Cantidad' + itemNum + '" required ></td>';
        item += '<td><input type="text" class="form-control txtValorUnitario input-number" id="txtValorUnitario' + itemNum + '" name="ValorUnitario' + itemNum + '" required ></td>';
        item += '<td><input type="text" class="form-control txtValorTotal input-number" id="txtValorTotal' + itemNum + '"  name="ValorTotal' + itemNum + '" ></td>';
        item += '<td>  <a  class="delete-row deleteRow" > <i class="fa fa-trash-o"></i></a> </td>';
        item += "</tr>";
        $('#tablaDetalleFactura tbody').append(item);

        $('.input-number').on('input', function () {
            this.value = this.value.replace(/[^0-9]/g, '');
        });
        $(".deleteRow").live('click', function (event) {
            $(this).closest('tr').remove();
            var itemNum = $("#tablaDetalleFactura >tbody >tr").length;
            calcularTotal(itemNum);
        });
        $("#txtValorUnitario" + itemNum).blur(function () {
            var cantidad = $("#txCantidad" + itemNum).val();
            var valorUnit = $("#txtValorUnitario" + itemNum).val();
            if (cantidad != "" && valorUnit != "") {
                $("#txtValorTotal" + itemNum).val(cantidad * valorUnit);
                calcularTotal(itemNum);
            }
        });
        $("#txCantidad" + itemNum).blur(function () {
            var cantidad = $("#txCantidad" + itemNum).val();
            var valorUnit = $("#txtValorUnitario" + itemNum).val();
            if (cantidad != "" && valorUnit != "" && cantidad != undefined && valorUnit != undefined) {
                $("#txtValorTotal" + itemNum).val(cantidad * valorUnit);
                calcularTotal(itemNum);
            }
        });
    });

    $("#AgregarFacturaCrear").click(function () {
        debugger;
        var from = $("#formCrear").serializeArray();
        Fecha = from[0]["value"];
        IdEstado = from[1]["value"];
        IdCliente = from[2]["value"];        
        ValorTotal = from[3]["value"];    
        Autoretenedor = $("#AutoRetenedor").is(":checked");
        var itemNum = $("#tablaDetalleFactura >tbody >tr").length;
        if (Fecha == "" || Autoretenedor == "" || IdEstado == "" || IdCliente == "" || ValorTotal == "" || itemNum==0) {
            return;
        }
        var json = "{Fecha:'" + Fecha + "',Autoretenedor:'" + Autoretenedor + "',IdCliente:'" + IdCliente + "',IdEstado:'" + IdEstado + "',ValorTotal:'" + ValorTotal+"'}";
        $.ajax({
            type: "POST",
            url: "facturas.aspx/CrearFactura",
            data: json,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {     
                debugger;
                var json = jQuery.parseJSON(response.d);
               var numFactura = json.NumeroFactura;
                GuardarDetalles(numFactura);
                               
            },
            error: function (result) {
                alert('ERROR ' + result.status + ' ' + result.statusText);
            }
        });

    });

    $("#AgregarFacturaActualizar").click(function () {
        debugger;
        var from = $("#formActualizar").serializeArray();
        IdFactura = from[0]["value"];
        Fecha = from[1]["value"];
        IdEstado = from[2]["value"];
        IdCliente = from[3]["value"];
        ValorTotal = from[4]["value"];
        Autoretenedor = $("#AutoRetenedorActualizar").is(":checked");
        var itemNum = $("#tablaDetalleFacturaActualizar >tbody >tr").length;
        if (Fecha == "" || IdEstado == "" || IdCliente == "" || ValorTotal == "" || itemNum == 0) {
            return;
        }
        var json = "{NumeroFactura:'" + IdFactura+"',Fecha:'" + Fecha + "',Autoretenedor:'" + Autoretenedor + "',IdCliente:'" + IdCliente + "',IdEstado:'" + IdEstado + "',ValorTotal:'" + ValorTotal + "'}";
        $.ajax({
            type: "POST",
            url: "facturas.aspx/ActualizarFactura",
            data: json,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {
                debugger;
                GuardarDetallesActualizar(IdFactura);

            },
            error: function (result) {
                alert('ERROR ' + result.status + ' ' + result.statusText);
            }
        });

    });
    GetAllFacturas();
    GetAllClientes();
    GetAllEstados();



    



});

function calcularTotal(totalRows) {
    var total=0;
    for (var i = 1; i <= totalRows; i++) {
        total = parseFloat(total) + parseFloat($("#txtValorTotal" + i).val());
    }
    $("#txtValorTotalCrear").val(total);
}


//Get all Facturas
function GetAllFacturas() {
    $('#tablaFacturas tbody').html('');
    $.ajax({
        type: "POST",
        url: "facturas.aspx/GetAllFacturas",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var item = "";
            $.each(response.d, function (key, value) {
                if (value.Autoretenedor) {
                    var HtmlAutoretenedor = '<div class="ckbox ckbox-danger"><input type="checkbox"  checked= "checked" disabled="disabled" /><label for="checkboxDanger"> </label></div>';
                } else {
                    var HtmlAutoretenedor = '<div class="ckbox ckbox-danger"><input type="checkbox"   disabled="disabled" /><label for="checkboxDanger"> </label></div> ';
                }
                item += "<tr><td>" + value.NumeroFactura + "</td><td>" + value.Fecha + "</td><td>" + HtmlAutoretenedor + "</td><td>" + value.Estado + "</td><td>" + value.NombreCliente + "</td><td>$" + value.ValorTotal + "</td><td>  <a class='editFact' data-id='" + value.NumeroFactura + "'><i class='fa fa-pencil'></i></a> </i></a></td></td></tr>";

            });
            
            console.log(item);
            $('#tablaFacturas tbody').append(item);
            $(".editFact").click(function () {
                var numFact = $(this).attr("data-id");
                cargarEditarFactura(numFact);
            });
        },
        error: function (result) {
            alert('ERROR ' + result.status + ' ' + result.statusText);
        }
    });


};

function cargarEditarFactura(numFactura) {
    $("#modalActualizarFactura").modal("show");
    $(".otrasFilas").remove();
    $.ajax({
        type: "POST",
        url: "facturas.aspx/GetFactura",
        data: "{Id:'" + numFactura+"'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            console.log(response.d);
            var dateString = response.d.Fecha.substr(6);
            var currentTime = new Date(parseInt(dateString));
            var month = currentTime.getMonth() + 1;
            var day = currentTime.getDate();
            var year = currentTime.getFullYear();
            var date = day + "/" + month + "/" + year;
            $("#txtFechaActualizar").val(date);
            $('#EstadoSelectActualizar').val(response.d.IdEstado).change();
            $('#clienteSelectActualizar').val(response.d.IdCliente).change();
            $("#NumeroFacturaActualizar").text(response.d.NumeroFactura);
            $("#txtValorSumaTotalActualizar").val(response.d.ValorTotal);
            $("#txtIdFacturaActualizar").val(response.d.NumeroFactura);
            $("#AutoRetenedorActualizar").attr('checked', response.d.Autoretenedor);
            CargarDetalleFactura(numFactura);
        },
        error: function (result) {
            alert('ERROR ' + result.status + ' ' + result.statusText);
        }
    });


}

function CargarDetalleFactura(numeroFactura) {
    $.ajax({
        type: "POST",
        url: "facturas.aspx/GetFacturaDetalle",
        data: "{Id:'" + numeroFactura + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            console.log(response.d);

            $.each(response.d, function (key, value) {
                debugger;
                var itemNum = $("#tablaDetalleFacturaActualizar >tbody >tr").length;
                itemNum++;
                var item = "";
                item += "<tr class='otrasFilas'>";
                item += '<td><input value="' + value.Descripcion +'" type="text" class="form-control txtDescripcionActualizar" id="txtDescripcionActualizar' + itemNum + '" name="Descripcion' + itemNum + '" required  maxlength="50"></td>';
                item += '<td><input value="' + value.Cantidad +'" type="text" class="form-control txtCantidadActualizar input-number" id="txCantidadActualizar' + itemNum + '" name="Cantidad' + itemNum + '" required ></td>';
                item += '<td><input value="' + value.ValorUnitario +'" type="text" class="form-control txtValorUnitarioActualizar input-number" id="txtValorUnitarioActualizar' + itemNum + '" name="ValorUnitario' + itemNum + '" required ></td>';
                item += '<td><input value="' + value.ValorTotal +'" type="text" class="form-control txtValorTotalActualizar input-number" id="txtValorTotalActualizar' + itemNum + '"  name="ValorTotal' + itemNum + '" ></td>';
                item += '<td>  <a  class="delete-row deleteRowActualizar" > <i class="fa fa-trash-o"></i></a> </td>';
                item += "</tr>";
                $('#tablaDetalleFacturaActualizar tbody').append(item);

                
                $("#txtValorUnitarioActualizar" + itemNum).blur(function () {
                    var cantidad = $("#txCantidadActualizar" + itemNum).val();
                    var valorUnit = $("#txtValorUnitarioActualizar" + itemNum).val();
                    if (cantidad != "" && valorUnit != "") {
                        $("#txtValorTotalActualizar" + itemNum).val(cantidad * valorUnit);
                        calcularTotalActualizar(itemNum);
                    }
                });
                $("#txCantidadActualizar" + itemNum).blur(function () {
                    var cantidad = $("#txCantidadActualizar" + itemNum).val();
                    var valorUnit = $("#txtValorUnitarioActualizar" + itemNum).val();
                    if (cantidad != "" && valorUnit != "" && cantidad != undefined && valorUnit != undefined) {
                        $("#txtValorTotalActualizar" + itemNum).val(cantidad * valorUnit);
                        calcularTotalActualizar(itemNum);
                    }
                });
            });
            $('.input-number').on('input', function () {
                this.value = this.value.replace(/[^0-9]/g, '');
            });
            $(".deleteRowActualizar").live('click', function (event) {
                $(this).closest('tr').remove();
                var itemNum = $("#tablaDetalleFacturaActualizar >tbody >tr").length;
                calcularTotalActualizar(itemNum);
            });



        },
        error: function (result) {
            alert('ERROR ' + result.status + ' ' + result.statusText);
        }
    });
}


function calcularTotalActualizar(totalRows) {
    var total = 0;
    for (var i = 1; i <= totalRows; i++) {
        total = parseFloat(total) + parseFloat($("#txtValorTotalActualizar" + i).val());
    }
    $("#txtValorSumaTotalActualizar").val(total);
}

function GuardarDetalles(numFactura) {
    $('#tablaDetalleFactura tr').each(function (index, element) {
        debugger;

        var Descripcion = $(element).find(".txtDescripcion").val();
        var cantidad = $(element).find(".txtCantidad").val();
        var valorunitario = $(element).find(".txtValorUnitario").val();
        var valorTotal = $(element).find(".txtValorTotal").val();

        if (Descripcion != undefined && cantidad != undefined && valorunitario != undefined && valorTotal != undefined) {

            var json = "{IdFactura:'" + numFactura + "',Cantidad:'" + cantidad + "',Descripcion:'" + Descripcion + "',ValorTotal:'" + valorTotal + "',ValorUnitario:'" + valorunitario + "'}";
            $.ajax({
                type: "POST",
                url: "facturas.aspx/GrabarDetalle",
                data: json,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (response) {
                    GetAllFacturas();
                    $("#modalCrearFactura").modal("hide");
                },
                error: function (result) {
                    alert('ERROR ' + result.status + ' ' + result.statusText);
                }
            });
        }

    });
}

function GuardarDetallesActualizar(numFactura) {
    $('#tablaDetalleFacturaActualizar tr').each(function (index, element) {
        debugger;

        var Descripcion = $(element).find(".txtDescripcionActualizar").val();
        var cantidad = $(element).find(".txtCantidadActualizar").val();
        var valorunitario = $(element).find(".txtValorUnitarioActualizar").val();
        var valorTotal = $(element).find(".txtValorTotalActualizar").val();

        if (Descripcion != undefined && cantidad != undefined && valorunitario != undefined && valorTotal != undefined) {

            var json = "{IdFactura:'" + numFactura + "',Cantidad:'" + cantidad + "',Descripcion:'" + Descripcion + "',ValorTotal:'" + valorTotal + "',ValorUnitario:'" + valorunitario + "'}";
            $.ajax({
                type: "POST",
                url: "facturas.aspx/ActualizarDetalle",
                data: json,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (response) {
                    GetAllFacturas();
                    $("#modalActualizarFactura").modal("hide");
                },
                error: function (result) {
                    alert('ERROR ' + result.status + ' ' + result.statusText);
                }
            });
        }

    });
}


//Get all Clientes
function GetAllClientes() {

    $.ajax({
        type: "POST",
        url: "facturas.aspx/GetAllClientes",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {

            console.log(response);
           // var listItems = '<option selected="selected" value="0">- Select -</option>';
            var listItems = '';
            $.each(response.d, function (key, value) {
                listItems += "<option value='" + value.Id + "'>" + value.Nombre + " " + value.Apellidos+ "</option>";
            });
            $("#clienteSelectCrear").html(listItems);
            $("#clienteSelectActualizar").html(listItems);
            $('.chosen-select').trigger('chosen:updated');
        },
        error: function (result) {
            alert('ERROR ' + result.status + ' ' + result.statusText);
        }
    });

}


//Get all Estados
function GetAllEstados() {
    $.ajax({
        type: "POST",
        url: "facturas.aspx/GetAllEstados",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            console.log(response);
            var listItems = '';
            $.each(response.d, function (key, value) {
                listItems += "<option value='" + value.Id + "'>" + value.Descripcion + "</option>";
            });
            $("#EstadoSelectCrear").html(listItems);
            $("#EstadoSelectActualizar").html(listItems);
        },
        error: function (result) {
            alert('ERROR ' + result.status + ' ' + result.statusText);
        }
    });

}