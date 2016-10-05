(function () {

    angular.module('App').controller('PageController', PageController);

    PageController.$inject = ['API', '$stateParams'];

    function PageController(API, $stateParams) {
        
        var vm = this;

        function constructor() {
            vm.data = API.getPageById({ id: $stateParams.url }).$object;
        }

        constructor();

    }

})();
    
    
  /*
    controller("PageController",
    ['$scope', 'Restangular', '$state', '$stateParams', function ($scope, Restangular, $state, $stateParams) {

        var page = Restangular.one("pages", $stateParams.url).get().then(function (data) { callback(data); });

        $scope.isLoading = true;

        // Check if we should be in child state (after URL reload)
        var callback = function (data) {
            $scope.page = data;
            $scope.isLoading = false;
            var state = 'page.' + data.action;
            if (!$state.is(state)) {
                $state.go(state, { url: data.url });
            }
            // TODO
            angular.element(document.querySelectorAll("body")).removeClass('nav-active');
        }

    }]); */