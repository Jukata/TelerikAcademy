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
    public class PostsController : ApiController
    {
        //private const string connString = "AngularBlog";

        [HttpGet]
        public IEnumerable<PostFullModel> GetAll()
        {
            BlogContext context = new BlogContext();

            var postsModels = context.Posts.Select(p => new PostFullModel()
            {
                PostId = p.PostId,
                Title = p.Title,
                Content = p.Content,
                Categories = p.Categories.Select(c => new CategoryModel()
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name,
                }),
            });

            return postsModels;
        }

        [HttpPost]
        public HttpResponseMessage CreatePost([FromBody]CreatePostModel item)
        {
            BlogContext context = new BlogContext();

            Post entity = new Post()
            {
                Content = item.Content,
                Title = item.Title,
            };

            var categories = new HashSet<Category>();

            if (item.Categories != null)
            {
                foreach (string catName in item.Categories)
                {
                    Category cat = context.Categories.FirstOrDefault(c => c.Name == catName);

                    if (cat == null)
                    {
                        cat = new Category() { Name = catName, };
                    }

                    categories.Add(cat);
                }
            }
            else
            {
                Category cat = context.Categories.FirstOrDefault(c => c.Name == "Default");
                if (cat == null)
                {
                    cat = new Category() { Name = "Default" };
                }
                categories.Add(cat);
            }

            entity.Categories = categories;

            context.Posts.Add(entity);
            context.SaveChanges();

            PostFullModel model = new PostFullModel()
            {
                PostId = entity.PostId,
                Title = entity.Title,
                Content = entity.Content,
                Categories = entity.Categories.Select(c => new CategoryModel()
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name,
                }),
            };

            HttpResponseMessage response = this.Request.CreateResponse(HttpStatusCode.Created, model);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = model.PostId }));

            return response;
        }
    }








}
