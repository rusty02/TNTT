'use strict';

// public variables
toastr.options = {
    "closeButton": false,
    "debug": false,
    "positionClass": "toast-bottom-right",
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
};
var mien = {
    data: [{
        id: '1',
        name: 'Miền Tây Bắc'
    }, {
        id: '2',
        name: 'Miền Tây'
    }, {
        id: '3',
        name: 'Miền Tây Nam'
    }, {
        id: '4',
        name: 'Miền Nam'
    }, {
        id: '5',
        name: 'Miền Trung'
    }, {
        id: '6',
        name: 'Miền Trung Đông'
    }, {
        id: '7',
        name: 'Miền Đông Bắc'
    }, {
        id: '8',
        name: 'Miền Đông Nam'
    }]
};
var role = {
    data: [{
        id: '1',
        name: 'Tuyên Úy'
    }, {
        id: '2',
        name: 'Trợ Úy'
    }, {
        id: '3',
        name: 'Trợ Tá'
    }, {
        id: '4',
        name: 'Huynh Trưởng'
    }, {
        id: '5',
        name: 'Huấn Luyện Viên'
    }]
};

var tnttApp = angular.module('tntt', ["google-maps"]).
    config(function ($routeProvider) {
        $routeProvider.when("", {
            controller: "HomeController",
            templateUrl: "/templates/homeView.html"
        });
        $routeProvider.when("/locate", {
            //controller: "locateController",
            templateUrl: "/templates/locateView.html"
        });
    
        $routeProvider.when("/members", {
            //controller: "membersController",
            templateUrl: "/templates/membersView.html"
        });
    
        $routeProvider.when("/doans", {
            //controller: "doansController",
            templateUrl: "/templates/doansView.html"
        });
        $routeProvider.when("/miens", {
            //controller: "miensController",
            templateUrl: "/templates/miensView.html"
        });
        $routeProvider.when("/truongUongs", {
            //controller: "miensController",
            templateUrl: "/templates/trunguongsView.html"
        });
    
        $routeProvider.when("/login", {
            controller: "loginController",
            templateUrl: "/templates/loginView.html"
        });
    
        $routeProvider.when("/addMember", {
            //controller: "addMemberController",
            templateUrl: "/templates/addMemberView.html"
        });
    
        $routeProvider.when("/member/:id", {
            //controller: "singleMemberController",
            templateUrl: "/templates/editMemberView.html"
        });

        $routeProvider.otherwise({ redirectTo: "/"});
});
