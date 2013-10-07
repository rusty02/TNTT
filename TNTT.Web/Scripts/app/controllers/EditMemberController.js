'use strict';

tnttApp.controller('EditMemberController', function EditMemberController($scope, memberData, $window, $routeParams, $filter) {
        $scope.mienList = mien;
        $scope.roleList = role;
        $scope.mienSelected = '';
        $scope.roleSelected = '';

        memberData.getMemberById($routeParams.id)
            .then(function (member) {
                //success

                // set the selected Mien
                $scope.mienSelected = member.mienId.toString();

                //set the selected Role
                $scope.roleSelected = member.role.toString();

                //filter member date of birth
                member.dateOfBirth = $filter('date')(member.dateOfBirth, 'MM/dd/yyyy');
                $scope.member = member; // setting the scope variable for UI binding
            },
            function () {
                //error
                $window.location = "#/home";
            });
        $scope.saveMember = function (member, editMemberForm) {

            if (editMemberForm.$valid) { // check if the form is valid
                member.mienId = $scope.mienSelected;
                member.role = $scope.roleSelected;
                memberData.saveMember($scope.member, $scope.saveMember)
                    .then(function (member) {
                        //success

                        toastr.success('Member saved succcessfully');
                        $window.location = "#/members";
                    },
                    function (error) {
                        //error
                        toastr.error(error.data);
                    });
            }
        };
        $scope.cancelEdit = function () {
            window.location = "/#/members";
        };
    }
);