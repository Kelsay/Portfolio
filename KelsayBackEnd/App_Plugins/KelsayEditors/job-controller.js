angular.module("umbraco").controller("JobController", JobController);

JobController.$inject = ["$scope"];

function JobController($scope) {
    console.log(typeof $scope.control.value);
    if (typeof $scope.control.value != "Object") {
        $scope.control.value = {};
    }

}