let result = (function solve() {
    let currentId = 'depot';
    let oldName ='';
    function depart() {
        let req = {
            url: `https://judgetests.firebaseio.com/schedule/${currentId}.json`,
            success: displayBus,
            error: handleError
        };
        $.ajax(req);
    }
    function arrive() {
        $('#info').find('span').text(`Arrive at ${oldName}`);
        $('#depart').prop('disabled', false);
        $('#arrive').prop('disabled', true);
    }

    function displayBus(busData) {
        oldName = busData['name'];
        currentId = busData['next'];
        $('#info').find('span').text(`Next stop ${busData['name']}`);
        $('#depart').prop('disabled', true);
        $('#arrive').prop('disabled', false);
    }

    function handleError(msg) {
        $('#info').find('span').text('Error');
        $('#depart').prop('disabled', true);
        $('#arrive').prop('disabled', true);
    }

    return {
        depart,
        arrive
    };
})();