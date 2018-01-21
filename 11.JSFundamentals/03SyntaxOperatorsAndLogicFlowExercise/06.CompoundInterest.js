function monetaryDeposit(params) {
    let principalSum = params[0];
    let interestRate = params[1] / 100;
    let compoundPeriod =12 / params[2];
    let timeSpan = params[3];

    let total = principalSum * (Math.pow(1 + (interestRate / compoundPeriod), ( compoundPeriod * timeSpan)));
    console.log(total.toFixed(2));
}

monetaryDeposit([1500, 4.3, 3, 6]);
monetaryDeposit([100000, 5, 12, 25]);