/// <reference path="/Assets/plugins/angular/angular.js" />

(function () {
    angular.module('onlineshop.applicationroles', ['onlineshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('applicationroles', {
            url: "/applicationroles",
            templateUrl: "/app/components/applicationroles/applicationroleView.html",
            parent: 'base',
            controller: "applicationroleViewController"
        })
            .state('applicationrole_add', {
                url: "/applicationrole_add",
                parent: 'base',
                templateUrl: "/app/components/applicationroles/applicationroleAddView.html",
                controller: "applicationroleAddController"
            })
            .state('applicationrole_edit', {
                url: "/applicationrole_edit/:id",
                templateUrl: "/app/components/applicationroles/applicationroleEditView.html",
                controller: "applicationroleEditController",
                parent: 'base',
            });
    }
})();