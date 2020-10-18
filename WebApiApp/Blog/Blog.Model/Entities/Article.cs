using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Model.Entities
{
    public class Article : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleId { get; set; }
        public int ArticleCategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
