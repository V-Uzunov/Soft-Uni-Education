namespace LearningSystem.Service.Models.Blog
{
    using Data.Constants;
    using System.ComponentModel.DataAnnotations;

    public class BlogArticlesViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.ArticleTitleMinLenght)]
        [MaxLength(DataConstants.ArticleTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MaxLength(DataConstants.ArticleContentMaxLenght, ErrorMessage = "Content must have maximum 3000 characters.")]
        public string Content { get; set; }
        
    }
}
