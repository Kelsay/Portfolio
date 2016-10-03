(function () {

    angular.module("App").controller("MenuController", MenuController);

    MenuController.$inject = ["$scope", Restangular];

    function MenuController($scope, Restangular) {
        $scope.items = Restangular.all("pages").getList().$object;

    }

})();