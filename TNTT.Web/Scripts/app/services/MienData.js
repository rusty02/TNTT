'user strict';

tnttApp.factory('mienData', function ($http, $q) {

    var _miens = [];
    var _miensInit = false;
    var _miensReady = function () {
        return _miensInit;
    };
   
    var _getMiens = function () {
        var deferred = $q.defer();

        $http.get("api/mien")
            .then(function (result) {
                //Successful
                angular.copy(result.data, _miens);
                _miensInit = true;

                deferred.resolve(_miens);
            },
            function (error) {
                //Error
                deferred.reject(error);
            });
        return deferred.promise;
    };

    return {
        miensReady: _miensReady,
        miens: _miens,
        getMiens: _getMiens
    };
});
