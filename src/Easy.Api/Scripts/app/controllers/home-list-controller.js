(function() {
    "use strict";

    angular.module("app").controller("homeListController", homeListController);

    homeListController.$inject = ["$uibModal", "DTOptionsBuilder", "DTColumnDefBuilder", "programadorService"];

    function homeListController($uibModal, DTOptionsBuilder, DTColumnDefBuilder, programadorService) {
        var vm = this;

        vm.programadores = [];


        vm.dtOptions = DTOptionsBuilder.newOptions()
            .withPaginationType('full_numbers')
            .withDisplayLength(10);
        vm.dtColumnDefs = [
            DTColumnDefBuilder.newColumnDef(1).notSortable()
        ];

        vm.openModal = openModal;

        activate();

        function activate() {
            selecionarTodos();
        }

        function selecionarTodos() {
            programadorService.selecionarTodos()
                .then(function successCallback(response) {

                    vm.programadores = response.data;

                }, function errorCallback(error) {
                    toastr.error("Occoreu um erro ao tentar selecionar os programadores", "ERRO");
                    console.log(error);
                });
        }

        function openModal(programadorId, size, parentSelector) {
            var parentElem = parentSelector ?
                angular.element($document[0].querySelector('.modal-demo ' + parentSelector)) : undefined;
            var modalInstance = $uibModal.open({
                animation: vm.animationsEnabled,
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: 'ProgramadorModal.html',
                controller: 'programadorModalController',
                controllerAs: 'vm',
                size: size,
                appendTo: parentElem,
                resolve: {
                    programadorId: function () {
                        return programadorId;
                    }
                }
            });

            modalInstance.result.then(function (programadorId) {
                excluir(programadorId);
            });
        }

        function excluir(id) {
            programadorService.excluir(id)
                .then(successCallback, errorCallback);

            function successCallback() {
                toastr.success("Programador excluído com sucesso", "SUCESSO");
                activate();
            }

            function errorCallback(error) {
                toastr.error("Erro ao excluir programador", "ERRO");
            }
        }
    }
})();