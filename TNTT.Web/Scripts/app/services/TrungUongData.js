'user strict';

tnttApp.factory('trungUongData', function ($http, $q) {

    var _trungUongs = [];
    var _trungUongsInit = false;
    var _trungUongsReady = function () {
        return _trungUongsInit;
    };
   
    var _getTruongUongs = function () {
        var deferred = $q.defer();

        $http.get("api/trungUong")
            .then(function (result) {
                //Successful
                angular.copy(result.data, _trungUongs);
                _trungUongsInit = true;

                deferred.resolve(_trungUongs);
            },
            function (error) {
                //Error
                deferred.reject(error);
            });
        return deferred.promise;
    };

    return {
        trungUongsReady: _trungUongsReady,
        trungUongs: _trungUongs,
        getTruongUongs: _getTruongUongs
    };
});
