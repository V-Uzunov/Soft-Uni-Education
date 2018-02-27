function solve(obj) {
    if (obj.handsShaking) {
        obj.bloodAlcoholLevel += (0.1 * obj.weight) * obj.experience;
        obj.handsShaking = false;
    }
    return obj;
}

console.log(solve({
    weight: 120,
    experience: 20,
    bloodAlcoholLevel: 200,
    handsShaking: true
}
));
