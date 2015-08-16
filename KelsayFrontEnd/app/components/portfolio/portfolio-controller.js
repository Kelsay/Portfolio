angular.module('App')


.config(['$stateProvider', function ($stateProvider) {

    $stateProvider.state('page.sites', {
        //url: "/portfolio/:url",
        templateUrl: "build/templates/portfolio.html",
        controller: "PortfolioController"
    });

}])


.controller("PortfolioController", ['$scope', '$stateParams', 'Restangular', function ($scope, $stateParams, Restangular) {

    $scope.items = Restangular.one("pages", $stateParams.url).all("portfolio").getList().$object;

}]);