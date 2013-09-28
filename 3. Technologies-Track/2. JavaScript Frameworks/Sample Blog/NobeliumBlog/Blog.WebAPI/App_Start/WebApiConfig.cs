namespace Blog.WebAPI
{
    using System.Web.Http;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "UsersApi",
                routeTemplate: "api/users/{action}",
                defaults: new
                {
                    controller = "users"
                }
            );

            config.Routes.MapHttpRoute(
                name: "PostApiAll",
                routeTemplate: "api/posts/all",
                defaults: new
                {
                    controller = "posts",
                    action = "all"
                }
            );

            config.Routes.MapHttpRoute(
                name: "PostApiMine",
                routeTemplate: "api/posts/mine",
                defaults: new
                {
                    controller = "posts",
                    action = "mine"
                }
            );

            config.Routes.MapHttpRoute(
                name: "PostApiMyComments",
                routeTemplate: "api/posts/mycomments",
                defaults: new
                {
                    controller = "posts",
                    action = "myComments"
                }
            );

            config.Routes.MapHttpRoute(
                name: "PostApiAllComments",
                routeTemplate: "api/posts/allcomments",
                defaults: new
                {
                    controller = "posts",
                    action = "allComments"
                }
            );

            config.Routes.MapHttpRoute(
                name: "PostApiSearchComments",
                routeTemplate: "api/posts/searchcomments",
                defaults: new
                {
                    controller = "posts",
                    action = "searchComments"
                }
            );

            config.Routes.MapHttpRoute(
                name: "PostApiSearchPosts",
                routeTemplate: "api/posts/searchposts",
                defaults: new
                {
                    controller = "posts",
                    action = "searchPosts"
                }
            );

            config.Routes.MapHttpRoute(
                name: "PostsApiComment",
                routeTemplate: "api/posts/{postId}/comment",
                defaults: new
                {
                    controller = "posts",
                    action = "comment"
                }
            );

            config.Routes.MapHttpRoute(
                name: "PostsApiSingle",
                routeTemplate: "api/posts/{postId}",
                defaults: new
                {
                    controller = "posts"
                }
            );

            config.Routes.MapHttpRoute(
                name: "TagsApiPosts",
                routeTemplate: "api/tags/{id}/posts",
                defaults: new
                {
                    controller = "tags"
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableQuerySupport();
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
