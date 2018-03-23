function getInfo() {
    let stopId = $('#stopId').val();
    let stopName = $('#stopName');
    let busesUl = $('#buses');
    let baseUrl = `https://judgetests.firebaseio.com/businfo/${stopId}`;
    busesUl.empty();
    let req = {
        url: baseUrl + '.json',
        success: displayBuses,
        error: displayError
    };
    $.ajax(req);

    function displayBuses(data) {
        let busName = data['name'];
        let buses = data['buses'];
        stopName.text(busName);

        for (const bus in buses) {
            busesUl.append(`<li>Bus ${bus} arrives in ${buses[bus]} minutes</li`);
        }
    }
    function displayError(msg) {
        stopName.text('Error');
    }
}