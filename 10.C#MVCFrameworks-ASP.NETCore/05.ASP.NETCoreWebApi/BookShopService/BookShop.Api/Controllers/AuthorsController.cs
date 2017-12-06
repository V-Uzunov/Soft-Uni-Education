namespace BookShop.Api.Controllers
{
    using BookShop.Api.Infrastructure.WebConstants;
    using BookShop.Service.Interfaces;
    using BookShop.Service.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class AuthorsController : BaseController
    {
        private readonly IAuthorsService authors;

        public AuthorsController(IAuthorsService authors)
        {
            this.authors = authors;
        }

        [HttpGet(WebConstants.WithId)]
        public async Task<IActionResult> Get(int id)
        {
            var authorId = await this.authors.GetById(id);

            if (authorId == null)
            {
                return NotFound();
            }

            return Ok(authorId);
        }

        [HttpGet(WebConstants.WithId + "/books")]
        public async Task<IActionResult> GetBooks(int id)
        {
            var booksId = await this.authors.GetBooksById(id);

            if (booksId == null)
            {
                return NotFound();
            }

            return Ok(booksId);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AuthorRequestServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id =await this.authors
                .Create(model.FirstName,
                        model.LastName);

            return Ok(id);
        }
    }
}
