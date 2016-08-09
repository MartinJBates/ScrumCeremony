angular.module('app')
    .service('RetrospectiveService', ['$http', retrospectiveService]);

function retrospectiveService($http) {

    this.getAllRetrospectives = function (date) {
        var promise = $http.get('/api/retrospective' + (date !== undefined ? '/' + date : '')).then(function (response) {
            return response.data;
        });
        return promise;
    }

    this.addRetrospective = function (formData) {
        var promise = $http.post('/api/retrospective', formData).then(function (response) {
            return response.data;
        });
        return promise;
    }

    this.addRetrospectiveFeedback = function (retrospectiveName, formData) {
        console.log(formData);
        var promise = $http.post('/api/retrospective/addfeedback?name=' + encodeURIComponent(retrospectiveName), formData).then(function (response) {
            return response.data;
        });
        return promise;
    }
}