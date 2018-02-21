function getArticleGenerator(articles) {

    let container = $('#content');
    return function () {
        if (articles.length > 0) {
            let article = $(`<article>${articles.shift()}</article>`);
            container.append(article);
        }
    };
}