'use strict';
// The Main Application module

var app = angular.module("App", ['ngAnimate', 'restangular', 'ui.router'])

    .config(['RestangularProvider', function (RestangularProvider) {
        RestangularProvider.setBaseUrl("http://api.fijolek.local")
    }])

    .config(['$locationProvider', function ($locationProvider) {
        $locationProvider.html5Mode(true);
    }])