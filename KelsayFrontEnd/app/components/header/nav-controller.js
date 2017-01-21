(function () {

    angular.module("App").controller("NavController", NavController);

    function NavController() {
        var vm = this;
        vm.isActive = false;

        vm.toggle = function() {
            vm.isActive = !vm.isActive;
        }

        vm.close = function () {
            vm.isActive = false;
        }
    }

})();