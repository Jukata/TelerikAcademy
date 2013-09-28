namespace Blog.WebAPI.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Web.Http;
    using Blog.Data;
    using Blog.Models;
    using Blog.WebAPI.Models;

    public class UsersController : BaseApiController
    {
        private const string ValidSha1CodeChars = "qwertyuiopasdfghjklzxcvbnm0123456789";
        private const int Sha1CodeLength = 40;

        private const string ValidUsernameChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM0123456789_.";
        private const int MinUsernameChars = 6;
        private const int MaxUsernameChars = 30;

        private const string ValidDisplayNameChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM0123456789_- .";
        private const int MinDisplayNameChars = 6;
        private const int MaxDisplayNameChars = 30;

        private static readonly Random rand = new Random();

        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage RegisterUser([FromBody] UserRegisterModel model)
        {
            var responseMessage = this.PerformOperation(() =>
            {
                using (var context = new BlogDbContext())
                {
                    if (model == null)
                    {
                        throw new ServerErrorException(
                            "Username data must be set",
                            HttpStatusCode.BadRequest);
                    }

                    this.ValidateUsername(model.Username);
                    this.ValidateDisplayName(model.DisplayName);
                    this.ValidateAuthCode(model.AuthCode);

                    var modelUsernameLower = model.Username.ToLower();
                    var modelDisplayNameLower = model.DisplayName.ToLower();

                    var user = context.Users.FirstOrDefault(u =>
                        u.Username == modelUsernameLower ||
                        u.DisplayName.ToLower() == modelDisplayNameLower);

                    if (user != null)
                    {
                        if (user.Username == modelUsernameLower)
                        {
                            throw new ServerErrorException(
                                "Username already exists",
                                HttpStatusCode.Conflict);
                        }

                        if (user.DisplayName.ToLower() == modelDisplayNameLower)
                        {
                            throw new ServerErrorException(
                                "Display name already exists",
                                HttpStatusCode.Conflict);
                        }
                    }

                    var newUser = new User()
                    {
                        Username = modelUsernameLower,
                        DisplayName = model.DisplayName,
                        AuthCode = model.AuthCode
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();

                    newUser.SessionKey = GenerateSessionKey(newUser.Id);
                    context.SaveChanges();

                    var loggedUserModel = new UserLoggedModel()
                    {
                        DisplayName = newUser.DisplayName,
                        SessionKey = newUser.SessionKey,
                    };

                    var response = this.Request.CreateResponse(
                        HttpStatusCode.Created,
                        loggedUserModel);

                    return response;
                }
            });

            return responseMessage;
        }

        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage LoginUser([FromBody] UserLoginModel model)
        {
            var responseMessage = this.PerformOperation(() =>
            {
                using (var context = new BlogDbContext())
                {
                    this.ValidateUsername(model.Username);
                    this.ValidateAuthCode(model.AuthCode);

                    var user = context.Users.FirstOrDefault(m =>
                        m.Username == model.Username.ToLower());

                    if (user == null)
                    {
                        throw new ServerErrorException(
                            "User does not exist",
                            HttpStatusCode.BadRequest);
                    }

                    if (user.AuthCode != model.AuthCode)
                    {
                        throw new ServerErrorException(
                            "Invalid authentication code",
                            HttpStatusCode.Unauthorized);
                    }

                    if (user.SessionKey == null)
                    {
                        user.SessionKey = this.GenerateSessionKey(user.Id);
                        context.SaveChanges();
                    }

                    var loggedUserModel = new UserLoggedModel()
                    {
                        DisplayName = user.DisplayName,
                        SessionKey = user.SessionKey,
                        IsAdmin = user.IsAdmin,
                    };

                    var response = this.Request.CreateResponse(
                        HttpStatusCode.Created,
                        loggedUserModel);

                    return response;
                }
            });

            return responseMessage;
        }

        [HttpPut]
        [ActionName("logout")]
        public HttpResponseMessage LogoutUser(string sessionKey)
        {
            var responseMessage = this.PerformOperation(() =>
            {
                using (var context = new BlogDbContext())
                {
                    this.ValidateSessionKey(sessionKey);

                    var user = context.Users
                        .FirstOrDefault(u => u.SessionKey == sessionKey);

                    if (user == null)
                    {
                        throw new ServerErrorException(
                            "Invalid or expired session",
                            HttpStatusCode.BadRequest);
                    }

                    user.SessionKey = null;
                    context.SaveChanges();

                    var response = this.Request.CreateResponse(
                        HttpStatusCode.OK,
                        "Logged out");

                    return response;
                }
            });

            return responseMessage;
        }

        public HttpResponseMessage GetIsAdmin(string sessionKey)
        {
            var responseMessage = this.PerformOperation(() =>
            {
                using (var context = new BlogDbContext())
                {
                    this.ValidateSessionKey(sessionKey);

                    var user = context.Users
                        .FirstOrDefault(u => u.SessionKey == sessionKey);

                    if (user == null)
                    {
                        throw new ServerErrorException(
                            "Invalid or expired session",
                            HttpStatusCode.BadRequest);
                    }

                    HttpResponseMessage response;
                    if (!user.IsAdmin)
                    {
                        response = this.Request.CreateResponse(
                        HttpStatusCode.BadRequest,
                        "You do not have administrator priviliges to view this page!");
                    }
                    else
                    {
                        response = this.Request.CreateResponse(HttpStatusCode.OK);
                    }

                    return response;
                }
            });

            return responseMessage;
        }

        private void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ServerErrorException(
                    "Username cannot be null",
                    HttpStatusCode.BadRequest);
            }

            if (username.Length < MinUsernameChars || username.Length > MaxUsernameChars)
            {
                throw new ServerErrorException(
                    "Username should be between 6 and 30 symbols long",
                    HttpStatusCode.BadRequest);
            }

            if (username.Any(ch => !ValidUsernameChars.Contains(ch)))
            {
                throw new ServerErrorException(
                    "Username contains invalid characters",
                    HttpStatusCode.BadRequest);
            }
        }

        private void ValidateDisplayName(string nickname)
        {
            if (nickname == null)
            {
                throw new ServerErrorException(
                    "Display name cannot be null",
                    HttpStatusCode.BadRequest);
            }

            if (nickname.Length < MinDisplayNameChars || nickname.Length > MaxDisplayNameChars)
            {
                throw new ServerErrorException(
                    "Display name should be between 6 and 30 symbols long",
                    HttpStatusCode.BadRequest);
            }

            if (nickname.Any(ch => !ValidDisplayNameChars.Contains(ch)))
            {
                throw new ServerErrorException(
                    "Display name contains invalid characters",
                    HttpStatusCode.BadRequest);
            }
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null)
            {
                throw new ServerErrorException(
                    "Authentication code cannot be null",
                    HttpStatusCode.BadRequest);
            }

            if (authCode.Length != Sha1CodeLength)
            {
                throw new ServerErrorException
                    ("Invalid authentication code length",
                    HttpStatusCode.BadRequest);
            }

            if (authCode.Any(ch => !ValidSha1CodeChars.Contains(ch)))
            {
                throw new ServerErrorException(
                    "Authentication code contains invalid characters",
                    HttpStatusCode.BadRequest);
            }
        }

        private string GenerateSessionKey(int id)
        {
            var keyBuilder = new StringBuilder(SessionKeyLen);

            keyBuilder.AppendFormat("{0:00000}", id);
            while (keyBuilder.Length < SessionKeyLen)
            {
                var index = rand.Next(SessionKeyPostfixChars.Length);
                keyBuilder.Append(SessionKeyPostfixChars[index]);
            }

            return keyBuilder.ToString();
        }
    }
}
