(function () {

    angular.module("App").service("API", ApiService);

    ApiService.$inject = ["$http"];

    function ApiService($http) {

        /**
         * Adds helper $object to the call results
         * $object can be bound directly to the template and will be *then* populated on resolve
         * Calls with only one result: $object will contain all the properties
         * Calls with multiple results: $object will contain list of entities indexed by ID
         * The $object contains also $loaded property to use within templates 
        **/
        this.addHelpers = function (response) {

            var data = response.data.data;

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


    };

})();
