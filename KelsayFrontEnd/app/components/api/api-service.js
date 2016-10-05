(function () {

    angular.module("App").service("API", ApiService);

    ApiService.$inject = ["$http", "ApiMethodFactory", "ApiUrl"];

    function ApiService($http, ApiMethodFactory, ApiUrl) {


        // GET all the pages 
        this.getPage = ApiMethodFactory.get({ 'method': 'get', 'url': '/page' });

        // GET specific page resource
        this.getPageById = ApiMethodFactory.get({ 'method': 'get', 'url': '/page/{id}' });

    };

})();
