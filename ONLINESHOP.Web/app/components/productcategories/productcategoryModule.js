/// <reference path="/Assets/plugins/angular/angular.js" />
(function () {
    angular.module('onlineshop.productcategories', ['onlineshop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('productcategories', {
                url: "/productcategories",
                templateUrl: "/app/components/productcategories/productcategoryView.html",
                controller: "productcategoryViewController"
            })

          .state('productcategories_add', {
              url: "/productcategories_add",
              templateUrl: "/app/components/productcategories/productcategoryAddView.html",
              controller: "productcategoryAddController"
          })

          .state('productcategories_edit', {
              url: "/productcategoies_edit/:id",
              templateUrl: "/app/components/productcategories/productcategoryEditView.html",
              controller: "productcategoryEditController"
          })


        ;
    }
})();