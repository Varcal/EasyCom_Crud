(function () {

    angular.module("app").controller("homeCreateController", homeCreateController);

    homeCreateController.$inject = ["$scope", "$location", "programadorService", "especialidadeTipoService", "disponibilidadeService", "horarioTrabalhoService"];

    function homeCreateController($scope, $location, programadorService, especialidadeTipoService, disponibilidadeService, horarioTrabalhoService) {
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
        vm.salvar = salvar;

        activate();

        function activate() {
            inicializar();
            habilitarForm1();
        }
        
        function habilitarForm1() {
            vm.habilitaForm1 = true;
            vm.habilitaForm2 = false;
            vm.habilitaForm3 = false;
        }

        function habilitarForm2() {

            if (validaForm1()) return;

            vm.errorForm1 = false;
            vm.habilitaForm1 = false;
            vm.habilitaForm2 = true;
            vm.habilitaForm3 = false;
        }

        function habilitarForm3() {
            vm.habilitaForm1 = false;
            vm.habilitaForm2 = false;
            vm.habilitaForm3 = true;
        }
        
        function salvar() {
            vm.loading = true;
            vm.errorForm3 = false;


            angular.forEach(vm.especialidades, function (value, key) {
                if (value.nota < 0 && value.obrigatoria) {
                    vm.errorForm3 = true;
                }

                if (value.nota >= 0) {
                    vm.programador.especialidades.push(value);
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

            angular.forEach(vm.horarios, function (value, key) {
                if (value.selected) {
                    vm.programador.horarios.push(value);
                }
            });

            
            programadorService.registrar(vm.programador)
                .then(successCallback, errorCallBack);

            function successCallback(response) {
                toastr.success("Programador cadastrado com sucesso", "SUCESSO");
                inicializar();
                $scope.formProgramador.$setPristine();
                vm.loading = false;
                $location.path("/");
            }

            function errorCallBack(error) {
                if (error.status === 400 && error.data) {
                    vm.notificacoes = error.data.errors;
                } else {
                    toastr.error("Não foi possível efetuar o cadastro", "ERRO");
                    console.log(error);
                }

                vm.loading = false;
            }
        }
        
        function inicializar() {

            carregarDisponibilidade();

            carregarEspecilidades();

            carregarHorarios();


            vm.contaTipoList = [
                { id: 1, descricao: "Corrente" },
                { id: 2, descricao: "Poupança" }
            ];

            vm.selectionDisponibilidade = [];
            vm.selectionHorario = [];

            vm.programador = {
                dadosCadastro: {},
                dadosBancarios: {},
                especialidades: [],
                disponibilidades: [],
                horarios: []
            }

            habilitarForm1();
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