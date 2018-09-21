/// <reference path="/Assets/plugins/angular/angular.js" />
(function (app) {

    app.controller('productcategoryViewController', productcategoryViewController);
    productcategoryViewController.$inject = ['$scope', 'apiService'];

    
    function productcategoryViewController($scope, apiService) {

        $scope.productCategories = [];
        $scope.Search = Search;
        $scope.page = 1;
        $scope.pageCount = 0;
        $scope.totalCount = 0;

        function Search(page) {

            var config = {
                params: {
                    page: page || 1,
                    pageSize:1
                }
            }
            apiService.get('/api/productcategory/getall', config, dataLoadCompleted, dataLoadFailed);
        }

        function dataLoadCompleted(result) {

            $scope.productCategories = result.data.Items;
            $scope.page = result.data.Page;
            $scope.pageCount = result.data.TotalPage;
            $scope.totalCount = result.data.TotalCount;

        }
        function dataLoadFailed(response) {
            console.log('load productcategory failed');
        }

        $scope.Search(1);
    }

})(angular.module('onlineshop.productcategories'));