(function () {

    angular.module('App').config(SkillsRoute);

    SkillsRoute.$inject = ['$stateProvider'];

    function SkillsRoute($stateProvider) {

        $stateProvider.state('page.skills', {
            url: '',
            templateUrl: 'build/templates/skills.html',
            controller: 'SkillsController as skills'
        });

    }

})();