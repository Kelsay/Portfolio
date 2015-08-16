angular.module("App")

.config(["$stateProvider", function ($stateProvider) {

    $stateProvider.state("page", {
        url: "/:url/",
        controller: "PageController",
        templateUrl: "build/templates/page.html",
        params: {
            url: ''
        }
    });

    $stateProvider.state("page.article", {});

}])


.controller("PageController",
    ['$scope', 'Restangular', '$state', '$stateParams', function ($scope, Restangular, $state, $stateParams) {

        var page = Restangular.one("pages", $stateParams.url).get().then(function (data) { callback(data); });

        // Check if we should be in child state (after URL reload)
        var callback = function (data) {
            $scope.page = data;
            var state = 'page.' + data.action;
            if (!$state.is(state)) {
                $state.go(state,{url: data.url});
            }
        }

    }]);