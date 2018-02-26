function getFibonator(){
    let fib1 = 0;
    let fib2 = 1;
    
    return function (){
        let fib3 = fib1 + fib2;
        fib1 = fib2;
        fib2 = fib3;
        
        return fib1;
    };
}

let fib = getFibonator();
fib(); // 1
fib(); // 1
fib(); // 2
fib(); // 3
fib(); // 5
fib(); // 8
fib(); // 13
