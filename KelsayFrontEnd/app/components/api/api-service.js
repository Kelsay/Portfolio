// API service
// Defines API call methods using MethodFactory
(function () {

    angular.module("App").service("API", ApiService);

    ApiService.$inject = ["$http", "ApiMethodFactory", "ApiUrl"];

    function ApiService($http, ApiMethodFactory, ApiUrl) {

        // GET list of pages 
        this.getPage = ApiMethodFactory.get({ 'method': 'get', 'url': '/page' });

        // GET specific page by id
        this.getPageById = ApiMethodFactory.get({ 'method': 'get', 'url': '/page/{id}' });

        // GET list of portfolio items on a page
        this.getPortfolio = ApiMethodFactory.get({ 'method': 'get', 'url': '/page/{id}/portfolio' });

        // GET specific portfolio item details by id
        this.getPortfolioById = ApiMethodFactory.get({ 'method': 'get', 'url': '/page/{id}/portfolio/{itemId}' });

        // GET list of jobs on a page
        this.getJobs = ApiMethodFactory.get({ 'method': 'get', 'url': '/page/{id}/jobs' });

        // GET list of skillset on a page
        this.getSkills = ApiMethodFactory.get({ 'method': 'get', 'url': '/page/{id}/skillset' });

    };

})();
