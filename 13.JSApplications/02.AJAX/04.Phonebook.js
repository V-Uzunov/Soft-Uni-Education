$(function () {
    $('#btnLoad').click(loadContacts);
    $('#btnCreate').click(createContact);
    let baseServiceUrl =
        'https://phonebook-uzunov.firebaseio.com/Phonebook';
    function loadContacts() {
        $('#phonebook').empty();
        $.get(baseServiceUrl + '.json')
            .then(displayContacts)
            .catch(displayError);

    }
    function displayContacts(contacts) {
        for (let key in contacts) {
            let person = contacts[key]['person'];
            let phone = contacts[key]['phone'];
            let li = $('<li>');
            li.text(person + ': ' + phone + ' ');
            $('#phonebook').append(li);
            li.append($('<button>Delete</button>')
                .click(deleteContact.bind(this, key)));
        }

    }
    function displayError(err) {
        $('#phonebook').append($('<li>Error</li>'));

    }
    function createContact() {
        let newContactJSON = JSON.stringify({
            person: $('#person').val(),
            phone: $('#phone').val()
        });
        $.post(baseServiceUrl + '.json', newContactJSON)
            .then(loadContacts)
            .catch(displayError);
        $('#person').val('');
        $('#phone').val('');

    }
    function deleteContact(key) {
        let request = {
            method: 'DELETE',
            url: baseServiceUrl + '/' + key + '.json'
        };
        $.ajax(request)
            .then(loadContacts)
            .catch(displayError);

    }
});
