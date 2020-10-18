using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Model.Entities
{
    public class ArticleCategory : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleCategoryId { get; set; }
        public string Name { get; set; }
    }
}
