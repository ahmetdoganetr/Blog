using System;

namespace Blog.WebApi.Model
{
    public class ArticleApiModel
    {
        public int ArticleId { get; set; }
        public int ArticleCategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
