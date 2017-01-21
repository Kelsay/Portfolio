/**
 * The Main Application file
 * Module declaration and some app wide settings
 */

'use strict';

var dependencies = [
    'ngAnimate',
    'ui.router',
];

var app = angular.module("App", dependencies)

    // Default view for /
    .config(['$urlRouterProvider', function ($urlRouterProvider) {
        $urlRouterProvider.when("/", "/start/")
    }])

    // Add base URL constant
    .constant('ApiUrl', 'http://api.fijolek.net')
    //.constant('ApiUrl', 'http://api.kelsay.local')

    // Put the app in the HTML5 mode for the clean urls
    .config(['$locationProvider', function ($locationProvider) {
        $locationProvider.html5Mode(true);
    }]);

