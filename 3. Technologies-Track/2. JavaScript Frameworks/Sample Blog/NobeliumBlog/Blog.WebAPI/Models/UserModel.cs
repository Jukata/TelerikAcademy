namespace Blog.WebAPI.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UserLoginModel
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "authCode")]
        public string AuthCode { get; set; }
    }

    [DataContract]
    public class UserRegisterModel : UserLoginModel
    {
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }
    }

    [DataContract]
    public class UserLoggedModel
    {
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }

        [DataMember(Name = "isAdmin")]
        public bool IsAdmin { get; set; }
    }
}