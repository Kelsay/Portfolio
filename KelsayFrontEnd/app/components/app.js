'use strict';
// The Main Application module

(function () {

    var app = angular.module("App", ['ngAnimate', 'restangular', 'ui.router', 'ui.bootstrap', 'ct.ui.router.extras.sticky'])

    .config(['RestangularProvider', function (RestangularProvider) {
        RestangularProvider.setBaseUrl("http://api.fijolek.net")
    }])

    .config(['$locationProvider', function ($locationProvider) {
        $locationProvider.html5Mode(true);
    }])

})();
