function uniqueUsernames(array) {
    let result = new Set();

    for (const names of array) {
        result.add(names);
    }

    function sortFunc(nameA, nameB) {
        if (nameA.length > nameB.length) {
            return 1;
        }
        if (nameA.length < nameB.length) {
            return -1;
        }
        return nameA.localeCompare(nameB);
    }

    let sortResult = [...result].sort(sortFunc);
    for (const names of sortResult) {
        console.log(names);
    }
}

uniqueUsernames(['Ashton',
    'Kutcher',
    'Ariel',
    'Lilly',
    'Keyden',
    'Aizen',
    'Billy',
    'Braston']);