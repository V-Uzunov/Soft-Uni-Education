function timer() {
    let hours = $('span#hours');
    let minutes = $('span#minutes');
    let seconds = $('span#seconds');
    let startBtn = $('#start-timer');
    let pauseBtn = $('#stop-timer');

    let incr = 0;
    let timer = null;
    //Events
    $(startBtn).click(startTimer);
    $(pauseBtn).click(pauseTime);

    //Start Timer
    function startTimer() {
        if (timer === null) {
            timer = setInterval(increment, 1000);
        }
    }

    //Increment seconds into minutes into hours
    function increment() {
        incr++;
        hours.text(('0' + Math.floor(incr / 60 / 60)).slice(-2));
        minutes.text(('0' + Math.floor((incr / 60) % 60)).slice(-2));
        seconds.text(('0' + (incr % 60)).slice(-2));
    }

    //Pause Timer
    function pauseTime() {
        clearInterval(timer);
        timer = null;
    }
}