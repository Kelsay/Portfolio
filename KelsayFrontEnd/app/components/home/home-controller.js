angular.module("App")

.config(["$stateProvider", function ($stateProvider) {

    $stateProvider.state("page.start", {
        templateUrl: "build/templates/home.html",
        controller: "PageController",
        params: {
            url : ''
        }
    });

}])