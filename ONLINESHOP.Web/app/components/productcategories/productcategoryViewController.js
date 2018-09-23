/// <reference path="/Assets/plugins/angular/angular.js" />
(function (app) {
    app.controller('productcategoryViewController', productcategoryViewController);
    productcategoryViewController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function productcategoryViewController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.productCategories = [];
        $scope.Search = Search;
        $scope.page = 1;
        $scope.pageCount = 0;
        $scope.totalCount = 0;
        $scope.filter = '';
        $scope.loadProductCategory = loadProductCategory;
        $scope.deleteProductCategory = deleteProductCategory;
        $scope.deleteMultiProductCategory = deleteMultiProductCategory;
        $scope.SelectAll = SelectAll;

        $scope.IsAll = false;
        function deleteProductCategory(id) {
            var name = GetName(id);
            $ngBootbox.confirm('bạn chắc muốn xóa ' + name).then(function () {
                var config = { params: { id: id } };
                apiService.del('/api/productcategory/delete', config, deleteComplete, deleteFailed);
            });
        }
        var name = '';
        function deleteMultiProductCategory() {
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
            name=name.slice(0,(name.length-1));
            $ngBootbox.confirm('bạn chắc muốn xóa ' + name).then(function () {
                apiService.del('/api/productcategory/deletemulti', config, deleteMultiComplete, deleteMultiFailed);
            });
        }

        function deleteMultiComplete() {
            notificationService.displaySuccess('xóa ' + name + ' thành công');
            Search();
            name = '';
        }

        function deleteMultiFailed() {
            notificationService.displaySuccess('xóa ' + name + 'không thành công');
        }

        $scope.$watch("productCategories", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.Selected = checked;
                $('#btnDelete').removeAttr('disabled');
                if (checked.length == $scope.productCategories.length) {
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

        //function UnCheckAll() {
        //    //$("#all").off('change').on('change', function () {
        //    //    var status = this.checked;
        //    //    $('.uncheckall').each(function () {
        //    //        this.checked = status;

        //    //    });
        //    //});

        //    //$('.uncheckall').off('change').on('change', function () {
        //    //    if (this.checked == false) {
        //    //        $("#all")[0].checked = false;
        //    //    }

        //    //    if ($('.uncheckall:checked').length == $('.uncheckall').length) {
        //    //        $("#all")[0].checked = true;
        //    //    }
        //    //});

        //}

        function SelectAll() {
            if (!$scope.IsAll) {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = true;
                });
                $scope.IsAll = true;
            }
            else {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = false;
                });
                $scope.IsAll = false;
            }
        }

        function GetName(id) {
            var name = '';
            $.each($scope.productCategories, function (i, tem) {
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
            loadProductCategory();
        }
        function loadProductCategory(page) {
            var config = {
                params: {
                    filter: $scope.filter,
                    page: page || 1,
                    pageSize: 2
                }
            }
            apiService.get('/api/productcategory/getall', config, dataLoadCompleted, dataLoadFailed);
            $("#all")[0].checked = false;
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