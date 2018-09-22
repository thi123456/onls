/// <reference path="\Assets/plugins/angular/angular.js" />

(function (app) {
    app.filter('showFilter', showFilter);

    function showFilter() {


        return function (input) {

            if (input)
                return 'có';
            else
                return 'Không';
        }
    }


})(angular.module('onlineshop.common'));