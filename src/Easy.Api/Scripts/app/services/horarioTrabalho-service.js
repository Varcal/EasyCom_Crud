(function () {
    "use strict";

    angular.module("app").factory("horarioTrabalhoService", horarioTrabalhoService);

    horarioTrabalhoService.$inject = ["$http", "SETTINGS"];

    function horarioTrabalhoService($http, SETTINGS) {
        return {
            selecionarTodos: selecionarTodos
        };

        function selecionarTodos() {
            return $http.get(SETTINGS.SERVICE_URL + "api/horarioTrabalho");
        }
    }
})();