using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Blog.Services.Models
{
    [DataContract]
    public class PostFullModel : PostModel
    {
        [DataMember(Name = "categories")]
        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}