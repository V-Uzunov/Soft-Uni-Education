function dayOfWeek(day) {
    let days = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'];
    let index= days.indexOf(day);
    return index >= 0 ? index + 1 : 'error';
}

console.log(dayOfWeek('Friday'));
