(function() {
    "use strict";

    angular.module("app").config(function ($routeProvider, $locationProvider) {
        $locationProvider.hashPrefix("");
        $routeProvider
            .when("/",
            {
                controller: 'homeListController',
                controllerAs: "vm",
                templateUrl: "Views/Home/index.html"
            })
            .when("/novo",
            {
                controller: 'homeCreateController',
                controllerAs: "vm",
                templateUrl: "Views/Home/create.html"
            })
            .when("/editar/:id",
            {
                controller: 'homeEditController',
                controllerAs: "vm",
                templateUrl: "Views/Home/edit.html"
            });
    });
})();