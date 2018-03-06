class SortList {
    constructor() {
        this.list = [];
        this.size = 0;
    }
    add(element) {
        this.list.push(element);
        this.size++;
        this.sort();
    }
    remove(index) {
        if (index >= 0 && index < this.list.length) {
            this.list
                .splice(index, 1);
            this.size--;
        }
    }
    get(index) {
        if (index >= 0 && index < this.list.length) {
            return this.list[index];
        }
    }
    sort() {
        return this.list.sort((a, b) => a - b);
    }
}

let myClass = new SortList();
myClass.add('Test');
myClass.add('Test2');
myClass.add('Test3');
console.log(myClass.sort());
console.log(myClass.get(2));
myClass.remove(1);
console.log(myClass.sort());