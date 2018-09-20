/// <reference path="../plugins/angular/angular.js" />
var myApp = angular.module("myModule", []);

myApp.controller("thiController", thiController);
myApp.service('ValidatetorService', ValidatetorService);
myApp.directive('thiDirective', thiDirective);
thiController.$inject = ['$scope', 'ValidatetorService'];
function thiController($scope, Validatetor) {
    $scope.checkNumber = function (input) {
        $scope.message = ValidatetorService.checkNumber(input);

    }
   
}

function ValidatetorService($window) {
    return {
        checkNumber: checkNumber
    }

    function checkNumber(input) {
       
        if (input % 2 == 0)
            return 'đây là số chẵn';
        else {
            return 'đây là số lẻ';
        }
    }
}

function thiDirective() {


    return {
        restrict:'A',
        templateUrl:"/Assets/admin/thiDirective.html"
    }
}