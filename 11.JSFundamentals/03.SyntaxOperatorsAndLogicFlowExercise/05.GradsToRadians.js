function gradsToRadians(params) {
    let degree = params * 0.9 % 360;
    if (degree < 0){
        degree += 360;
    }
    console.log(degree);
}

gradsToRadians(100);
gradsToRadians(400);
gradsToRadians(850);
gradsToRadians(-50);