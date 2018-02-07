function solve(message) {
    let tagValidator = /^<message((?:\s+[a-z]+="[A-Za-z0-9 .]+"\s*?)*)>((?:.|\n)+?)<\/message>$/;

    let tokens = tagValidator.exec(message);
    if (!tokens) {
        console.log("Invalid message format");
        return;
    }
    let [match, attributes, body] = tokens;

    let attributeValidator = /\s+([a-z]+)="([A-Za-z0-9 .]+)"\s*?/g;
    let sender = '';
    let recipient = '';
    let attributeTokens = attributeValidator.exec(attributes);
    while (attributeTokens) {
        if (attributeTokens[1] === 'to') {
            recipient = attributeTokens[2];
        } else if (attributeTokens[1] === 'from') {
            sender = attributeTokens[2];
        }
        attributeTokens = attributeValidator.exec(attributes);
    }
    if (sender === '' || recipient === '') {
        console.log("Missing attributes");
        return;
    }

    body = body.replace(/\n/g, '</p>\n    <p>');
    let html = `<article>\n  <div>From: <span class="sender">${sender}</span></div>\n`;
    html += `  <div>To: <span class="recipient">${recipient}</span></div>\n`;
    html += `  <div>\n    <p>${body}</p>\n  </div>\n</article>`;
    console.log(html);
}

solve('<message to="Bob" from="Alice" timestamp="1497254092">Hey man, what\'s up?</message>');