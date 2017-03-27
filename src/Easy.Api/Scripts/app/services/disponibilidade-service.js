(function () {
    "use strict";

    angular.module("app").factory("disponibilidadeService", disponibilidadeService);

    disponibilidadeService.$inject = ["$http", "SETTINGS"];

    function disponibilidadeService($http, SETTINGS) {
        return {
            selecionarTodos: selecionarTodos
        };

        function selecionarTodos() {
            return $http.get(SETTINGS.SERVICE_URL + "api/disponibilidade");
        }
    }
})();