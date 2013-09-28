namespace Blog.WebAPI.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Blog.Data;
    using Blog.WebAPI.Models;

    public class TagsController : BaseApiController
    {
        public HttpResponseMessage GetAll(string sessionKey)
        {
            var responseMessage = this.PerformOperation(() =>
            {
                this.ValidateSessionKey(sessionKey);

                var context = new BlogDbContext();
                var keyExists = context.Users
                    .Any(user => user.SessionKey == sessionKey);

                if (!keyExists)
                {
                    throw new ServerErrorException(
                        "Invalid or expired session",
                        HttpStatusCode.BadRequest);
                }

                var tagModels = context.Tags.Select(tag =>
                    new TagModel()
                    {
                        Id = tag.Id,
                        Name = tag.Name,
                        Posts = tag.Posts.Count
                    }
                );

                return tagModels
                    .OrderBy(model => model.Name);
            });

            return responseMessage;
        }

        public HttpResponseMessage GetByTagId(int id, string sessionKey)
        {
            var responseMessage = this.PerformOperation(() =>
            {
                this.ValidateSessionKey(sessionKey);

                var context = new BlogDbContext();
                var keyExists = context.Users
                    .Any(user => user.SessionKey == sessionKey);

                if (!keyExists)
                {
                    throw new ServerErrorException(
                        "Invalid or expired session",
                        HttpStatusCode.BadRequest);
                }

                var postModels = context.Posts
                    .Where(post => post.Tags.Any(tag => tag.Id == id))
                    .Select(post =>
                    new PostModel()
                    {
                        Id = post.Id,
                        Title = post.Title,
                        PostedBy = post.User.DisplayName,
                        PostDate = post.PostDate,
                        Text = post.Text,
                        Tags = post.Tags.Select(tag => tag.Name),
                        Comments = post.Comments.Select(comment =>
                                new CommentModel()
                                {
                                    Text = comment.Text,
                                    CommentedBy = "asd",
                                    PostDate = comment.PostDate
                                }
                            )
                    });

                return postModels
                    .OrderByDescending(model => model.PostDate);
            });

            return responseMessage;
        }
    }
}
