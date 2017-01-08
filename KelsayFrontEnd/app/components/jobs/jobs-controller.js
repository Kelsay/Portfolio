(function () {

    angular.module('App').controller('JobsController', JobsController);

    JobsController.$inject = ['API', '$stateParams'];

    function JobsController(API, $stateParams) {

        // Properties
        var vm = this;
        vm.$showDetails = false;

        // Init
        vm.items = API.getJobs({ id: $stateParams.url }).$list;

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