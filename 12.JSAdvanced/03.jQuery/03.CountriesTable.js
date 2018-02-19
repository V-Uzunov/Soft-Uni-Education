function initializeTable() {
    $('#createLink').click(addTowns);

    createTowns('Bulgaria', 'Sofia');
    createTowns('Germany', 'Berlin');
    createTowns('Russia', 'Moscow');
    fixLinks();
    
    function addTowns() {
        let country = $('#newCountryText').val();
        let capital = $('#newCapitalText').val();
        createTowns(country, capital);
        fixLinks();
    }

    function fixLinks() {
        $('tr a').css('display', 'inline');
        $('tr:last-child a:contains(Down)').hide();
        $('tr:eq(2) a:contains(Up)').hide();
    }

    function createTowns(country, capital) {
        $('<tr>')
            .append($(`<td>${country}</td>`))
            .append($(`<td>${capital}</td>`))
            .append($('<td>')
                .append($('<a href="#">[Up]</a>').click(moveUp))
                .append($('<a href="#">[Down]</a>').click(moveDown))
                .append($('<a href="#">[Delete]</a>').click(deleteCountry)))
            .appendTo($('#countriesTable'));
    }
    function moveUp() {
        let currentTableRow = $(this)
        .parent()
        .parent();

        let previousTableRow = currentTableRow.prev();

        currentTableRow.insertBefore(previousTableRow);
        fixLinks();
    }
    function moveDown() {
        let currentTableRow = $(this)
        .parent()
        .parent();

        let nextTableRow = currentTableRow.next();
        currentTableRow.insertAfter(nextTableRow);
        fixLinks();
    }
    function deleteCountry() {
        $(this)
        .parent()
        .parent()
        .remove();
        fixLinks();
    }
}