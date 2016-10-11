(function () {

    angular.module('App').config(PortfolioRoute);

    PortfolioRoute.$inject = ['$stateProvider'];

    function PortfolioRoute($stateProvider) {

        $stateProvider.state('page.sites', {
            url: '',
            templateUrl: 'build/templates/portfolio.html',
            controller: 'PortfolioController as portfolio'
        });

    }

})();