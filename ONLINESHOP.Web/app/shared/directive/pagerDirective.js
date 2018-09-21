(function (app) {
    'use strict';

    app.directive('pagerDirective', pagerDirective);

    function pagerDirective() {
        return {
            scope: {
                page: '@',
                pagesCount: '@',
                totalCount: '@',
                searchFunc: '&',
                customPath: '@'
            },
            replace: true,
            restrict: 'E',
            templateUrl: '/app/shared/directive/pagerDirective.html',
            controller: [
                '$scope', function ($scope) {
                    $scope.search = function (i) {
                        if ($scope.searchFunc) {
                            $scope.searchFunc({ page: i });
                        }
                    };

                    $scope.range = function () {
                        if (!$scope.pagesCount) { return []; }
                        var MaxPage = 5;
                        var startPageIndex = Math.max(1, ($scope.page - ((Math.ceil(MaxPage / 2)) - 1)));
                        var endPageIndex = Math.min($scope.pagesCount, ($scope.page + ((Math.ceil(MaxPage / 2)) - 1)));
                       
                     

                        var ret = [];
                        for (var i = startPageIndex; i <= endPageIndex; i++) {
                            ret.push(i);
                        }

                        return ret;
                    };

                    $scope.pagePlus = function (count) {
                        return +$scope.page + count;
                    }

                }]
        }
    }

})(angular.module('onlineshop.common'));