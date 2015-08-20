angular.module('App')


.config(['$stateProvider', function ($stateProvider) {

    $stateProvider.state('page.sites', {
        url : "",
        templateUrl: "build/templates/portfolio.html",
        controller: "PortfolioController",
        sticky: true
    });

    $stateProvider.state('page.sites.details', {
        url: ":item/",      
        //templateUrl : "build/templates/portfolio-details.html",
        controller: "PortfolioDetailsController",
        reload: true,
        params: {
            item: '',
            num: ''
        },
        onEnter: ['$stateParams', '$state', '$modal', function ($stateParams, $state, $modal) {
            $modal.open({
                templateUrl: "build/templates/portfolio-details.html",
                resolve: {
                    //item: function () { new Item(123).get(); }
                },
                controller: "PortfolioDetailsController"
                /*controller: ['$scope', '$stateParams', 'Restangular', function ($scope, $stateParams, Restangular) {

                    $scope.num = $stateParams.num;
                    $scope.item = Restangular.one("pages", $stateParams.url).one("portfolio", $stateParams.item).get().$object;

                }] 
                /*controller: ['$scope', 'item', function ($scope, item) {
                    $scope.dismiss = function () {
                        $scope.$dismiss();
                    };

                    $scope.save = function () {
                        item.update().then(function () {
                            $scope.$close(true);
                        });
                    };
                }] */
            }).result.finally(function () {
                //$state.go('^');
            });
        }]
    });


}])


.controller("PortfolioController", ['$scope', '$stateParams', 'Restangular',function ($scope, $stateParams, Restangular) {

    $scope.items = Restangular.one("pages", $stateParams.url).all("portfolio").getList().$object;

}])


.controller("PortfolioDetailsController", ['$scope', '$stateParams', 'Restangular', function ($scope, $stateParams, Restangular) {

    $scope.num = $stateParams.num;
    $scope.item = Restangular.one("pages", $stateParams.url).one("portfolio", $stateParams.item).get().$object;

    $scope.close = function () {
        $scope.$close(true);
    }

}]);