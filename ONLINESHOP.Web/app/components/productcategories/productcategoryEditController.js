/// <reference path="\Assets/plugins/angular/angular.js" />

(function (app) {

    app.controller('productcategoryEditController', productcategoryEditController);
    productcategoryEditController.$inject = ['apiService', '$scope', 'notificationService', '$state','$stateParams','commonService'];
    function productcategoryEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.ProductCategory = {

            Status: true,


        };
        $scope.parentCategory = [];
        $scope.UpdateProductCategory = UpdateProductCategory;
        $scope.getSeoTitle = getSeoTitle;
        function getSeoTitle() {

            $scope.ProductCategory.Alias = commonService.getSeoTitle($scope.ProductCategory.Name);
        }
      
        function loadProductByID() {

            apiService.get('/api/productcategory/getbyid/' + ($stateParams.id), null, dataLoadCompleted2, dataLoadFailed2);

        }

        function UpdateProductCategory() {

            apiService.put('/api/productcategory/update', $scope.ProductCategory, dataLoadCompleted1, dataLoadFailed1);
        }

        function loadparentCategory() {



            apiService.get('/api/productcategory/getallparent', null, dataLoadCompleted, dataLoadFailed);
        }

        function dataLoadCompleted(result) {

            $scope.parentCategory = result.data;

        }
        function dataLoadFailed(response) {
            console.log('load parent failed');
        }

        function dataLoadCompleted1(result) {

            notificationService.displaySuccess(result.data.Name + ' đã update thành công');
            $state.go('productcategories');

        }
        function dataLoadFailed1(response) {
            notificationService.displayError('update không thành công');
        }

        function dataLoadCompleted2(result) {
            $scope.ProductCategory = result.data;
          

        }
        function dataLoadFailed2(response) {
            console.log('load Detail failed');
        }


       

        loadparentCategory();
        loadProductByID();
    }


})(angular.module('onlineshop.productcategories'));