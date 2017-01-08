(function () {

    angular.module('App').config(ArticleRoute);

    ArticleRoute.$inject = ['$stateProvider'];

    function ArticleRoute($stateProvider) {

        $stateProvider.state('page.article', {
            url: '',
            templateUrl: 'build/templates/article.html',
            controller: 'ArticleController as article'
        });

    }

})();