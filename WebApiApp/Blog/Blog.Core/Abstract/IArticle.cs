using Blog.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Core.Abstract
{
    public interface IArticle : ICRUD
    {
        bool Delete(int articleId);
        Article Find(int articleId);
        Task<List<Article>> Get();
        Task<List<Article>> Get(string searchText);
        bool Insert(Article model);
        bool Update(Article model);
    }
}
