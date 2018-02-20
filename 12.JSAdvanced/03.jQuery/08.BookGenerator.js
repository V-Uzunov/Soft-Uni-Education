function createBook(selector, title, author, isbn) {

    let bookGenerator = (function () {
        let id = 1;
        return function (selector, title, author, isbn) {

            //Create all elements
            let container = $(selector);
            let bookContainer = $('<div>');
            bookContainer.attr('id', `book${id}`);
            bookContainer.css('border', 'none');
            let pTitle = $(`<p class="title">${title}</p>`);
            bookContainer.append(pTitle);
            let pAuthor = $(`<p class="author">${author}</p>`);
            bookContainer.append(pAuthor);
            let pISBN = $(`<p class="isbn">${isbn}</p>`);
            bookContainer.append(pISBN);

            //Create Buttons
            let selectedBtn = $('<button>Select</button>');
            bookContainer.append(selectedBtn);
            let deselectBtn = $('<button>Deselect</button>');
            bookContainer.append(deselectBtn);

            //Add Events
            selectedBtn.click(()=>{
                bookContainer.css('border', '2px solid blue');
            });

            deselectBtn.click(()=>{
                bookContainer.css('border', '');
            });

            container.append(bookContainer);
        id++;
        };
    })();
    bookGenerator(selector, title, author, isbn);
}