(function () {

    angular.module("App").controller("HeaderController", HeaderController);

    HeaderController.$inject = ["API"];

    function HeaderController(API) {

        var vm = this;

        function constructor() {
            vm.items = API.getPage().$object;
        }

        constructor();
    }

})();