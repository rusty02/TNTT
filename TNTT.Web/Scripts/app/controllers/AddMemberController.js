'use strict';

tnttApp.controller('AddMemberController', function AddMemberController($scope, $http, $window, memberData) {
        $scope.newMember = {};
        $scope.mienList = mien;
        $scope.doanList = { data: [] };
        $scope.roleList = role;

        $scope.roleSelected = '4';
        $scope.mienSelected = '1';
        $scope.doanSelected = '0';


        memberData.getDoanByMienId($scope.mienSelected).
        then(function (doans) {
            //success
            $.each(doans.data, function (i, item) {
                $scope.doanList.data.push({ name: item.name });
            });
            //$scope.doanSelected = 1;
            toastr.success('Doan list updated successfully');
            //  $window.location = "#/home";
        },
        function (error) {
            //error
            toastr.error(error.data);
        });
    
        $scope.updateDoanlist = function () {
            $scope.doanList = { data: [] };

            memberData.getDoanByMienId($scope.mienSelected)
              .then(function (doans) {
                  //success
                  $.each(doans.data, function (i, item) {
                      $scope.doanList.data.push({ name: item.name });
                  });
                  $scope.doanSelected = 1;
                  toastr.success('Doan list updated successfully');
                  // $window.location = "#/members";
              },
               function (error) {
                   //error
                   toastr.error(error.data);
               });
        };

        $scope.saveMember = function (newMember, newMemberForm) {
            if (newMemberForm.$valid) { // check if the form is valid
                $scope.newMember.role = $scope.roleSelected;
                $scope.newMember.doanName = $('#selDoan option:selected').text();
                $scope.newMember.mienName = $('#selMien option:selected').text();
                $scope.newMember.mienId = $scope.mienSelected;
                //    $scope.newMember.doanId = 1;

                dataService.addMember($scope.newMember)
                    .then(function () {
                        //success
                        toastr.success('New member added succcessfully');
                        //  $window.location = "#/home";
                    },
                    function (error) {
                        //error
                        toastr.error(error.data);
                    });
            }
        };
    
        $scope.cancelAdd = function () {
            window.location = "/#/members";
        };
    }
);