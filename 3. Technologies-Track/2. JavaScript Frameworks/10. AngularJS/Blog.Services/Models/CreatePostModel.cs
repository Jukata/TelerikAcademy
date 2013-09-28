using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Blog.Services.Models
{
    [DataContract]
    public class CreatePostModel : PostModel
    {
        [DataMember(Name = "categories")]
        public IEnumerable<string> Categories { get; set; }
    }
}