(function () {
    "use strict";

    angular.module('app').constant('SETTINGS', {
        'VERSION': '0.0.0',
        'CURR_ENV': 'dev',
        'AUTH_TOKEN': 'easy-token',
        'AUTH_USER': 'easy-user',

        "IMAGES_URL": '/images', /*localhost*/
        'SERVICE_URL': 'http://localhost/Easy.Api/', /*localhost*/
        'SERVICE_URL_WEB': null /*localhost*/
    });

    angular.module('app').run(function ($rootScope, SETTINGS) {

       $rootScope.images = SETTINGS.SERVICE_URL + SETTINGS.IMAGES_URL;
       
    });

})();