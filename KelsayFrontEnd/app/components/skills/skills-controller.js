(function () {

    angular.module('App').controller('SkillsController', SkillsController);

    SkillsController.$inject = ['API', '$stateParams'];

    function SkillsController(API, $stateParams) {
        var vm = this;
        vm.items = API.getSkills({ id: $stateParams.url }).$list;
    }

})();