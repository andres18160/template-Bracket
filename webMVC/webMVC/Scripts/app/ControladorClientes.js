app.controller("ControladorClientes", function ($scope,$http) {

    $scope.clientes = [];
    $scope.newCliente = {};
    $scope.updateCliente = {};
    $scope.IdEdit = "";
    $scope.DeleteClient = {};

    cargarClientes();


    $scope.crearCliente = function () {
        debugger;
        if ($scope.formCrear.$valid) {
            $http({
                method: 'POST',
                url: '/api/cliente',
                data:$scope.newCliente
            }).then(function (data, status, headers, config) {
                debugger;
                console.log(data);
                $scope.newCliente = {};
                $scope.formCrear.$setPristine();
                $("#ModalAgregar").modal("hide");
                jQuery.gritter.add({
                    title: 'Notificación',
                    text: 'El cliente se registro sin problemas',
                    class_name: 'growl-success',
                    sticky: false,
                    time: ''
                });
                   cargarClientes();

                }, function (error, status, headers, config) {
                    config.log(error);
                });
          
        }
    }
    $scope.CargarEliminarCliente = function (Id) {
        debugger;
        jQuery.grep($scope.clientes, function (obj) {
            if (obj.Id === Id)
                $scope.DeleteClient = obj;
            $("#ModalDelete").modal("show");
        });
    }


    $scope.CargarUpdateCliente = function (Id) {
        jQuery.grep($scope.clientes, function (obj) {
            if (obj.Id === Id)
                $scope.updateCliente = obj;
            $("#ModalActualizar").modal("show");
        });
    }

    $scope.ActualizarCliente = function () {
        debugger;
        if ($scope.formActualizar.$valid) {
            $http({
                method: 'PUT',
                url: '/api/cliente/' + $scope.updateCliente.Id,
                data: $scope.updateCliente
            }).then(function (data, status, headers, config) {
                debugger;
                console.log(data);
                $scope.newCliente = {};
                $scope.formActualizar.$setPristine();
                $("#ModalActualizar").modal("hide");
                cargarClientes();

            }, function (error, status, headers, config) {
                config.log(error);
            });
        }
    }

    $scope.EliminarCliente=function() {
        debugger;
        $http({
            method: 'DELETE',
            url: '/api/cliente/' + $scope.DeleteClient.Id
        }).then(function (success) {
            debugger;
            console.log(success);
            $("#ModalDelete").modal("hide");
            jQuery.gritter.add({
                title: 'Notificación',
                text: 'El cliente se Elimino sin problemas',
                class_name: 'growl-danger',
                sticky: false,
                time: ''
            });
            cargarClientes();

        }, function (error) {

        });
    }

    function cargarClientes () {
        debugger;
        $http({
            method: 'GET',
            url: '/api/cliente'
        }).then(function (success) {
            debugger;
            console.log(success.data);
            $scope.clientes = success.data;
        }, function (error) {

        });
    }


});