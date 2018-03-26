function attachEvents() {

    $('#submit').click(attachSubmit);

    function attachSubmit() {
        let req = {
            url: 'https://judgetests.firebaseio.com/locations.json',
            success: getWeatherData,
            error: handleError
        };
        $.ajax(req);
    }
    function getWeatherData(data) {
        let inputTown = $('#location').val();
        let requestCode = data
            .filter(l => l['name'] === inputTown)
            .map(c => c['code'])[0];

        if (!requestCode) {
            handleError(); // If the code does not exist (handle error)
        }
        let currentWeatherReq = $.ajax({
            url: `https://judgetests.firebaseio.com/forecast/today/${requestCode}.json`
        });
        let upcomingWeatherReq = $.ajax({
            url: `https://judgetests.firebaseio.com/forecast/upcoming/${requestCode}.json`
        });

        Promise.all([currentWeatherReq, upcomingWeatherReq])
            .then(displayWeather)
            .catch(handleError);

    }
    function displayWeather([currentWeatherReq, upcomingWeatherReq]) {
        let weatherIcon = {
            'Sunny': '&#x2600;', // ☀
            'Partly sunny': '&#x26C5;',// ⛅
            'Overcast': '&#x2601;', // ☁
            'Rain': '&#x2614;', // ☂
            'Degrees': '&#176;'   // °
    
        };
        $('#forecast').css('display', 'block'); //Unlock div
        displayCurrentWeather();
        displayUpcomingWeather();
        
        function displayCurrentWeather() {
            let current = $('#current');
            current.empty();
            let condition = currentWeatherReq['forecast']['condition'];
            let name = currentWeatherReq['name'];
            let low = currentWeatherReq['forecast']['low'];
            let high = currentWeatherReq['forecast']['high'];
            current.append('<div class="label">Current conditions</div>');
            let spanSymbol = $('<span>')
                .addClass('condition symbol')
                .html(weatherIcon[condition]);
            let spanCondition = $('<span>')
                .addClass('condition')
                .append($('<span>')
                    .addClass('forecast-data')
                    .text(name))
                .append($('<span>')
                    .addClass('forecast-data')
                    .html(`${low}&#176;/${high}&#176;`))
                .append($('<span>')
                    .addClass('forecast-data')
                    .text(condition));
    
            current.append(spanSymbol)
                .append(spanCondition);
        }
        function displayUpcomingWeather() {
            let upcoming = $('#upcoming');
            upcoming.empty();
            upcoming.append($('<div class="label">Three-day forecast</div>'));
            let forecast = upcomingWeatherReq['forecast'];
            for (const items of forecast) {
                let condition = items['condition'];
                let low = items['low'];
                let high = items['high'];
                let spanSymbol = $('<span>')
                    .addClass('condition')
                    .html(weatherIcon[condition]);
                let spanCondition = $('<span>')
                    .addClass('upcoming')
                    .append($('<span>')
                        .addClass('forecast-data')
                        .html(`${low}&#176;/${high}&#176;`))
                    .append($('<span>')
                        .addClass('forecast-data')
                        .text(condition));
    
                upcoming.append(spanSymbol)
                    .append(spanCondition);
            }
        }
    }
    
    function handleError(msg) {
        $('#forecast')
            .css('display', 'block') // Unlock div
            .text('Error');
    }
}