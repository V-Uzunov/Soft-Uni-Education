function search() {
    let word = $('#searchText').val();
    let matches = $(`#towns li:contains(${word})`);
    matches.css('font-weight', 'bold');
    $(`#towns li:not(:contains(${word}))`).css('font-weight', '');
    $('#result').text(`${matches.length} matches found.`);
}