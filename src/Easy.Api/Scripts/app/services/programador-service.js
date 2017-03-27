(function() {
    
    angular.module("app").factory("programadorService", programadorService);

    programadorService.$inject = ["$http","SETTINGS"];

    function programadorService($http, SETTINGS) {
        return {
            registrar: registrar,
            alterar: alterar,
            excluir: excluir,
            obterPorId: obterPorId,
            selecionarTodos: selecionarTodos
        };

        function registrar(programador) {
            return $http.post(SETTINGS.SERVICE_URL + "api/programador/", programador);
        }

        function alterar(programador) {
            return $http.put(SETTINGS.SERVICE_URL + "api/programador/", programador);
        }

        function excluir(id) {
            return $http.delete(SETTINGS.SERVICE_URL + "api/programador/" + id);
        }

        function obterPorId(id) {
            return $http.get(SETTINGS.SERVICE_URL + "api/programador/" + id);
        }

        function selecionarTodos() {
            return $http.get(SETTINGS.SERVICE_URL + "api/programador");
        }
    }
})();