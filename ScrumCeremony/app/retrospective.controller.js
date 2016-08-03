angular.module('app')
    .controller('RetrospectiveController', ['RetrospectiveService', retrospectiveController]);

function retrospectiveController(retrospectiveService) {
    var vm = this;

    vm.searchDate = '';
    vm.retrospectives = [];
    vm.form = {};

    vm.search = getRetrospectives;
    vm.addRetrospective = addRetrospective;
    vm.addRetrospectiveFeedback = addRetrospectiveFeedback;
    vm.resetAddForm = resetAddForm;

    function getRetrospectives() {

        retrospectiveService.getAllRetrospectives(vm.searchDate)
			.then(function (retrospectives) {
			    vm.retrospectives = retrospectives;
			});
    }

    function addRetrospective() {
        vm.retrospectiveAddedSuccessfully = false;

        vm.form.participants = vm.form.participants.split(',');

        retrospectiveService.addRetrospective(vm.form)
	        .then(function (result) {
	            if (result) {
	                vm.retrospectiveAddedSuccessfully = true;
	            }

	            getRetrospectives();
	        });
    }

    function addRetrospectiveFeedback() {

        retrospectiveService.addRetrospectiveFeedback(vm.form.name, vm.formFeedback)
            .then(function (result) {
                getRetrospectives();
            });
    }

    function resetAddForm() {
        vm.form = {};
        vm.formFeedback = {};
        vm.retrospectiveAddedSuccessfully = false;
    }
}