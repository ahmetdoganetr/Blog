using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Core.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Blog.Model.Entities;
using Blog.WebApi.Model;
using Microsoft.AspNetCore.Authorization;

namespace Blog.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private IArticle articleRepository;

        public ArticleController(IArticle articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticle()
        {
            try
            {
                return await articleRepository.Get();
            } 
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<Article> GetArticle(int id)
        {
            try
            {
                var article = articleRepository.Find(id);

                if (article == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }

                return article;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ArticleApiModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = new Article()
                    {
                        ArticleCategoryId = model.ArticleCategoryId,
                        Title = model.Title,
                        Content = model.Content,
                        Date = model.Date
                    };

                    bool result = articleRepository.Insert(entity);

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
        public ActionResult Put([FromBody] ArticleApiModel model)
        {
            try
            {
                if (ModelState.IsValid || model.ArticleId != 0)
                {
                    var article = articleRepository.Find(model.ArticleId);

                    if (article == null)
                    {
                        return StatusCode(StatusCodes.Status204NoContent);
                    }

                    article.ArticleCategoryId = model.ArticleCategoryId;
                    article.Title = model.Title;
                    article.Content = model.Content;
                    article.Date = model.Date;
                    article.EditedDate = DateTime.Now;

                    bool result = articleRepository.Update(article);

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
                var article = articleRepository.Find(id);

                if (article == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }

                bool result = articleRepository.Delete(id);

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

        [Route("[action]/{searchText}")]
        [HttpGet("{searchText}")]
        public async Task<ActionResult<IEnumerable<Article>>> Search(string searchText)
        {
            try
            {
                if (!string.IsNullOrEmpty(searchText))
                {
                    return await articleRepository.Get(searchText);
                }
                
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
