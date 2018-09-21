/// <reference path="/Assets/plugins/angular/angular.js" />
(function (app) {

    app.controller('productcategoryViewController', productcategoryViewController);
    productcategoryViewController.$inject = ['$scope', 'apiService'];

    
    function productcategoryViewController($scope, apiService) {

        $scope.productCategories = [];
        $scope.Search = Search;

        function Search() {
            apiService.get('/api/productcategory/getall', null, dataLoadCompleted, dataLoadFailed);
        }

        function dataLoadCompleted(result) {

            $scope.productCategories = result.data;

        }
        function dataLoadFailed(response) {
            console.log('load productcategory failed');
        }

        $scope.Search();
    }

})(angular.module('onlineshop.productcategories'));