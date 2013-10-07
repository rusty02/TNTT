'user strict';

tnttApp.factory('memberData', function ($http, $q) {
    var _members = [];
    var _isInit = false;
    var _isReady = function () {
        return _isInit;
    };

    var _getMembers = function () {
        var deferred = $q.defer();
        var convertToUTC = function (dt) {
            var localDate = new Date(dt);
            var localTime = localDate.getTime();
            var localOffset = localDate.getTimezoneOffset() * 60000;
            return new Date(localTime + localOffset);
        };

        $http.get("api/member")
            .then(function (result) {
                //Successful
                angular.copy(result.data, _members);
                _isInit = true;

                deferred.resolve(_members);
            },
            function (error) {
                //Error
                deferred.reject(error);
            });
        return deferred.promise;
    };
    var _addMember = function (newMember) {
        var deferred = $q.defer();

        $http.post("/api/member", newMember)
            .then(function (result) {
                //success
                var newlyMember = result.data;
                //merge with existing list of member
                // get Role
                $.each(role.data, function (i, item) {
                    if (item.id == result.data.role) {
                        result.data.role = item.name;
                    }
                });

                _members.push(newlyMember);
                deferred.resolve(newlyMember);
            },
            function (error) {
                // error
                deferred.reject(error);
            });

        return deferred.promise;
    };
    function _findMember(id) {
        var found = null;

        $.each(_members, function (i, item) {
            if (item.id == id) {
                found = item;
                return false;
            }

        });

        return found;
    }

    var _getMemberById = function (id) {
        var deferred = $q.defer();

        if (_isReady()) {
            var member = _findMember(id);
            if (member) {
                deferred.resolve(member);
            } else {
                deferred.reject();
            }
        } else {
            $http.get("api/member/" + id)
                .then(function (data) {
                    //success
                    var member = data;
                    if (member) {
                        deferred.resolve(member.data);
                    } else {
                        deferred.reject();
                    }
                },
                function () {
                    //failure
                    deferred.reject();
                });
        }

        return deferred.promise;
    };

    var _getDoanByMienId = function (id) {
        var deferred = $q.defer();
        $http.get("api/doan/getbymienid", { params: { id: id, flag: true } })
            .then(function (doans) {
                //success
                if (doans.data.length > 0) {
                    deferred.resolve(doans);
                } else {
                    deferred.reject();
                }
            },
            function (error) {
                //failure
                deferred.reject(error);
            });
        return deferred.promise;
    };

    var _saveMember = function (member) {
        var deferred = $q.defer();

        $http.put("/api/member/", member)
            .then(function () {
                //success
                deferred.resolve(member);
            },
            function (error) {
                //error
                deferred.reject(error);
            });

        return deferred.promise;
    };

    return {
        members: _members,
        getMembers: _getMembers,
        addMember: _addMember,
        isReady: _isReady,
        getMemberById: _getMemberById,
        saveMember: _saveMember,
        getDoanByMienId: _getDoanByMienId,
    };
});
