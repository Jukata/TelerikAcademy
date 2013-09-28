using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public class Post
    {
        private ICollection<Category> categories;

        public Post()
        {
            this.categories = new HashSet<Category>();
        }

        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }
    }
}
