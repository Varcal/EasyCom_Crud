(function () {
    "use strict";

    angular.module("app").controller("homeEditController", homeEditController);

    homeEditController.$inject = ["$scope", "$routeParams", "$location", "programadorService", "especialidadeTipoService", "disponibilidadeService", "horarioTrabalhoService"];

    function homeEditController($scope, $routeParams, $location, programadorService, especialidadeTipoService, disponibilidadeService, horarioTrabalhoService) {
        var vm = this;

        vm.emailPattern = /^([a-zA-Z0-9])+([a-zA-Z0-9._%+-])+@([a-zA-Z0-9_.-])+\.(([a-zA-Z]){2,6})$/;
        vm.notificacoes = [];
        vm.loading = false;
        vm.errorForm3 = false;

        vm.habilitarForm1 = habilitarForm1;
        vm.habilitarForm2 = habilitarForm2;
        vm.habilitarForm3 = habilitarForm3;
        vm.selectedDisponibilidade = selectedDisponibilidade;
        vm.selectedHorario = selectedHorario;
        vm.selectionDisponibilidade = [];
        vm.selectionHorario = [];

        var id = $routeParams.id;

        vm.alterar = alterar;

        activate();

        function activate() {
            inicializar();
            obterPorId();
        }


        function alterar() {

            vm.loading = true;
            vm.programador.disponibilidades = [];
            vm.errorForm3 = false;

            angular.forEach(vm.especialidades, function (value, key) {
                if (value.nota < 0 && value.obrigatoria) {
                    vm.errorForm3 = true;
                }

                if (value.nota >= 0) {
                    angular.forEach(vm.programador.especialidades, function (v, key) {
                        if (value.especialidadeTipoId === v.especialidadeTipoId) {
                            v.nota = value.nota;
                        }
                    });
                }
            });

            if (vm.errorForm3) {
                vm.loading = false;
                return;
            }

            angular.forEach(vm.disponibilidades, function (value, key) {
                if (value.selected) {
                    vm.programador.disponibilidades.push(value);
                }
            });

            vm.programador.horarios = [];
            angular.forEach(vm.horarios, function (value, key) {
                if (value.selected) {
                    vm.programador.horarios.push(value);
                }
            });

            

            programadorService.alterar(vm.programador)
                .then(successCallback, errorCallback);



            function successCallback(response) {
                toastr.success("Programador alterardo com sucesso", "SUCESSO");
                vm.loading = false;
                $location.path("/");
            }

            function errorCallback(error) {
                if (error.status === 400 && error.data) {
                    vm.notificacoes = error.data.errors;
                } else {
                    toastr.error("Erro ao alterar programador", "ERRO");
                    console.error(error);
                }

                vm.loading = false;
            }
        }

        function obterPorId() {
            programadorService.obterPorId(id)
                .then(function successCallback(response) {
                    vm.programador = response.data;
                    carregarTela();

                },
                function errorCallback(error) {
                    toastr.error("Erro ao tentar obter programador", "ERRO");
                    console.log(error);
                });
        }

        function habilitarForm1() {
            vm.habilitaForm1 = true;
            vm.habilitaForm2 = false;
            vm.habilitaForm3 = false;
        }

        function habilitarForm2() {
            if (validaForm1()) return;

            vm.habilitaForm1 = false;
            vm.habilitaForm2 = true;
            vm.habilitaForm3 = false;
        }

        function habilitarForm3() {
            vm.habilitaForm1 = false;
            vm.habilitaForm2 = false;
            vm.habilitaForm3 = true;
        }

        function inicializar() {
            carregarDisponibilidade();

            carregarEspecilidades();

            carregarHorarios();

            vm.contaTipoList = [
                { id: 1, descricao: "Corrente" },
                { id: 2, descricao: "Poupança" }
            ];


            habilitarForm1();
        }

        function carregarTela() {
            angular.forEach(vm.programador.disponibilidades, function (value, key) {
                angular.forEach(vm.disponibilidades, function (v, key) {
                    if (value.id === v.id) {
                        v.selected = true;
                    }
                });
            });

            angular.forEach(vm.programador.horarios, function (value, key) {
                angular.forEach(vm.horarios, function (v, key) {
                    if (value.id === v.id) {
                        v.selected = true;
                    }
                });
            });

            angular.forEach(vm.programador.especialidades, function (value, key) {
                angular.forEach(vm.especialidades, function (v, key) {
                    if (value.especialidadeTipoId === v.especialidadeTipoId) {
                        v.nota = value.nota;
                    }
                });
            });
        }

        function selectedDisponibilidade() {
            return filterFilter(vm.disponibilidades, { selected: true });
        }

        function selectedHorario() {
            return filterFilter(vm.horarios, { selected: true });
        }

        function validaForm1() {
            var form = $scope.formProgramador;

            if ((form.email.$invalid || form.email.$error.pattern) || form.nome.$invalid || form.skype.$invalid || form.telefone.$invalid ||
                form.cidade.$invalid || form.estado.$invalid || form.pretensaoSalarial.$invalid || vm.selectionDisponibilidade.length <= 0
                || vm.selectionHorario.length <= 0) {
                vm.errorForm1 = true;
                return vm.errorForm1;
            }
        }

        function carregarDisponibilidade() {
            disponibilidadeService.selecionarTodos()
                .then(successCallback, errorCallback);

            function successCallback(response) {
                vm.disponibilidades = response.data;

                $scope.$watch('vm.disponibilidades|filter:{selected:true}', function (nv) {
                    vm.selectionDisponibilidade = nv.map(function (disponibilidade) {
                        return disponibilidade;
                    });
                }, true);

            }

            function errorCallback(error) {
                toastr.error("Erros ao carregar as disponibilidades", "ERRO");
                console.log(error);
            }
        }

        function carregarEspecilidades() {
            especialidadeTipoService.selecionarTodos()
                .then(successCallback, errorCallback);

            function successCallback(response) {
                vm.especialidades = response.data;
            }

            function errorCallback(error) {
                toastr.error("Erros ao carregar as especialidades", "ERRO");
                console.log(error);
            }
        }

        function carregarHorarios() {
            horarioTrabalhoService.selecionarTodos()
                .then(successCallback, errorCallback);

            function successCallback(response) {
                vm.horarios = response.data;

                $scope.$watch('vm.horarios|filter:{selected:true}', function (nv) {
                    vm.selectionHorario = nv.map(function (horario) {
                        return horario;
                    });
                }, true);

            }

            function errorCallback(error) {
                toastr.error("Erros ao carregar os horários trabalho", "ERRO");
                console.log(error);
            }
        }
    }
})();