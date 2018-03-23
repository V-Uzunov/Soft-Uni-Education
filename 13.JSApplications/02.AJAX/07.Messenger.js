function attachEvents() {
    let url = 'https://messenger-uzunov.firebaseio.com/messenger/.json';
    $('#refresh').click(attachRefresh);
    $('#submit').click(attachSend);
    
    function attachSend() {
        let messageJson = JSON.stringify({
            author: $('#author').val(),
            content: $('#content').val(),
            timestamp: Date.now()
        });
        let req = {
            method: 'POST',
            url: url,
            data: messageJson,
            success: attachRefresh
        }; 
        $.ajax(req);
    }

    function attachRefresh() {
        let req = {
            url: url,
            success: displayMsg
        };
        $.ajax(req);
    }

    function displayMsg(messeges) {
        let textArea = $('#messages');
        let resultText = '';
        for (let key in messeges) {
            let name = messeges[key]['author'];
            let msg = messeges[key]['content'];
            resultText += `${name}: ${msg}\n`;
        }
        textArea.append(resultText);
    }
}