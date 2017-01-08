(function () {

    angular.module('App').config(JobsRoute);

    JobsRoute.$inject = ['$stateProvider'];

    function JobsRoute($stateProvider) {

        $stateProvider.state('page.jobs', {
            url: '',
            templateUrl: 'build/templates/jobs.html',
            controller: 'JobsController as jobs'
        });

    }

})();