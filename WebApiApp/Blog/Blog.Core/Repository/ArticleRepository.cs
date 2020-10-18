using Blog.Core.Abstract;
using Blog.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Core.Repository
{
    public class ArticleRepository : CRUD, IArticle
    {
        public bool Delete(int articleId)
        {
            try
            {
                var article = Find(articleId);

                if (article != null)
                {
                    article.IsDeleted = true;

                    return Update<Article>(article);
                }

                return false;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Article Find(int articleId)
        {
            try
            {
                return db.Article.AsNoTracking().FirstOrDefault(a => a.ArticleId == articleId && a.IsDeleted == false);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Task<List<Article>> Get()
        {
            try
            {
                return db.Article.Where(a => a.IsDeleted == false).ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Task<List<Article>> Get(string searchText)
        {
            try
            {
                searchText = searchText.ToLower();

                return db.Article.Where(a => (a.Title.ToLower().Contains(searchText) || a.Content.ToLower().Contains(searchText)) && a.IsDeleted == false).ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool Insert(Article model)
        {
            try
            {
                return Insert<Article>(model);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool Update(Article model)
        {
            try
            {
                return Update<Article>(model);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
