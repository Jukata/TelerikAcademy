using Blog.Data;
using Blog.Models;
using Blog.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blog.Services.Controllers
{
    public class CategoriesController : ApiController
    {
        //private const string connString = "AngularBlog";

        [HttpGet]
        public IEnumerable<CategoryModel> GetAllCategories()
        {
            BlogContext context = new BlogContext();
            return context.Categories.Select(c => new CategoryModel()
            {
                CategoryId = c.CategoryId,
                Name = c.Name
            });
        }

        [HttpGet]
        [ActionName("Posts")]
        public IEnumerable<PostFullModel> GetPostsByCategories(int id)
        {
            BlogContext context = new BlogContext();

            Category category = context.Categories.Find(id);

            if (category == null)
            {
                var errResponse =
                    this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid category id");
                throw new HttpResponseException(errResponse);
            }

            var posts = context.Posts
                .Where(p => p.Categories.Any(c => c.Name == category.Name))
                .Select(p => new PostFullModel()
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    Content = p.Content,
                    Categories = p.Categories.Select(c => new CategoryModel()
                    {
                        CategoryId = c.CategoryId,
                        Name = c.Name,
                    })
                });

            return posts;
        }


    }
}
