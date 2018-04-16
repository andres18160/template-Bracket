jQuery(document).ready(function () {
    jQuery("#formLogin").validate({
        highlight: function (element) {
            jQuery(element).closest('.form-group').removeClass('has-success').addClass('has-error');
        },
        success: function (element) {
            jQuery(element).closest('.form-group').removeClass('has-error');
        }
    });
    //$('#bntLogin').click(function () {
    //    var usuario = $('#Usuario').val();
    //    var clave = $('#Contraseña').val();


    //    var json = "{ usuario: '" + usuario + "',clave:'" + clave + "'}";
    //    $.ajax({
    //        type: "POST",
    //        url: "login.aspx/ValidarUsuario",
    //        data: json,
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",
    //        success: function (response) {
    //            console.log(response);
    //            alert(response.d);
    //        },
    //        error: function (result) {
    //            alert('ERROR ' + result.status + ' ' + result.statusText);
    //        }
    //    }); 
    //});
}); 