function objAssign(params) {
    let obj = {};
    
    obj[params[0]] = params[1];
    obj[params[2]] = params[3];
    obj[params[4]] = params[5];

    return obj;
}

console.log(objAssign(['name', 'Pesho', 'age', '23', 'gender', 'male']));
console.log(objAssign(['ssid', '90127461', 'status', 'admin', 'expires', '600']));

