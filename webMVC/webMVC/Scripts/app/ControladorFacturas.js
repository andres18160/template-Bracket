app.controller("ControladorFacturas", function ($scope, $http) {

    $scope.facturas = [];
    $scope.estados = [];
    $scope.clientes = [];
    $scope.newFactura = {};
    $scope.updateFactura = {};
    $scope.IdEdit = "";
    $scope.DeleteFactura = {};

    $scope.rows = [];
    $scope.counter = 1;




    cargarFacturas();
    cargarEstados();
    cargarClientes();


    $scope.loadModalCrear = function () {
        $("#modalCrearFactura").modal("show");
    }

    $scope.addRow = function () {
        $scope.Newrow = {
            Id: '',
            IdFactura: '',
            Descripcion: '',
            Cantidad: 0,
            ValorUnitario: 0,
            ValorTotal: 0
        };

        $scope.Newrow.Id = $scope.counter;
        $scope.rows.push($scope.Newrow);
        $scope.counter++;
    }

    $scope.removeRow = function (Id) {
        var newDataList = [];
        angular.forEach($scope.rows, function (v) {
            if (v.Id!=Id) {
                newDataList.push(v);
            }
        }); $scope.rows = newDataList;
    }

    $scope.crearFactura = function () {
        debugger;
        if ($scope.formCrearFactura.$valid) {
            $http({
                method: 'POST',
                url: '/api/factura',
                data: $scope.newFactura
            }).then(function (data, status, headers, config) {
                debugger;
                console.log(data);
                $scope.newFactura = {};
                $scope.formCrear.$setPristine();
                $("#modalCrearFactura").modal("hide");
                jQuery.gritter.add({
                    title: 'Notificación',
                    text: 'La Factura fue resgistrada.',
                    class_name: 'growl-success',
                    sticky: false,
                    time: ''
                });
                cargarFacturas();

            }, function (error, status, headers, config) {
                config.log(error);
            });

        }
    }

    function cargarFacturas() {

        $http({
            method: 'GET',
            url: '/api/factura'
        }).then(function (success) {
            console.log(success.data);
            $scope.facturas = success.data;
        }, function (error) {

        });
    }


    function cargarEstados() {

        $http({
            method: 'GET',
            url: '/api/estado'
        }).then(function (success) {
            console.log(success.data);
            $scope.estados = success.data;
        }, function (error) {

        });
    }

    function cargarClientes() {

        $http({
            method: 'GET',
            url: '/api/cliente'
        }).then(function (success) {
            console.log(success.data);
            $scope.clientes = success.data;
        }, function (error) {

        });
    }

});


