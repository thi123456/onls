/// <reference path="/Assets/plugins/angular/angular.js" />
(function (app) {

    app.controller('productViewController', productViewController);
    

        productViewController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

        function productViewController($scope, apiService, notificationService, $ngBootbox, $filter) {
            $scope.products = [];
            $scope.Search = Search;
            $scope.page = 1;
            $scope.pageCount = 0;
            $scope.totalCount = 0;
            $scope.filter = '';
            $scope.loadProduct = loadProduct;
            $scope.deleteProduct = deleteProduct;
            $scope.deleteMultiProduct = deleteMultiProduct;
            $scope.SelectAll = SelectAll;

            $scope.IsAll = false;
            function deleteProduct(id) {
                var name = GetName(id);
                $ngBootbox.confirm('bạn chắc muốn xóa ' + name).then(function () {
                    var config = { params: { id: id } };
                    apiService.del('/api/product/delete', config, deleteComplete, deleteFailed);
                });
            }
            var name = '';
            function deleteMultiProduct() {
                var listId = [];
                name = '';
                angular.forEach($scope.Selected, function (item) {
                    listId.push(item.ID);

                    name = name + item.Name + ',';
                });
                var config = {
                    params: {
                        listId: JSON.stringify(listId)
                    }
                };
                name = name.slice(0, (name.length - 1));
                $ngBootbox.confirm('bạn chắc muốn xóa ' + name).then(function () {
                    apiService.del('/api/product/deletemulti', config, deleteMultiComplete, deleteMultiFailed);
                });
            }

            function deleteMultiComplete() {
                notificationService.displaySuccess('xóa ' + name + ' thành công');
                Search();
               
            }

            function deleteMultiFailed() {
                notificationService.displaySuccess('xóa ' + name + 'không thành công');
            }

            $scope.$watch("products", function (n, o) {
                var checked = $filter("filter")(n, { checked: true });
                if (checked.length) {
                    $scope.Selected = checked;
                    $('#btnDelete').removeAttr('disabled');
                    if (checked.length == $scope.products.length) {
                        $("#all")[0].checked = true;
                        $scope.IsAll = true;
                    }
                    else {
                        $("#all")[0].checked = false;
                        $scope.IsAll = false;
                    }
                }
                else {
                    $('#btnDelete').attr('disabled', 'disabled');
                    $("#all")[0].checked = false;
                    $scope.IsAll = false;
                }
            }, true);

          
            function SelectAll() {
                if (!$scope.IsAll) {
                    angular.forEach($scope.products, function (item) {
                        item.checked = true;
                    });
                    $scope.IsAll = true;
                }
                else {
                    angular.forEach($scope.products, function (item) {
                        item.checked = false;
                    });
                    $scope.IsAll = false;
                }
            }

            function GetName(id) {
                var name = '';
                $.each($scope.products, function (i, tem) {
                    if (tem.ID == id) {
                        name = tem.Name;
                    }
                });
                return name;
            }
            function deleteComplete(result) {
                notificationService.displaySuccess('Xóa ' + result.data.Name + ' thành công');
                Search();
            }

            function deleteFailed() {
                notificationService.displayError('Xóa không thành công');
            }

            function Search() {
                loadProduct();
            }
            function loadProduct(page) {
                var config = {
                    params: {
                        filter: $scope.filter,
                        page: page || 1,
                        pageSize: 2
                    }
                }
                apiService.get('/api/product/getall', config, dataLoadCompleted, dataLoadFailed);
                $("#all")[0].checked = false;
            }

            function dataLoadCompleted(result) {
                if (result.data.TotalCount == 0)
                    notificationService.displayWarning('Không có bản ghi nào');
                $scope.products = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pageCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
            }
            function dataLoadFailed(response) {
                console.log('load productcategory failed');
            }

            $scope.loadProduct();
        }
    

})(angular.module('onlineshop.products'));