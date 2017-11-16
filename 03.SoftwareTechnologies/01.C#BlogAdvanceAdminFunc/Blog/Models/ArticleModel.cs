using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class ArticleModel
    {
        [Required]
        [StringLength(50)]
        public string Title  { get; set; }
        public string Content { get; set; }

        [Required]
        [Display(Name= "Category")]
        public int CategoryId { get; set; }

        [Required]
        public string AuthorId { get; set; }
        public List<Category> Categories { get; set; }

        public string Tags { get; set; }
    }
}