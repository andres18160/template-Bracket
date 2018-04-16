jQuery(document).ready(function () {
    $('#liAdminUsuarios').addClass('active');

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




    /*
    $('#tablaUsuarios').dataTable({
        "sPaginationType": "full_numbers",
    });*/

    cargarListaUsuarios();

    $('#delete').click(function () {
        debugger;
        id = $(this).attr("data-id");
        var json = "{ Id: '" + id + "'}";
        $.ajax({
            type: "POST",
            url: "usuarios_admin.aspx/EliminarUsuario",
            data: json,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                debugger;
                console.log(response);
                if (response.d == "OK") {
                    $("#ModalDelete").modal("hide");
                    cargarListaUsuarios();

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
    $("#ActualizarUsuario").click(function () {
        var Id = $('#txtIdActualizar').val();
        var Nombre = $('#txtNombreActualizar').val();
        var Usuario = $('#txtUsuarioActualizar').val();
        var Password = $('#txtPasswordActualizar').val();

        if (Nombre == "" || Usuario == "" || Password==""){
        return;
    }

    var json = "{ Id: '" + Id + "',Nombre: '" + Nombre + "',Usuario:'" + Usuario + "',Password:'" + Password + "' }";
    $.ajax({
        type: "POST",
        url: "usuarios_admin.aspx/ActualizarUsuario",
        data: json,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log(response.d);
            debugger;
            if (response.d == "OK") {
                $("#ModalActualizar").modal("hide");
                $("#lblMensajeActualizar").text("");
                cargarListaUsuarios();
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

$("#AgregarUsuario").click(function () {
    var Nombre = $('#txtNombre').val();
    var Usuario = $('#txtUsuario').val();
    var Password = $('#txtPassword').val();

    var json = "{ Nombre: '" + Nombre + "',Usuario:'" + Usuario + "',Password:'" + Password + "' }";
    $.ajax({
        type: "POST",
        url: "usuarios_admin.aspx/CrearUsuario",
        data: json,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log(response.d);
            debugger;
            if (response.d == "OK") {
                $("#ModalAgregar").modal("hide");
                $("#lblMensaje").text("");
                cargarListaUsuarios();
                $('#txtNombre').val("");
                $('#txtUsuario').val("");
                $('#txtPassword').val("");
            } else if (response.d == "NO") {
                $("#lblMensaje").text("Error creando el usuario. ");
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


function cargarListaUsuarios() {
    $(".otrasFilas").remove();
    var row = '<tr>' +
        $.ajax({
            type: "POST",
            url: "usuarios_admin.aspx/CargarUsuarios",
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                console.log(response);
                $.each(response.d, function (i, item) {
                    row += '<tr class="otrasFilas">' +
                        '<td>' + item.Id + '</td>' +
                        '<td>' + item.Nombre + '</td>' +
                        '<td>' + item.Usuario + '</td>' +
                        '<td>  <a class="edituser"><i class="fa fa-pencil"></i></a><a  class="delete-row deleteuser" > <i class="fa fa-trash-o"></i></a></td>' +
                        '</tr>';
                });
                $("#tablaUsuarios tbody").append(row);

                $(".edituser").click(function () {
                    debugger;
                    id = $(this).parents("tr").find("td").eq(0).html();
                    Nombre = $(this).parents("tr").find("td").eq(1).html();
                    usuario = $(this).parents("tr").find("td").eq(2).html();
                    $("#myModalActualizar").text("Actualizar usuario " + Nombre + " (" + usuario + ")");
                    $("#txtIdActualizar").val(id);
                    $("#txtNombreActualizar").val(Nombre);
                    $("#txtUsuarioActualizar").val(usuario);
                    $("#ModalActualizar").modal("show");
                });

                $('.deleteuser').click(function () {
                    id = $(this).parents("tr").find("td").eq(0).html();
                    Nombre = $(this).parents("tr").find("td").eq(1).html();
                    usuario = $(this).parents("tr").find("td").eq(2).html();
                    $("#labelDeleteUser").text(Nombre);
                    $("#delete").attr("data-id", id);
                    $("#ModalDelete").modal("show");
                });
            },
            error: function (result) {
                alert('ERROR ' + result.status + ' ' + result.statusText);
            }
        });


}