'user strict';

tnttApp.factory('doanData', function ($http, $q) {
    var _doans = [];
    var _doansInit = false;
    var _doansReady = function () {
        return _doansInit;
    };
    
    var _getDoans = function () {
        var deferred = $q.defer();

        $http.get("api/doan")
            .then(function (result) {
                //Successful
                angular.copy(result.data, _doans);
                _doansInit = true;

                deferred.resolve(_doans);
            },
            function (error) {
                //Error
                deferred.reject(error);
            });
        return deferred.promise;
    };

    
    return {
        doansReady: _doansReady,
        doans: _doans,
        getDoans: _getDoans,
    };
});
