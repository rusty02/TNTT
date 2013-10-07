'use strict';

tnttApp.controller('LocationController', function LocationController($scope) {
        $scope.userAddress = "test";
        $scope.geolocationAvailable = navigator.geolocation ? true : false;
        $scope.markers = [];
        $scope.zoom = 8;
        google.maps.visualRefresh = true;

        angular.extend($scope, {
            position: {
                coords: {
                    latitude: 0,
                    longitude: 0
                }
            },

            /** the initial center of the map */
            centerProperty: {
                latitude: 0,
                longitude: 0
            },

            /** the initial zoom level of the map */
            zoomProperty: $scope.zoom,

            /** list of markers to put in the map */
            markersProperty: [],
        });

        var icon = {
            url: 'http://developerdrive.developerdrive.netdna-cdn.com/wp-content/uploads/2013/08/ddrive.png'
        };

        if ($scope.geolocationAvailable) {

            navigator.geolocation.getCurrentPosition(function (position) {
                //alert(position.coords.latitude);

            });

            if ($scope.geolocationAvailable) {

                navigator.geolocation.getCurrentPosition(function (position) {

                    $scope.position.coords = {
                        latitude: position.coords.latitude,
                        longitude: position.coords.longitude
                    };
                    $scope.markersProperty.push({
                        latitude: position.coords.latitude,
                        longitude: position.coords.longitude,
                        icon: icon,
                    });

                    $scope.$apply();
                }, function () {
                });
            }

            //google.maps.event.addListener($scope.markers, 'click', function () {
            //    var lng = points[i].longitue,
            //        lat = points[i].latitude;
            //    alert(lat + "-" + lng);
            //});
        }
    }
);