'use strict';

tnttApp.controller('TrungUongListController', function TrungUongListController($scope, $http, trungUongData) {
        $scope.data = trungUongData;
        $scope.isBusy = false;

        if (trungUongData.trungUongsReady() == false) {
            $scope.isBusy = true;
            trungUongData.getTruongUongs()
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