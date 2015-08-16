angular.module('App')
    .filter('item', function () {
        return function (item) {
            var params = {
                url : item.url
            }
            return "page."+ item.action + "(" + JSON.stringify(params) + ")";
        };
    });