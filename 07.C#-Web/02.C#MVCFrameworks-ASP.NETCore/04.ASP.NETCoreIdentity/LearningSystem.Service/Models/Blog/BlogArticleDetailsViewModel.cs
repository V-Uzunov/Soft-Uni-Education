namespace LearningSystem.Service.Models.Blog
{
    using System;

    public class BlogArticleDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public string Author { get; set; }
    }
}
