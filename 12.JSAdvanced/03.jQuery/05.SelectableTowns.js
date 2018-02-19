function attachEvents() {
    $('ul#items li').click(selectItems);
    $('#showTownsButton').click(showTowns);

    function selectItems() {
        let li = $(this);
        if (li.attr('data-selected')) {
            li.removeAttr('data-selected');
            li.css('background', '');
        } else {
            li.attr('data-selected', 'true');
            li.css('background', '#DDD');
        }
    }

    function showTowns() {
        let result =
            $('#items li[data-selected=true]')
            .toArray()
            .map(li => li.textContent)
            .join(', ');

        $('#selectedTowns').text(`Selected towns: ${result}`);
    }
}