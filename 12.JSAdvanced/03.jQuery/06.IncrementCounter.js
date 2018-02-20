function increment(selector) {

    let container = $(`${selector}`);
    let textArea = $('<textarea>');
    let incrBtn = $('<button>Increment</button>');
    let addBtn = $('<button>Add</button>');
    let ul = $('<ul>');

    //Fill Text Area
    textArea.val(0);
    textArea.addClass('counter');
    textArea.attr('disabled', true);

    //Fill buttons
    incrBtn.addClass('btn');
    incrBtn.attr('id', 'incrementBtn');

    addBtn.addClass('btn');
    addBtn.attr('id', 'addBtn');
    //Fill ul
    ul.addClass('results');

    //Events
    $(incrBtn).click(()=>{
        textArea.val(+textArea.val() + 1);
    });

    $(addBtn).click(()=>{
        let newLi = $(`<li>${textArea.val()}</li>`);
        ul.append(newLi);
    });

    //Append all elements
    container.append(textArea)
             .append(incrBtn)
             .append(addBtn)
             .append(ul);
}