namespace LearningSystem.Service.Models.Blog
{
    using System;

    public class BlogArticleListingViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime PublishDate { get; set; }

        public string Author { get; set; }
    }
}
