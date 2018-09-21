/// <reference path="\Assets/plugins/angular/angular.js" />

(function(app){

    app.controller('productcategoryAddController', productcategoryAddController);
    productcategoryAddController.$inject = ['apiService','$scope','notificationService','$state'];
    function productcategoryAddController(apiService, $scope, notificationService, $state) {
        $scope.ProductCategory = {
            CreatedDate: new Date(),
            Status:true
        };
        $scope.parentCategory = [];
        $scope.AddProductCategory = AddProductCategory;

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