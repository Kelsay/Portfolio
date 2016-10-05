/**
 * The Main Application file
 * Module declaration and some app wide settings
 */

'use strict';

var dependencies = [
    'ngAnimate',
    'restangular',
    'ui.router',
    'ui.bootstrap',
    'ct.ui.router.extras.sticky'
];

var app = angular.module("App", dependencies)

    .config(['RestangularProvider', function (RestangularProvider) {
        RestangularProvider.setBaseUrl("http://api.fijolek.net")
    }])

    // Default view for /
    .config(['$urlRouterProvider', function ($urlRouterProvider) {
        $urlRouterProvider.when("/", "/start/")
    }])

    // Add base URL constant
    .constant('ApiUrl', 'http://api.fijolek.net')

    // Put the app in the HTML5 mode for the clean urls
    .config(['$locationProvider', function ($locationProvider) {
        $locationProvider.html5Mode(true);
    }]);

