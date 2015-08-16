angular.module('App')


.config(['$stateProvider', function ($stateProvider) {

    $stateProvider.state('page.sites', {
        //url: "/portfolio/:url",
        templateUrl: "build/templates/portfolio.html",
        controller: "PortfolioController"
    });

}])


.controller("PortfolioController", ['$scope', '$stateParams', 'Restangular', function ($scope, $stateParams, Restangular) {
    
    $scope.test = "Dupa";
    $scope.portfolio = Restangular.one("portfolio", $stateParams.id).get().$object;

}]);