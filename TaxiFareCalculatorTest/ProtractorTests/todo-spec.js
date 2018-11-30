describe('Taxi fare calculator tests', function () {
    it('should set input values', function () {
        browser.get('http://localhost:50341/');

        element(by.name('minutesAboveSixMph')).sendKeys(5);
        element(by.name('milesBelowSixMph')).sendKeys(2);
        element(by.name('startTime')).sendKeys('05');
        element(by.name('startTime')).sendKeys('30');
        element(by.name('startTime')).sendKeys('PM');
        element(by.name('rideDate')).sendKeys('10-08-2010');

        element(by.name('submitButton')).click().then(function () {
            var result = element(by.name('farePrice')).getAttribute('value');
            expect(result).toEqual('$9.75');
        });
        
        
    });
    it('should disable submit button by resetting', function () {
        browser.get('http://localhost:50341/');

        element(by.name('minutesAboveSixMph')).sendKeys(5);
        element(by.name('milesBelowSixMph')).sendKeys(2);
        element(by.name('startTime')).sendKeys('05');
        element(by.name('startTime')).sendKeys('30');
        element(by.name('startTime')).sendKeys('PM');
        element(by.name('rideDate')).sendKeys('10-08-2010');

        element(by.name('resetButton')).click().then(function () {
            var result = element(by.name('submitButton')).getAttribute('disabled');
            expect(result).toEqual('true');
        });


    });
    it('should reset all fields', function () {
        browser.get('http://localhost:50341/');

        element(by.name('minutesAboveSixMph')).sendKeys(5);
        element(by.name('milesBelowSixMph')).sendKeys(2);
        element(by.name('startTime')).sendKeys('05');
        element(by.name('startTime')).sendKeys('30');
        element(by.name('startTime')).sendKeys('PM');
        element(by.name('rideDate')).sendKeys('10-08-2010');
        element(by.name('submitButton')).click().then(function () {
            element(by.name('resetButton')).click().then(function () {
                var minutesAboveSixMph = element(by.name('minutesAboveSixMph')).getAttribute('value');
                var milesBelowSixMph = element(by.name('milesBelowSixMph')).getAttribute('value');
                var startTime = element(by.name('startTime')).getAttribute('value');
                var rideDate = element(by.name('rideDate')).getAttribute('value');
                var farePrice = element(by.name('farePrice')).getAttribute('value');
                expect(minutesAboveSixMph).toEqual('');
                expect(milesBelowSixMph).toEqual('');
                expect(startTime).toEqual('');
                expect(rideDate).toEqual('');
                expect(farePrice).toEqual('');
            })
        }
    );


    });
    it('should disable submit button because null startTime', function () {
        browser.get('http://localhost:50341/');

        element(by.name('minutesAboveSixMph')).sendKeys(5);
        element(by.name('milesBelowSixMph')).sendKeys(2);
        element(by.name('rideDate')).sendKeys('10-08-2010');
        
        var result = element(by.name('submitButton')).getAttribute('disabled');
        expect(result).toEqual('true');


    });
    it('should disable submit button because null minutesAboveSixMph', function () {
        browser.get('http://localhost:50341/');

        element(by.name('milesBelowSixMph')).sendKeys(2);
        element(by.name('startTime')).sendKeys('05');
        element(by.name('startTime')).sendKeys('30');
        element(by.name('startTime')).sendKeys('PM');
        element(by.name('rideDate')).sendKeys('10-08-2010');

        var result = element(by.name('submitButton')).getAttribute('disabled');
        expect(result).toEqual('true');


    });
    it('should disable submit button because null minutesAboveSixMph', function () {
        browser.get('http://localhost:50341/');
        element(by.name('minutesAboveSixMph')).sendKeys(5);
        element(by.name('startTime')).sendKeys('05');
        element(by.name('startTime')).sendKeys('30');
        element(by.name('startTime')).sendKeys('PM');
        element(by.name('rideDate')).sendKeys('10-08-2010');

        var result = element(by.name('submitButton')).getAttribute('disabled');
        expect(result).toEqual('true');


    });
    it('should disable submit button because negative milesBelowSixMph', function () {
        browser.get('http://localhost:50341/');

        element(by.name('minutesAboveSixMph')).sendKeys(5);
        element(by.name('milesBelowSixMph')).sendKeys(-1);
        element(by.name('startTime')).sendKeys('05');
        element(by.name('startTime')).sendKeys('30');
        element(by.name('startTime')).sendKeys('PM');
        element(by.name('rideDate')).sendKeys('10-08-2010');
        
        var result = element(by.name('submitButton')).getAttribute('disabled');
        expect(result).toEqual('true');


    });
    it('should disable submit button because negative minutesAboveSixMph', function () {
        browser.get('http://localhost:50341/');

        element(by.name('minutesAboveSixMph')).sendKeys(-1);
        element(by.name('milesBelowSixMph')).sendKeys(2);
        element(by.name('startTime')).sendKeys('05');
        element(by.name('startTime')).sendKeys('30');
        element(by.name('startTime')).sendKeys('PM');
        element(by.name('rideDate')).sendKeys('10-08-2010');

        var result = element(by.name('submitButton')).getAttribute('disabled');
        expect(result).toEqual('true');


    });
        
});