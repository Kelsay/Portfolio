angular.module("App")

.config(["$stateProvider", function ($stateProvider) {

    $stateProvider.state("article", {
        url: "/article",
        controller: "ArticleController",
        templateUrl: "build/templates/article-view.html",
        params: {
            id: ""
        }
    });

}])


.controller("ArticleController",
    ['$scope', 'Restangular', '$stateParams', function ($scope, Restangular, $stateParams) {

        $scope.article = Restangular.one("articles", $stateParams.id).get().$object;

    }]);