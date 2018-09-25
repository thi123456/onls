/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('onlineshop.applicationgroups', ['onlineshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('applicationgroups', {
            url: "/applicationgroups",
            templateUrl: "/app/components/applicationgroups/applicationgroupView.html",
            parent: 'base',
            controller: "applicationgroupViewController"
        })
            .state('applicationgroup_add', {
                url: "/applicationgroup_add",
                parent: 'base',
                templateUrl: "/app/components/applicationgroups/applicationgroupAddView.html",
                controller: "applicationgroupAddController"
            })
            .state('applicationgroup_edit', {
                url: "/applicationgroup_edit/:id",
                templateUrl: "/app/components/applicationgroups/applicationgroupEditView.html",
                controller: "applicationgroupEditController",
                parent: 'base',
            });
    }
})();