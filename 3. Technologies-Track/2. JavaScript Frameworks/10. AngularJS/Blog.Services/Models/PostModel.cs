using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Blog.Services.Models
{
    [DataContract]
    public class PostModel
    {
        [DataMember(Name = "postId")]
        public int PostId { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }
    }
}