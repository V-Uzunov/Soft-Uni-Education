function getSummary(summaryBtn) {

    $(summaryBtn).click(function (){
        let summary = $('#content strong').text();
        createSummary(summary);
    });

    function createSummary(summary) {
        //Create elements
        let div = $('<div>');
        div.attr('id', 'summary');
        let title = $('<h2>').text('Summary');
        let paragraph = $('<p>').text(summary);

        //Append elements
        div.append(title);
        div.append(paragraph);
        let parent = $('#content').parent();
        parent.append(div);
    }
}