function move(command) {
    let availableTowns = $('#available-towns');
    let selectedTowns = $('#selected-towns');

    let commandObj = {
        'left': () => {
            availableTowns.append(selectedTowns.find('option:selected'));
        },
        'right':() => {
            selectedTowns.append(availableTowns.find('option:selected'));
        },
        'print': () =>{
            $('#output').append(selectedTowns
                .find('option')
                .toArray()
                .map(el => el.textContent)
                .join('; '));
        }
    };

     commandObj[command]();
}