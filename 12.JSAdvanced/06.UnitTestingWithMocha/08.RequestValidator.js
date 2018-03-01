function validateRequest(obj) {
    let validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    let uriPattern = /^[A-Za-z\d\.\*]+$/gm;
    let validVersion = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    let messagePattern = /^[^<>\\&'"]*$/gm;

    if (!obj.method || !validMethods.includes(obj.method)) {
        throw new Error('Invalid request header: Invalid Method');
    }
    if (!obj.uri || !uriPattern.test(obj.uri)) {
        throw new Error('Invalid request header: Invalid URI');
    }
    if (!obj.version || !validVersion.includes(obj.version)) {
        throw new Error('Invalid request header: Invalid Version');
    }
    if (!obj.message || !messagePattern.test(obj.message)) {

        if(obj.message === ''){
            return obj;
         }
        throw new Error('Invalid request header: Invalid Message');
    }

    return obj;
}

console.log(validateRequest({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
}));
