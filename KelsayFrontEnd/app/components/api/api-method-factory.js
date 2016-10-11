(function () {

    angular.module("App").factory("ApiMethodFactory", ApiMethodFactory);

    ApiMethodFactory.$inject = ["$http", "$q", "ApiUrl"];

    function ApiMethodFactory($http, $q, ApiUrl) {
        return {

            /**
             * Get new method
             */
            get: function (requestParameters) {

                // Make the URL absolute
                requestParameters.url = ApiUrl + requestParameters.url;

                return function (args) {

                    // Request parameters
                    var params = replaceTokens(requestParameters, args);

                    // Adds an empty object for the reference
                    var helpers = {};
                    helpers.$object = {};
                    helpers.$list = [];

                    // Prepare request and handlers, bind helpers
                    var request = $http(params).then(successHandler.bind(helpers), errorHandler);

                    request.$object = helpers.$object;
                    request.$list = helpers.$list;

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

        /**
         * Replace tokens in the url with actual request parameters
         */
        function replaceTokens(request, args) {

            // Make a new object and copy properties
            try {                
                var newRequest = {};
                angular.extend(newRequest, request);
            } catch (error) {
                console.error(error);
            }

            if (angular.isObject(request) && angular.isObject(args)) {

                // Searches the URL template for the {tokens}
                var regex = /\{(.*?)\}/g;
                var tokens = newRequest.url.match(regex);

                // If there are tokens, try to replace them using the arguments provided
                if (tokens) {
                    for (var i in tokens) {
                        var tokenName = tokens[i].replace('{', "").replace('}', "");
                        newRequest.url = newRequest.url.replace(tokens[i], args[tokenName]);
                    }
                }

            }

            return newRequest;
        };

    }

})();