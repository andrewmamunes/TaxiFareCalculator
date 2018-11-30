angular.module('taxiFareCalculatorApp', ['ngMessages'])
    .controller('taxiFareCalculatorController', function ($scope, rideService) {

    var formatter = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD',
    });
    $scope.resetForm = function () {
        $scope.ride = {};
        document.getElementsByName('rideForm')[0].reset();
    }
    $scope.calculateFare = function (isValid) {
        if (isValid) {
            //promise
            rideService.calculateFare($scope.ride)
                // resolve promise
                .then(function (response) {
                    $scope.ride.farePrice = formatter.format(response.data);
                }, function (error) {
                    alert(error.data);
                })
        } else {
            alert('The ride that you submitted is invalid.');
        }
    }
});