(function () {

    angular.module('App').controller('JobsController', JobsController);

    JobsController.$inject = ['API', '$stateParams'];

    function JobsController(API, $stateParams) {

        // Properties
        var vm = this;

        // Init
        vm.items = API.getJobs({ id: $stateParams.url }).$list;

    }

})();