namespace BookShop.Api.Controllers
{
    using BookShop.Api.Infrastructure.WebConstants;
    using BookShop.Service.Interfaces.Category;
    using BookShop.Service.Models.Category;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService category;

        public CategoriesController(ICategoriesService category)
        {
            this.category = category;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await this.category.All());

        [HttpGet(WebConstants.WithId)]
        public async Task<IActionResult> GetById(int id)
        {
            var categoryById = await this.category.FindById(id);

            if (categoryById == null)
            {
                return NotFound();
            }

            return Ok(categoryById);
        }

        [HttpDelete(WebConstants.WithId)]
        public async Task<IActionResult> Delete(int id)
        {
            var categoryById = await this.category.FindById(id);

            if (categoryById == null)
            {
                return NotFound();
            }

            var categoryId = await this.category.DeleteById(id);

            return Ok(categoryId);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CategoryRequestServiceModel model)
        {
            var categoryExist = await this.category.Exists(model.Name);

            if (categoryExist)
            {
                return BadRequest("This category already exist!");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = await this.category.Create(model.Name);

            return Ok(id);
        }

        [HttpPut(WebConstants.WithId)]
        public async Task<IActionResult> Put(int id, [FromBody]CategoryPutServiceModel model)
        {
            var categoryById = await this.category.FindById(id);

            if (categoryById == null)
            {
                return NotFound();
            }

            var success= await this.category.Edit(id, model.Name);

            if (!success)
            {
                return BadRequest("Cannot edit to already existing category");
            }

            return Ok(id);
        }
    }
}
