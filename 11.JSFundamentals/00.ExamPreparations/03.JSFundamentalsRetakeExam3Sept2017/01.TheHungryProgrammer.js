function getSnatchMeals(meals, commandArgs) {
    let mealsEaten = 0;
    let actions = {
        Serve: () => {
            if (meals.length > 0) {
                console.log(`${meals.pop()} served!`);
            }
        },
        Eat: () => {
            if (meals.length > 0) {
                console.log(`${meals.shift()} eaten`);
                mealsEaten++;
            }
        },
        End: () => {
            if (meals.length > 0) {
                console.log(`Meals left: ${meals.join(', ')}`);
            }
            else {
                console.log('The food is gone');
            }
            console.log(`Meals eaten: ${mealsEaten}`);
        },
        Add: ([meal]) => {
            if (meal && meal !== '') {
                meals.unshift(meal);
            }
        },
        Shift: ([startIdx, endIdx]) => {
            let hasValidIndexes = endIdx > 0 && startIdx >= 0 && endIdx < meals.length && startIdx < endIdx;

            if (hasValidIndexes) {
                let temp = meals[startIdx];
                meals[startIdx] = meals[endIdx];
                meals[endIdx] = temp;
            }
        },
        Consume: ([startIdx, endIdx]) => {
            let hasValidIndexes = startIdx >= 0 && endIdx > 0 && startIdx < endIdx && endIdx < meals.length;

            if (hasValidIndexes) {
                let mealsToEat = endIdx - startIdx + 1;
                meals.splice(startIdx, mealsToEat);
                mealsEaten += mealsToEat;
                console.log('Burp!');
            }
        }
    };

    for (let command of commandArgs) {
        let args = command.split(' ');
        let action = args.shift();

        let currentAction = actions[action];
        if (currentAction) {
            currentAction(args);
            if (action === 'End') {
                break;
            }
        }
    }
}

getSnatchMeals(['carrots', 'apple', 'beet'],
    ['Consume 0 2',
        'End',]
);