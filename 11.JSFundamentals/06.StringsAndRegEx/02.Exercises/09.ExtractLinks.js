function extractor(array) {
    let text = array.join();
    let pattern = /www\.[A-Za-z0-9\-]+\.[a-z]+(?:\.[a-z]+)*/gm;
    let matches = pattern.exec(text);
    let result = [];
    while (matches) {
        result.push(matches);
        matches = pattern.exec(text);
    }
    console.log(result.join('\n'));
}

extractor(['Join WebStars now for free, at www.web-stars.com You can also support our partners:  Internet - www.internet.com  WebSpiders - www.webspiders101.com  Sentinel - www.sentinel.-ko']);
