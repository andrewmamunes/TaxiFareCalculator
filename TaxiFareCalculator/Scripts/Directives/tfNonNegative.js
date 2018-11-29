angular.module('taxiFareCalculatorApp')
    .directive('tfNonNegative', function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attr, ngModel) {
                ngModel.$validators.nonnegative = function (modelValue) {
                    return modelValue >= 0;
                }
            }

        }
    })