(function () {

    angular.module('App').controller('PortfolioController', PortfolioController);

    PortfolioController.$inject = ['API', '$stateParams'];

    function PortfolioController(API, $stateParams) {

        // Properties
        var vm = this;
        vm.$showDetails = false;
        vm.$loading = false;
        vm.$isFinished = false;

        // A list of items
        vm.items = [];

        // Init

        /***
         * Get a single page of portfolio items
         */

        vm.loadItems = function () {
            vm.$loading = true;
            var data = {
                params: {
                    start: vm.items.length
                }
            };
            API.getPortfolio({ id: $stateParams.url }, data).then(loadItemsHandler);
        }

        // Call at the startup to load the first portion
        vm.loadItems();

        function loadItemsHandler(response) {
            vm.items = vm.items.concat(response.data.items);
            vm.$finished = response.data.isLast;
            vm.$loading = false;
        }

        /**
         * Show details of the selected portfolio item
         */
        vm.showDetails = function (itemId) {
            vm.details = {};
            vm.details = API.getPortfolioById({ id: $stateParams.url, itemId: itemId }).$object;
            vm.$showDetails = true;
        }

        /**
         * Close the details
         */
        vm.hideDetails = function () {
            vm.$showDetails = false;
        }

    }

})();