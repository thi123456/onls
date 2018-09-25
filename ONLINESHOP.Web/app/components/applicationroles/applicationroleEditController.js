(function (app) {
    'use strict';

    app.controller('applicationroleEditController', applicationroleEditController);

    applicationroleEditController.$inject = ['$scope', 'apiService', 'notificationService', '$location', '$stateParams'];

    function applicationroleEditController($scope, apiService, notificationService, $location, $stateParams) {
        $scope.role = {}


        $scope.updateApplicationRole = updateApplicationRole;

        function updateApplicationRole() {
            apiService.put('/api/applicationRole/update', $scope.role, addSuccessed, addFailed);
        }
        function loadDetail() {
            apiService.get('/api/applicationRole/detail/' + $stateParams.id, null,
            function (result) {
                $scope.role = result.data;
            },
            function (result) {
                notificationService.displayError(result.data);
            });
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.role.Name + ' đã được cập nhật thành công.');

            $location.url('applicationroles');
        }
        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }
        loadDetail();
    }
})(angular.module('onlineshop.applicationroles'));