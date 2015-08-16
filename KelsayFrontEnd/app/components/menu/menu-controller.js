angular.module("App")

    .controller("MenuController", ["$scope","Restangular", function ($scope,Restangular) {

        $scope.items = Restangular.all("pages").getList().$object;

    }])