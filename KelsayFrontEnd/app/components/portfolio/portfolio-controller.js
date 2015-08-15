angular.module('App')


.config(['$stateProvider', function ($stateProvider) {

    $stateProvider.state("sites", {
        url: "/portfolio",
        templateUrl: "build/templates/portfolio.html",
        controller: "PortfolioController",
        params: {
            id: ''
        }
    });

}])


.controller("PortfolioController", ['$scope', '$stateParams', 'Restangular', function ($scope, $stateParams, Restangular) {

    $scope.page = Restangular.one("portfolio", $stateParams.id).get().$object;

}]);