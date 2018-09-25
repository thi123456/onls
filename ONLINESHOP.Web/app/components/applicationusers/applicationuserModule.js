/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('onlineshop.applicationusers', ['onlineshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('applicationusers', {
            url: "/applicationusers",
            templateUrl: "/app/components/applicationusers/applicationuserView.html",
            parent: 'base',
            controller: "applicationuserViewController"
        })
            .state('applicationuser_add', {
                url: "/add_applicationuser",
                parent: 'base',
                templateUrl: "/app/components/applicationusers/applicationuserAddView.html",
                controller: "applicationuserAddController"
            })
            .state('applicationuser_edit', {
                url: "/applicationuser_edit/:id",
                templateUrl: "/app/components/applicationusers/applicationuserEditView.html",
                controller: "applicationuserEditController",
                parent: 'base',
            });
    }
})();