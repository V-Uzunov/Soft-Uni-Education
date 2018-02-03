function jsonToHTML(array) {
    let result = '<table>\n';
    let parsedArray = JSON.parse(array);
    let keys = Object.keys(parsedArray[0]);
    result +='    <tr>';
    for (const key of keys) {
        result += `<th>${key}</th>`;
    }
    result +='</tr>\n';
    for (const value of parsedArray) {
        result += '    <tr>';
        for (const val of Object.keys(value)) {
            result += `<td>${htmlEscape(value[val] + '')}</td>`;
        }
        result += '</tr>\n';
    }

    result += '</table>';

    console.log(result);
    function htmlEscape(str) {
        return str.replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }
}

jsonToHTML('[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]');