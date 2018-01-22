function distanceIn3D(input) {
    let x1 = input[0];
    let y1 = input[1];
    let z1 = input[2];
    let x2 = input[3];
    let y2 = input[4];
    let z2 = input[5];

    let distance = Math.pow(x1 - x2, 2) + Math.pow(y1-y2, 2) + Math.pow(z1-z2, 2);
    
    console.log(Math.sqrt(distance));
}

distanceIn3D([1, 1, 0, 5, 4, 0]);
distanceIn3D([3.5, 0, 1, 0, 2, -1]);