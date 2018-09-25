/// <reference path="/Assets/plugins/angular/angular.js" />
(function (app) {

    app.controller('productAddController', productAddController);

    productAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];
    function productAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.Product = {

            Status: true
        };
        $scope.parentCategory = [];
        $scope.AddProduct = AddProduct;
        $scope.getSeoTitle = getSeoTitle;
        $scope.moreImage = [];
        function getSeoTitle() {

            $scope.Product.Alias = commonService.getSeoTitle($scope.Product.Name);
        }
        function AddProduct() {
            $scope.Product.MoreImages = JSON.stringify($scope.moreImage);
            apiService.post('/api/product/create', $scope.Product, dataLoadCompleted1, dataLoadFailed1);
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

            notificationService.displaySuccess(result.data.Name + ' đã thêm thành công');
            $state.go('products');

        }
        function dataLoadFailed1(response) {
            notificationService.displayError('thêm mới không thành công');
        }

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        $scope.ChooseImage = function () {

            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {

                $scope.$apply(function () {
                    $scope.Product.Image = fileUrl;
                });
              

            };
            finder.popup();
        }

       


        $scope.ChooseMoreImage = function () {

            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImage.push(fileUrl);
                });
               
              
            };
            finder.popup();
        }

        loadparentCategory();
    }


})(angular.module('onlineshop.products'));