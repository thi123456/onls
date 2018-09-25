/// <reference path="/Assets/plugins/angular/angular.js" />
(function (app) {
    app.controller('loginController', ['$scope', 'loginService', '$injector', 'notificationService',
        function ($scope, loginService, $injector, notificationService) {
            $scope.loginData = {
                userName: "",
                password: ""
            };

            $scope.loginSubmit = function () {
                loginService.login($scope.loginData.userName, $scope.loginData.password).then(function (response) {
                    if (response != null && response.error == null) {
                        notificationService.displayError("Tên đăng nhập hoặc mật khẩu không đúng");
                        return;
                    }
                    else {
                        notificationService.displaySuccess("Đăng nhập thành công");
                        var stateService = $injector.get('$state');
                        stateService.go('home');
                    }
                });
            }
        }]);
})(angular.module('onlineshop'));