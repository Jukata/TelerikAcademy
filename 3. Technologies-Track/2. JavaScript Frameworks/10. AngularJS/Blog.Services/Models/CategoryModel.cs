using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Blog.Services.Models
{
    [DataContract]
    public class CategoryModel
    {
        [DataMember(Name = "categoryId")]
        public int CategoryId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}