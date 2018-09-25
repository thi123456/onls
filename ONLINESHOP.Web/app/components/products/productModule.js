/// <reference path="/Assets/plugins/angular/angular.js" />
(function () {
    angular.module('onlineshop.products', ['onlineshop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('products', {
                url: "/products",
                parent:'base',
                templateUrl: "/app/components/products/productView.html",
                controller: "productViewController"
            })
       
          .state('products_add', {
              url: "/products_add",
              parent:'base',
              templateUrl: "/app/components/products/productAddView.html",
              controller: "productAddController"
          })
        
          .state('products_edit', {
              url: "/products_edit/:id",
              parent:'base',
              templateUrl: "/app/components/products/productEditView.html",
              controller: "productEditController"
          })
            

        ;
    }
})();