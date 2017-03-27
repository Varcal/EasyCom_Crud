(function() {
    "use strict";

    angular.module("app").factory("especialidadeTipoService", especialidadeTipoService);

    especialidadeTipoService.$inject = ["$http", "SETTINGS"];

    function especialidadeTipoService($http, SETTINGS) {
        return {
            selecionarTodos: selecionarTodos
        };

        function selecionarTodos() {
            return $http.get(SETTINGS.SERVICE_URL + "api/especialidadeTipo");
        }
    }
})();