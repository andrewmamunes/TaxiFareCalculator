angular.module('taxiFareCalculatorApp')
    .directive('tfNonNegative', function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attr, ngModel) {
                element.attr('min', 0);
                ngModel.$validators.nonnegative = function (modelValue) {
                    return modelValue >= 0;
                }
            }

        }
    })