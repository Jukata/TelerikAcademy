namespace Blog.WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class PostCreateNewModel
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "tags")]
        public IEnumerable<string> Tags { get; set; }
    }

    [DataContract]
    public class PostModel : PostCreateNewModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "postedBy")]
        public string PostedBy { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }

        [DataMember(Name = "comments")]
        public IEnumerable<CommentModel> Comments { get; set; }
    }

    [DataContract]
    public class PostCreatedModel
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }
    }
}