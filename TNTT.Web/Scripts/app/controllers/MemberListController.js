'use strict';

tnttApp.controller('MemberListController', function MemberListController($scope, $http, memberData, miensFilter) {
        $scope.author = "Phung Nguyen";
        $scope.data = memberData;
        $scope.isBusy = false;
        $scope.data.test = 1;
    
        if (memberData.isReady() == false) {
            $scope.isBusy = true;
            memberData.getMembers()
              .then(function () {
                  //success
                  toastr.success('Retrieved [Members] from remote data source');
              },
              function (error) {
                  //error
                  toastr.error(error.data);
              })
              .then(function () {
                  $scope.isBusy = false;
              });
        } else {
            $scope.data = $scope.data;
            $scope.data.test = miensFilter(1);
            //$scope.isBusy = true;
            //memberData.getMembers()
            //  .then(function () {
            //      //success
            //      toastr.success('Retrieved [Members] from remote data source');
            //  },
            //  function (error) {
            //      //error
            //      toastr.error(error.data);
            //  })
            //  .then(function () {
            //      $scope.isBusy = false;
            //  });

        }
    
        $scope.clearSearch = function () {
            $scope.searchMember = '';
        };
    }
);