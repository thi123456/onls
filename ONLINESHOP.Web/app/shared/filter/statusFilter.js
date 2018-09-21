/// <reference path="\Assets/plugins/angular/angular.js" />

(function (app) {
    app.filter('statusFilter', statusFilter);

    function statusFilter() {


        return function (input) {

            if (input)
                return 'Kích hoạt';
            else
                return 'Khóa';
        }
    }


})(angular.module('onlineshop.common'));
