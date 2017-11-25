namespace LearningSystem.Service.Interfaces.Blog
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Blog;

    public interface IBlogArticleService
    {
        Task CreateAsync(string title, string content, string userId);

        Task<IEnumerable<BlogArticleListingViewModel>> AllAsync(int page = 1, int pageSize=6);
        Task<int> TotalAsync();

        Task<BlogArticleDetailsViewModel> ByIdAsync(int id);
    }
}
