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

                return function (values, data) {

                    // Request parameters
                    var request = replaceTokens(requestParameters, values);
                    angular.extend(request, data);

                    // Add an empty object for the reference
                    var helpers = {};
                    helpers.$object = {};
                    helpers.$list = [];

                    // Prepare request and handlers, bind helpers
                    var promise = $http(request).then(successHandler.bind(helpers), errorHandler);

                    promise.$object = helpers.$object;
                    promise.$list = helpers.$list;

                    return promise;
                }
            }
        }

        /**
         * Default success handler
         * Add $object and $list properties to the response for easy templating and reduce number of callbacks
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

            // Add non-enumerable property $loaded to help templating
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