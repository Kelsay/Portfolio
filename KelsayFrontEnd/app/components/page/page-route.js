(function () {

    angular.module("App").config(PageRoute);

    PageRoute.$inject = ["$stateProvider"];

    function PageRoute($stateProvider) {

        $stateProvider.state("page", {
            url: "/:url/",
            controller: "PageController as page",
            templateUrl: "build/templates/page.html",
            params: {
                url: ''
            }
        });

        $stateProvider.state("page.article", {});
    }

})();