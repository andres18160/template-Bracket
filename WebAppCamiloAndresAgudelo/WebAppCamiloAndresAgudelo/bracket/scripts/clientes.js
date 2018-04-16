jQuery(document).ready(function () {
    $('#liAdminClientes').addClass('active');


    jQuery("#formCrear").validate({
        highlight: function (element) {
            jQuery(element).closest('.form-group').removeClass('has-success').addClass('has-error');
        },
        success: function (element) {
            jQuery(element).closest('.form-group').removeClass('has-error');
        }
    });

    jQuery("#formActualizar").validate({
        highlight: function (element) {
            jQuery(element).closest('.form-group').removeClass('has-success').addClass('has-error');
        },
        success: function (element) {
            jQuery(element).closest('.form-group').removeClass('has-error');
        }
    });


    cargarListaClientes();



    $('#delete').click(function () {
        debugger;
        id = $(this).attr("data-id");
        var json = "{ Id: '" + id + "'}";
        $.ajax({
            type: "POST",
            url: "clientes.aspx/EliminarCliente",
            data: json,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                debugger;
                console.log(response);
                if (response.d == "OK") {
                    $("#ModalDelete").modal("hide");
                    cargarListaClientes();
                }

            },
            error: function (result) {
                alert('ERROR ' + result.status + ' ' + result.statusText);
            }
        });
    });

    $("#agregar").click(function () {
        $("#ModalAgregar").modal("show");
    });
    $("#ActualizarCliente").click(function () {
        var Id = $('#txtIdActualizar').val();
        var Nombre = $('#txtNombreActualizar').val();
        var Apellido = $('#txtApellidoActualizar').val();
        var Cedula = $('#txtCedulaActualizar').val();
        var Direccion = $('#txtDireccionActualizar').val();
        var Telefono = $('#txtTelefonoActualizar').val();
        if (Nombre == "" || Apellido == "" || Cedula == "" || Direccion == "" || Telefono == "") {
            return;
        }

        var json = "{ Id: '" + Id + "',Nombre: '" + Nombre + "',Apellido:'" + Apellido + "',Direccion:'" + Direccion + "',Telefono:'" + Telefono + "',Cedula:'" + Cedula + "' }";
        $.ajax({
            type: "POST",
            url: "clientes.aspx/ActualizarCliente",
            data: json,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                console.log(response.d);
                debugger;
                if (response.d == "OK") {
                    $("#ModalActualizar").modal("hide");
                    $("#lblMensajeActualizar").text("");
                    cargarListaClientes();
                    $('#txtIdActualizar').val("");
                    $('#txtNombreActualizar').val("");
                    $('#txtUsuarioActualizar').val("");
                    $('#txtPasswordActualizar').val("");
                } else if (response.d == "NO") {
                    $("#lblMensajeActualizar").text("Error creando el usuario. ");
                }

            },
            error: function (result) {
                $("#lblMensajeActualizar").text('ERROR ' + result.status + ' ' + result.statusText);
            }
        });
    });

    $("#AgregarCliente").click(function () {
        debugger;
        var Nombre = $('#txtNombre').val();
        var Apellido = $('#txtApellido').val();
        var Cedula = $('#txtCedula').val();
        var Direccion = $('#txtDireccion').val();
        var Telefono = $('#txtTelefono').val();
        if (Nombre == "" || Apellido == "" || Cedula == "" || Direccion == "" || Telefono == "") {
            return;
        }
        var json = "{ Nombre: '" + Nombre + "',Apellido:'" + Apellido + "',Direccion:'" + Direccion + "',Telefono:'" + Telefono + "',Cedula:'" + Cedula + "' }";
        $.ajax({
            type: "POST",
            url: "clientes.aspx/CrearCliente",
            data: json,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                console.log(response.d);
                debugger;
                if (response.d == "OK") {
                    $("#ModalAgregar").modal("hide");
                    cargarListaClientes();
                    $("#lblMensaje").text("");
                    $('#txtNombre').val("");
                    $('#txtApellido').val("");
                    $('#txtCedula').val("");
                    $('#txtDireccion').val("");
                    $('#txtTelefono').val("");
                } else if (response.d == "NO") {
                    $("#lblMensaje").text("Error creando el usuario. ");
                } else if (response.d ="EXISTE"){
                    $("#lblMensaje").text("El cliente ya existe. ");
                    $('#txtCedula').val("");
                    $('#txtCedula').focus();
                } else {
                    $("#lblMensaje").text(response.d);
                }

            },
            error: function (result) {
                $("#lblMensaje").text('ERROR ' + result.status + ' ' + result.statusText);
            }
        });
    });






});




function cargarListaClientes() {
    $(".otrasFilas").remove();
    var row = '<tr>' +
        $.ajax({
            type: "POST",
            url: "clientes.aspx/CargarClientes",
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                console.log(response);
                $.each(response.d, function (i, item) {
                    row += '<tr class="otrasFilas">' +
                        '<td>' + item.Id + '</td>' +
                        '<td>' + item.Nombre + '</td>' +
                        '<td>' + item.Apellidos + '</td>' +
                        '<td>' + item.cedula + '</td>' +
                        '<td>' + item.Direccion + '</td>' +
                        '<td>' + item.Telefono + '</td>' +
                        '<td>  <a class="edituser"><i class="fa fa-pencil"></i></a><a  class="delete-row deleteuser" > <i class="fa fa-trash-o"></i></a></td>' +
                        '</tr>';
                });
                $("#tablaClientes tbody").append(row);

                $(".edituser").click(function () {
                    debugger;
                    id = $(this).parents("tr").find("td").eq(0).html();
                    Nombre = $(this).parents("tr").find("td").eq(1).html();
                    apellidos = $(this).parents("tr").find("td").eq(2).html();
                    cedula = $(this).parents("tr").find("td").eq(3).html();
                    direccion = $(this).parents("tr").find("td").eq(4).html();
                    telefono = $(this).parents("tr").find("td").eq(5).html();
                    $("#myModalActualizar").text("Actualizar Cliente " + apellidos + " " + Nombre);
                    $("#txtIdActualizar").val(id);
                    $("#txtNombreActualizar").val(Nombre);
                    $("#txtApellidoActualizar").val(apellidos);
                    $("#txtCedulaActualizar").val(cedula);
                    $("#txtDireccionActualizar").val(direccion);
                    $("#txtTelefonoActualizar").val(telefono);
                    $("#ModalActualizar").modal("show");
                });

                $('.deleteuser').click(function () {
                    debugger;
                    id = $(this).parents("tr").find("td").eq(0).html();
                    Nombre = $(this).parents("tr").find("td").eq(1).html();
                    apellidos = $(this).parents("tr").find("td").eq(2).html();
                    $("#labelDeleteClient").text("Esta seguro de eliminar a " + Nombre + " " + apellidos);
                    $("#delete").attr("data-id", id);
                    $("#ModalDelete").modal("show");
                });
            },
            error: function (result) {
                alert('ERROR ' + result.status + ' ' + result.statusText);
            }
        });


}