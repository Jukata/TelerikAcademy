namespace Blog.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        public virtual User User { get; set; }

        public virtual Post Post { get; set; }
    }
}
