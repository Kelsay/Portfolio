angular.module('App')
    .filter('trusted', ['$sce', function ($sce) {
        return function (text) {
            text = text ? text : "";
            return $sce.trustAsHtml(text);
        };
    }]);