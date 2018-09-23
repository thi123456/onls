/// <reference path="/Assets/plugins/angular/angular.js" />
(function (app) {

    app.controller('productEditController', productEditController);

    productEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];
    function productEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.Product = {

            Status: true,


        };
        $scope.parentCategory = [];
        $scope.UpdateProduct = UpdateProduct;
        $scope.getSeoTitle = getSeoTitle;
        function getSeoTitle() {

            $scope.Product.Alias = commonService.getSeoTitle($scope.Product.Name);
        }

        function loadProductByID() {

            apiService.get('/api/product/getbyid/' + ($stateParams.id), null, dataLoadCompleted2, dataLoadFailed2);

        }

        function UpdateProduct() {

            apiService.put('/api/product/update', $scope.Product, dataLoadCompleted1, dataLoadFailed1);
        }

        function loadparentCategory() {



            apiService.get('/api/product/getallparent', null, dataLoadCompleted, dataLoadFailed);
        }

        function dataLoadCompleted(result) {

            $scope.parentCategory = result.data;

        }
        function dataLoadFailed(response) {
            console.log('load parent failed');
        }

        function dataLoadCompleted1(result) {

            notificationService.displaySuccess(result.data.Name + ' đã update thành công');
            $state.go('products');

        }
        function dataLoadFailed1(response) {
            notificationService.displayError('update không thành công');
        }

        function dataLoadCompleted2(result) {
            $scope.Product = result.data;


        }
        function dataLoadFailed2(response) {
            console.log('load Detail failed');
        }

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }


        loadparentCategory();
        loadProductByID();
    }


})(angular.module('onlineshop.products'));