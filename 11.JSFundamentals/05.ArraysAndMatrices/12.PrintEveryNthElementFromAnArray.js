function everyStepElement(array) {
  let step = Number(array[array.length - 1]);
  array.pop();

  for (let i = 0; i < array.length; i+=step){
    console.log(array[i]);
  }
}

everyStepElement(['5', '20', '31', '4', '20', '2']);