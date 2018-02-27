function solve() {
    let obj = {
        extend: function(template){
            for (const key in template) {
                if (template.hasOwnProperty(key)) {
                    const element = template[key];
                    if (typeof element === 'function') {
                        Object.getPrototypeOf(obj)[key] = element;
                    }else{
                        obj[key] = element;
                    }
                }
            }
        }
    };
    return obj;
}

let myObj = solve();
let template = {
    extensionMethod: function () {
        console.log('Method');
    },
  extensionProperty: 'someProp'
};
myObj.extend(template);
console.log(myObj);
console.log(Object.getPrototypeOf(myObj));