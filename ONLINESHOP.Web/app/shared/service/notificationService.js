/// <reference path="\Assets/plugins/angular/angular.js" />
(function (app) {


    app.service('notificationService', notificationService);
    function notificationService() {


        toastr.options = {
            "debug":false,
            "positionClass": "toast-top-right",
            "onlick": null,
            "fadeIn": 300,
            "fadeOut": 1000,
            "timeOut": 3000,
            "extendedTimeOut":1000
        };

       
        function displaySuccess(message) {
            toastr.success(message);
        }
        function displayError(errors) {
            if (Array.isArray(errors))
                error.each(function (err) {
                    toastr.error(err);
                });
            else
            {
                toastr.error(errors);
            }
        }
        function displayWarning(message) {
            toastr.warning(message);
        }
        function displayInfo(message)
        {
            toastr.info(message);
        }

        return {
            displaySuccess: displaySuccess,
            displayError: displayError,
            displayInfo: displayInfo,
            displayWarning: displayWarning

        }
    }


})(angular.module('onlineshop.common'));
