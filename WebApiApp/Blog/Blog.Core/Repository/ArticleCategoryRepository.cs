using Blog.Core.Abstract;
using Blog.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Blog.Core.Repository
{
    public class ArticleCategoryRepository : CRUD, IArticleCategory
    {
        public bool Delete(int articleCategoryId)
        {
            try
            {
                var articleCategory = Find(articleCategoryId);

                if (articleCategory != null)
                {
                    articleCategory.IsDeleted = true;

                    return Update<ArticleCategory>(articleCategory);
                }

                return false;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ArticleCategory Find(int articleCategoryId)
        {
            try
            {
                return db.ArticleCategory.AsNoTracking().FirstOrDefault(a => a.ArticleCategoryId == articleCategoryId && a.IsDeleted == false);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Task<List<ArticleCategory>> Get()
        {
            try
            {
                return db.ArticleCategory.Where(a => a.IsDeleted == false).ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool Insert(ArticleCategory model)
        {
            try
            {
                return Insert<ArticleCategory>(model);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool Update(ArticleCategory model)
        {
            try
            {
                return Update<ArticleCategory>(model);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
