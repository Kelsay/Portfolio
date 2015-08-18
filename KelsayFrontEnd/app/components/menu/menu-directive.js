angular.module('App')

app.directive('mobileLauncher', function () {
    return {
        restrict: 'A',
        link: function ($scope, el, attr) {
            
            var body = angular.element(document.querySelectorAll("body"))

            el.bind('click', function () {
                body.toggleClass('nav-active')
            })

        }
    }
})