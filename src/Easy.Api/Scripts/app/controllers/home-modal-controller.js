(function () {

    angular.module('app').controller('programadorModalController', programadorModalController);

    programadorModalController.$inject = ['$uibModalInstance', 'programadorId'];

    function programadorModalController($uibModalInstance, programadorId) {
        var vm = this;

        vm.programadorId = programadorId;


        vm.ok = function () {
            $uibModalInstance.close(vm.programadorId);
        };

        vm.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };
    }
})();