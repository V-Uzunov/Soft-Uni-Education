namespace LearningSystem.Web.Areas.Blog.Models.Articles
{
    using System;
    using System.Collections.Generic;
    using Infrastructure.Constants;
    using Service.Models.Blog;

    public class ArticlesListingPageModel
    {
        public IEnumerable<BlogArticleListingViewModel> Articles { get; set; }

        public int TotalArticles { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}
