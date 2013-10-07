'use strict';

tnttApp.controller('DoanListController', function DoanListController($scope, $http, doanData) {
        $scope.data = doanData;
        $scope.isBusy = false;

        if (doanData.doansReady() == false) {
            $scope.isBusy = true;
            doanData.getDoans()
          .then(function () {
              //success
              toastr.success('Retrieved [Doans] from remote data source');
          },
          function (error) {
              //error
              toastr.error(error.data);
          })
          .then(function () {
              $scope.isBusy = false;
          });
        }
    }
);