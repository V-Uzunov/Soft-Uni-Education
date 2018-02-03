function scoreToHtml(array) {
    let result = '<table>\n';
    result += '  <tr><th>name</th><th>score</th></tr>\n';
    let parseArray = JSON.parse(array);
    for (const obj of parseArray) {
        result +=`  <tr><td>${htmlEscape(obj['name'] + '')}</td><td>${htmlEscape(obj['score'] + '')}</td></tr>\n`;
    }
    result += '</table>';

    function htmlEscape(str) {
        return str.replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }

    console.log(result);
}

scoreToHtml('[{"name":"Pesho","score":479},{"name":"Gosho","score":205}]');