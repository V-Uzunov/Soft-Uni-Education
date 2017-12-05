namespace BookShop.Service.Interfaces.Category
{
    using BookShop.Service.Models.Category;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        Task<IEnumerable<CategoryDetailsServiceModel>> All();

        Task<CategoryByIdServiceModel> FindById(int id);

        Task<int> DeleteById(int id);

        Task<int> Create(string name);

        Task<bool> Exists(string name);

        Task<bool> Edit(int id, string name);
    }
}
