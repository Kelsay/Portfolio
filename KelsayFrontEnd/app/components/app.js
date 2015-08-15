var app = angular.module("App", ['ngAnimate', 'restangular', 'ui.router'])

    .config(['RestangularProvider', function (RestangularProvider) {
        RestangularProvider.setBaseUrl("http://api.fijolek.local")
    }]);