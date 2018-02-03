function jsonTable(array) {
    let result = '<table>\n';

    for (let i = 0; i < array.length; i++) {
        let elements = JSON.parse(array[i]);
        result +='	<tr>\n';
        result +=`		<td>${htmlEscape(elements['name'] + '')}</td>\n`;
        result +=`		<td>${htmlEscape(elements['position'] + '')}</td>\n`;
        result +=`		<td>${htmlEscape(elements['salary'] + '')}</td>\n`;
        result +='	<tr>\n';      
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

jsonTable(['{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
 '{"name":"Georgi","position":"Lecturer","salary":1000}']);