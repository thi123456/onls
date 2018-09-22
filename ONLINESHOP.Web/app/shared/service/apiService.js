﻿/// <reference path="\Assets/plugins/angular/angular.js" />
(function (app) {

    app.service('apiService', apiService);
    apiService.$inject = ['$http','notificationService'];

    function apiService($http, notificationService) {

        return {
            get: get,
            post: post,
            put:put
        }

        function get(url,params,success,failure) {
            $http.get(url, params).then(function (result) { success(result); }, function (error) { failure(error); });
        }
        function post(url, params, success, failure) {
            $http.post(url, params).then(function (result) { success(result); }, function (error) { if (error.status === '401') notificationService.displayError('Lỗi chứng thực'); failure(error); });
        }
        function put(url, params, success, failure) {
            $http.put(url, params).then(function (result) { success(result); }, function (error) { if (error.status === '401') notificationService.displayError('Lỗi chứng thực'); failure(error); });
        }
    }

})(angular.module('onlineshop.common'));