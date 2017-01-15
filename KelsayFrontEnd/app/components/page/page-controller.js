(function () {

    angular.module('App').controller('PageController', PageController);

    PageController.$inject = ['API', '$state', '$stateParams'];

    function PageController(API, $state, $stateParams) {

        var vm = this;

        function constructor() {
            API.getPageById({ id: $stateParams.url }).then(successHandler);
        }

        constructor();

        function successHandler(response) {
            vm.data = response.data;
            vm.data.$loaded = true;
            goToChildState(vm.data);
        }

        /**
         * After reload from URL, check if we should be in nested state
         */
        function goToChildState(data) {
            var state = 'page.' + data.action;
            if (!$state.is(state) && $state.href(state)) {
                $state.go(state, { url: data.url })
            }
        }

    }

})();