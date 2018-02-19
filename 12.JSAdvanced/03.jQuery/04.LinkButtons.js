function attachEvents() {
    $('a.button').click(addSelected);

    function addSelected() {
        $('.selected').removeClass('selected');
        $(this).addClass('selected');
    }
}