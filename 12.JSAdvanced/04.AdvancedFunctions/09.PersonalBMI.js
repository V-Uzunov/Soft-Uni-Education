function personalBMI() {
    function getStatus() {
        if (bmi < 18.5) {
            return 'underweight';
        }
        if (bmi < 25) {
            return 'normal';
        }
        if (bmi < 30) {
            return 'overweight';
        }
        if (bmi >= 30) {
            return 'obese';
        }
    }

    let [name, age, weight, height] = arguments;
    let heightInMeters = height / 100;
    let bmi = weight / Math.pow(heightInMeters, 2);
    let status = getStatus();
    let result = {
        name: name,
        personalInfo:{
            age: Math.round(age),
            weight: Math.round(weight),
            height: Math.round(height)         
        },
        BMI: Math.round(bmi),
        status: status 
    };

    if (status === 'obese') {
        result['recommendation'] = 'admission required';
    }
    return result;
}

console.log(personalBMI('Peter', 29, 75, 182));