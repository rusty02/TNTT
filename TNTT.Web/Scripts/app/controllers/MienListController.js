'use strict';

tnttApp.controller('MienListController', function MienListController($scope, $http, mienData) {
        $scope.data = mienData;
        $scope.isBusy = false;

        if (mienData.miensReady() == false) {
            $scope.isBusy = true;
            mienData.getMiens()
          .then(function () {
              //success
              toastr.success('Retrieved [Miens] from remote data source');
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