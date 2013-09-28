using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Blog.Services.Models
{
    [DataContract]
    public class CategoryFullModel : CategoryModel
    {
        [DataMember(Name = "posts")]
        public IEnumerable<PostModel> Posts { get; set; }
    }
}