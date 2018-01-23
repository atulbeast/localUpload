angular.module('myApp', ['ngRoute', 'ui.bootstrap', 'ngMessages', 'ngMaterial', 'ngAnimate', 'toaster', 'ngFileUpload','angular-screenshot']).config(function ($routeProvider) {
   
    $routeProvider.when('/',
    {
        controller: 'StudentCtrl',
        templateUrl: 'App/Partial/AllStudent.html'

    }).when('/create', {
        controller: 'CreateCtrl',
        templateUrl: 'App/Partial/CreateStudent.html'

    }).when('/edit', {
        controller: 'EditCtrl',
        templateUrl: 'App/Partial/EditStudent.html'

    })

});         