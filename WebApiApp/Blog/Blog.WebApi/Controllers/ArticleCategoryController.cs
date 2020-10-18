using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog.Model.Entities;
using Blog.Core.Abstract;
using Blog.WebApi.Model;
using Microsoft.AspNetCore.Authorization;

namespace Blog.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleCategoryController : ControllerBase
    {
        private IArticleCategory articleCategoryRepository;

        public ArticleCategoryController(IArticleCategory articleCategoryRepository)
        {
            this.articleCategoryRepository = articleCategoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleCategory>>> GetArticleCategory()
        {
            try
            {
                return await articleCategoryRepository.Get();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("{id}")]
        public ActionResult<ArticleCategory> GetArticleCategory(int id)
        {
            try
            {
                var articleCategory = articleCategoryRepository.Find(id);

                if (articleCategory == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }

                return articleCategory;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ArticleCategoryApiModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = new ArticleCategory()
                    {
                        Name = model.Name
                    };

                    bool result = articleCategoryRepository.Insert(entity);

                    if (result)
                    {
                        return StatusCode(StatusCodes.Status200OK);
                    }

                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] ArticleCategoryApiModel model)
        {
            try
            {
                if (ModelState.IsValid || model.ArticleCategoryId != 0)
                {
                    var articleCategory = articleCategoryRepository.Find(model.ArticleCategoryId);

                    if (articleCategory == null)
                    {
                        return StatusCode(StatusCodes.Status204NoContent);
                    }

                    articleCategory.Name = model.Name;
                    articleCategory.EditedDate = DateTime.Now;

                    bool result = articleCategoryRepository.Update(articleCategory);

                    if (result)
                    {
                        return StatusCode(StatusCodes.Status200OK);
                    }

                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var articleCategory = articleCategoryRepository.Find(id);

                if (articleCategory == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }

                bool result = articleCategoryRepository.Delete(id);

                if (result)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
