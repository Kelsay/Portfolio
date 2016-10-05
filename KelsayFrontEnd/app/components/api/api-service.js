(function () {

    angular.module("App").service("API", ApiService);

    ApiService.$inject = ["$http", "ApiMethodFactory", "ApiUrl"];

    function ApiService($http, ApiMethodFactory, ApiUrl) {

        this.getPages = ApiMethodFactory.get({ 'method': 'get', 'url': '/pages' });

    };

})();
