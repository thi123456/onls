/// <reference path="/Assets/plugins/angular/angular.js" />
(function (app) {

    app.controller('productcategoryViewController', productcategoryViewController);
    productcategoryViewController.$inject = ['$scope', 'apiService', 'notificationService'];

    
    function productcategoryViewController($scope, apiService, notificationService) {

        $scope.productCategories = [];
        $scope.Search = Search;
        $scope.page = 1;
        $scope.pageCount = 0;
        $scope.totalCount = 0;
        $scope.filter = '';
        $scope.loadProductCategory = loadProductCategory;
        
        function Search()
        {
            loadProductCategory();
        }
        function loadProductCategory(page) {

            var config = {
                params: {
                    filter: $scope.filter,
                    page: page || 1,
                    pageSize:2
                }
            }
            apiService.get('/api/productcategory/getall', config, dataLoadCompleted, dataLoadFailed);
        }

        function dataLoadCompleted(result) {
            if (result.data.TotalCount == 0)
                notificationService.displayWarning('Không có bản ghi nào');
            $scope.productCategories = result.data.Items;
            $scope.page = result.data.Page;
            $scope.pageCount = result.data.TotalPage;
            $scope.totalCount = result.data.TotalCount;

        }
        function dataLoadFailed(response) {
            console.log('load productcategory failed');
        }

        $scope.loadProductCategory();
    }

})(angular.module('onlineshop.productcategories'));