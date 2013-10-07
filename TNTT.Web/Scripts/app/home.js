// home.js

function loginController($scope, $http) {
    getExternalLogins("/", true).done(function(data) {
        if (typeof (data) === "object") {
            alert('add data');
        } else {
            alert('error');
        }
    });
}


// Other private operations
function getExternalLogins(returnUrl, generateState) {
    return $.ajax(externalLoginsUrl(returnUrl, generateState), {
        cache: false,
        headers: getSecurityHeaders()
    });
};

function externalLoginsUrl(returnUrl, generateState) {
    return "/api/Account/ExternalLogins?returnUrl=" + (encodeURIComponent(returnUrl)) +
        "&generateState=" + (generateState ? "true" : "false");
}

function getUserInfo(accessToken) {
    var headers;

    if (typeof (accessToken) !== "undefined") {
        headers = {
            "Authorization": "Bearer " + accessToken
        };
    } else {
        headers = getSecurityHeaders();
    }

    return $.ajax(userInfoUrl, {
        cache: false,
        headers: headers
    });
};

function getSecurityHeaders() {
    var accessToken = sessionStorage["accessToken"] || localStorage["accessToken"];

    if (accessToken) {
        return { "Authorization": "Bearer " + accessToken };
    }

    return {};
}

//homeController.$inject = ['$scope', '$http']; // <-- resolves minifier issue