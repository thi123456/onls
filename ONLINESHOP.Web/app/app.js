/// <reference path="/Assets/plugins/angular/angular.js" />
(function () {

    angular.module('onlineshop', ['onlineshop.common',
                                 'onlineshop.products',
                                 'onlineshop.productcategories'
                                
    ]).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider)
    {
        $stateProvider.state('home', {

            url: "/admin",
            templateUrl: "/app/components/home/homeView.html",
            controller:"homeController"


        })

        ;
        $urlRouterProvider.otherwise('/admin');

    }


})();