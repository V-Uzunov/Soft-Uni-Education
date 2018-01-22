function distance(input) {
    let dist1= (input[0] / 3.6) * input[2];
    let dist2= (input[1] / 3.6) * input[2];
    let delta = Math.abs(dist1- dist2);
    console.log(delta);
}

distance([0, 60, 3600]);
distance([11, 10, 120]);
distance([5, -5, 40]);
