function parseUsername(array) {
    let result = [];

    for (let i = 0; i < array.length; i++) {
        const element = array[i].split('@');
        let name = element[0] + '.';
        element[1].split('.').forEach(el => name +=el[0]);
        result.push(name);
    }

    console.log(result.join(', '));
}

parseUsername(['peshoo@gmail.com', 'todor_43@mail.dir.bg', 'foo@bar.com']);