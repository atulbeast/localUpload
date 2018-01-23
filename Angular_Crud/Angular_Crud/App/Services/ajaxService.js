angular.module('myApp').service('ajaxService', ['$http', function ($http) {

    // setting timeout of 1 second to simulate a busy server.

    this.AjaxPost = function (route, data) {
        $http.defaults.headers.post["Content-Type"] = "application/json; charset=UTF-8";
        return $http.post(route, data, { withCredentials: false });
    }

    this.AjaxPut = function (route, data) {
        $http.defaults.headers.put["Content-Type"] = "application/json; charset=UTF-8";
        return $http.put(route, data);
    }

    this.AjaxPostWithNoAuthenication = function (data, route, successFunction, errorFunction) {
       // blockUI.start();
        $http.post(route, data).success(function (response, status, headers, config) {
          //  blockUI.stop();

            successFunction(response, status);
        }).error(function (response) {
           // blockUI.stop();
            errorFunction(response);
        });
    }

    this.AjaxGet = function (route) {
        return $http({ method: 'GET', url: route });
    }

    this.AjaxGetWithData = function (data, route, successFunction, errorFunction) {
       // blockUI.start();
        setTimeout(function () {
            $http({ method: 'GET', url: route, params: data }).success(function (response, status, headers, config) {
            //    blockUI.stop();
                successFunction(response, status);
            }).error(function (response) {
               // blockUI.stop();
                if (response.IsAuthenicated == false) { window.location = "app/index.html"; }
                errorFunction(response);
            });
        }, 1000);

    }


    this.AjaxGetWithNoBlock = function (data, route, successFunction, errorFunction) {
        setTimeout(function () {
            $http({ method: 'GET', url: route, params: data }).success(function (response, status, headers, config) {
                successFunction(response, status);
            }).error(function (response) {;
                if (response.IsAuthenicated == false) { window.location = "app/index.html"; }
                errorFunction(response);
            });
        }, 0);

    }


}]);



