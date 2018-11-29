angular.module('taxiFareCalculatorApp')
    .service('rideService', function ($http) {

        this.calculateFare = function (ride) {
            return $http.post('http://' + location.host + '/fare/calculateFare', JSON.stringify(ride));
        }
    })
