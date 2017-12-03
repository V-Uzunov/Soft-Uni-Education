namespace BookShop.Api.Controllers
{
    using BookShop.Api.Infrastructure.WebConstants;
    using BookShop.Service.Interfaces;
    using BookShop.Service.Interfaces.Books;
    using BookShop.Service.Models.Books;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class BooksController : BaseController
    {
        private readonly IBooksService books;
        private readonly IAuthorsService authors;

        public BooksController(IBooksService books, IAuthorsService authors)
        {
            this.authors = authors;
            this.books = books;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BooksRequestServiceModel model)
        {
            if (!await this.authors.Exists(model.AuthorId))
            {
                return BadRequest("Author not exists!");
            }

            var id =await this.books.Create(model.Title,
                                           model.Description,
                                           model.AgeRestriction,
                                           model.Categories,
                                           model.Copies,
                                           model.Edition,
                                           model.AuthorId,
                                           model.ReleaseDate,
                                           model.Price);
            return Ok(id);
        }

        [HttpPut(WebConstants.WithId)]
        public async Task<IActionResult> Put(int id, [FromBody]BooksPutServiceModel model)
        {
            if (!await this.authors.Exists(model.AuthorId))
            {
                return BadRequest("Author not exists!");
            }
            var bookId = await this.books.GetById(id);

            if (bookId == null)
            {
                return NotFound();
            }

            var book =await this.books.Edit(id,
                                           model.Title,
                                           model.Description,
                                           model.AgeRestriction,
                                           model.Copies,
                                           model.Edition,
                                           model.AuthorId,
                                           model.ReleaseDate,
                                           model.Price);

            return Ok(book);
        }


        [HttpGet(WebConstants.WithId)]
        public async Task<IActionResult> Get(int id)
        {
            var bookId = await this.books.GetById(id);

            if (bookId == null)
            {
                return NotFound();
            }

            return Ok(bookId);
        }

        [HttpGet]
        public async Task<IActionResult> GetBySearchWord([FromQuery]string word="")
        {
            var booksByWord = await this.books.GetBySearch(word);

            if (booksByWord == null)
            {
                return NotFound();
            }
            return Ok(booksByWord);
        }
    }
}
