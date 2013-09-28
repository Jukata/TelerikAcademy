namespace Blog.WebAPI.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class CommentCreateModel
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }
    }

    [DataContract]
    public class CommentModel : CommentCreateModel
    {
        [DataMember(Name = "commentedBy")]
        public string CommentedBy { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }
    }
}