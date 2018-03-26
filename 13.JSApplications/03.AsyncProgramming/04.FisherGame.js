function attachEvents() {
    const baseUrl = 'https://baas.kinvey.com/appdata/kid_ryxpjXUqz/';
    const kinveyUsername = 'veso';
    const kinveyPassword = 'veso';
    const base64auth = btoa(kinveyUsername + ':' + kinveyPassword);
    const authHeaders = {
        'Authorization': 'Basic ' + base64auth,
        'Content-type': 'application/json'
    };

    $('#aside').find('.load').click(attachLoad);
    $('#addForm').find('.add').click(attachAdd);
    let catches = $('#catches');

    function request(method, endpoint, data) {
        return $.ajax({
            method: method,
            url: baseUrl + endpoint,
            headers: authHeaders,
            data: data
        });
    }

    function attachLoad() {
        request('GET', 'biggestCatches/')
            .then(listAllCatches)
            .catch(handleError);
    }
    function listAllCatches(allCatches) {
        catches.empty();
        for (const data of allCatches) {
            let dataId = data['_id'];
            let angler = data['angler'];
            let weight = Number(data['weight']);
            let species = data['species'];
            let location = data['location'];
            let bait = data['bait'];
            let captureTime = Number(data['captureTime']);
            appendCatches(catches, dataId, angler, weight, species, location, bait, captureTime);
        }
    }
    function appendCatches(catches, dataId, angler, weight, species, location, bait, captureTime) {
        catches.append($(`<div class="catch" data-id="${dataId}">`)
            .append($('<label>Angler</label>'))
            .append($(`<input type="text" class="angler" value="${angler}"/>`))
            .append($('<label>Weight</label>'))
            .append($(`<input type="number" class="weight" value="${weight}"/>`))
            .append($('<label>Species</label>'))
            .append($(`<input type="text" class="species" value="${species}"/>`))
            .append($('<label>Location</label>'))
            .append($(`<input type="text" class="location" value="${location}"/>`))
            .append($('<label>Bait</label>'))
            .append($(`<input type="text" class="bait" value="${bait}"/>`))
            .append($('<label>Capture Time</label>'))
            .append($(`<input type="number" class="captureTime" value="${captureTime}"/>`))
            .append($('<button class="update">Update</button>').click(attachUpdate))
            .append($('<button class="delete">Delete</button>').click(attachDelete.bind(this, dataId))));
    }
    function attachAdd() {
        request('POST', 'biggestCatches/', addDataObj('#addForm'))
            .then(attachLoad)
            .catch(handleError);
    }
    function attachUpdate() {
        let catchItem = $(this).parent();
        let dataId = catchItem.attr('data-id');

        request('PUT', `biggestCatches/${dataId}`, addDataObj(catchItem))
        .then(attachLoad)
        .catch(handleError);
    }
    function attachDelete(dataId) {
        request('DELETE', `biggestCatches/${dataId}`)
            .then(attachLoad)
            .catch(handleError);
    }
    function addDataObj(formClass) {
        let addFormInputs = $(formClass);
        return JSON.stringify({
            'angler': addFormInputs.find('.angler').val(),
            'weight': Number(addFormInputs.find('.weight').val()),
            'species': addFormInputs.find('.species').val(),
            'location': addFormInputs.find('.location').val(),
            'bait': addFormInputs.find('.bait').val(),
            'captureTime': Number(addFormInputs.find('.captureTime').val())
        });
    }
    function handleError(err) {
        alert(`Error happened: ${err.statusText}`);
    }
}