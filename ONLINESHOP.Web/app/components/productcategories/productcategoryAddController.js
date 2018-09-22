/// <reference path="\Assets/plugins/angular/angular.js" />

(function(app){

    app.controller('productcategoryAddController', productcategoryAddController);
    productcategoryAddController.$inject = ['apiService','$scope','notificationService','$state','commonService'];
    function productcategoryAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.ProductCategory = {
           
            Status:true
        };
        $scope.parentCategory = [];
        $scope.AddProductCategory = AddProductCategory;
        $scope.getSeoTitle = getSeoTitle;
        function getSeoTitle() {

            $scope.ProductCategory.Alias = commonService.getSeoTitle($scope.ProductCategory.Name);
        }
        function AddProductCategory() {

            apiService.post('/api/productcategory/create', $scope.ProductCategory, dataLoadCompleted1, dataLoadFailed1);
        }

        function loadparentCategory() {

           
            
            apiService.get('/api/productcategory/getallparent',null, dataLoadCompleted, dataLoadFailed);
        }

        function dataLoadCompleted(result) {
           
            $scope.parentCategory = result.data;

        }
        function dataLoadFailed(response) {
            console.log('load parent failed');
        }

        function dataLoadCompleted1(result) {

            notificationService.displaySuccess(result.data.Name + ' đã thêm thành công');
            $state.go('productcategories');

        }
        function dataLoadFailed1(response) {
            notificationService.displayError('thêm mới không thành công');
        }

       loadparentCategory();
    }


})(angular.module('onlineshop.productcategories'));