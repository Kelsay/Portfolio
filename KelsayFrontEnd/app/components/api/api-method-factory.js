(function () {

    angular.module("App").factory("ApiMethodFactory", ApiMethodFactory);

    ApiMethodFactory.$inject = ["$http", "$q", "ApiUrl"];

    function ApiMethodFactory($http, $q, ApiUrl) {
        return {

            /**
             * Get new method
             */
            get: function (params) {

                // Request parameters
                params.url = ApiUrl + params.url;

                // Adds an empty object for the reference
                var helpers = {};
                helpers.$object = {};
                helpers.$list = [];

                // Prepare request and handlers, bind helpers
                var request = $http(params).then(successHandler.bind(helpers), errorHandler);

                request.$object = helpers.$object;
                request.$list = helpers.$list;

                return function () {
                    return request;
                }
            }
        }

        /**
         * Default success handler
         */
        function successHandler(response) {

            var data = response.data;
            
            if (angular.isArray(data)) {
                for (var i in data) {
                    var index = data[i].id || i;
                    this.$object[index] = data[i];
                    this.$list.push(data[i]);
                }
            } else if (response.data) {
                angular.extend(this.$object, response.data);
            }

            // Adds non-enumerable property $loaded to help templating
            Object.defineProperty(this.$object, "$loaded", { value: true, enumerable: false });
            Object.defineProperty(this.$list, "$loaded", { value: true, enumerable: false });
            
            return response;
        };

        /**
         * Default error handler
         */
        function errorHandler(response) {
            console.error(response);
            return $q.reject(response);
        }

    }

})();