function escaping(array) {
    let result = '<ul>\n';
    
    for (const text of array) {
        result += '<li>' + htmlEscape(text) + '</li>\n';
    }

    result += '</ul>';

    function htmlEscape(str) {
        return str.replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }
    
    console.log(result);
}

escaping(['<b>unescaped text</b>', 'normal text']);