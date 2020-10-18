using Blog.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Core.Abstract
{
    public interface IArticleCategory : ICRUD
    {
        bool Delete(int articleCategoryId);
        ArticleCategory Find(int articleCategoryId);
        Task<List<ArticleCategory>> Get();
        bool Insert(ArticleCategory model);
        bool Update(ArticleCategory model);
    }
}
