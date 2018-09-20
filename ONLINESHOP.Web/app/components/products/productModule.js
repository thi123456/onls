/// <reference path="/Assets/plugins/angular/angular.js" />
(function () {
    angular.module('onlineshop.products', ['onlineshop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('products', {
                url: "/products",
                templateUrl: "/app/components/products/productView.html",
                controller: "productViewController"
            })
       
          .state('products_add', {
              url: "/products_add",
              templateUrl: "/app/components/products/productAddView.html",
              controller: "productAddController"
          })
        
          .state('products_edit', {
              url: "/products_edt",
              templateUrl: "/app/components/products/productEditView.html",
              controller: "productEditController"
          })
            

        ;
    }
})();