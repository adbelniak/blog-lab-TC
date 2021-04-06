using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Blog.DAL.Model
{
    public class Comment
    {
        [Key]
        public long Id { get; set; }

        public long PostId { get; set; }

        [Required]
        public string Content { get; set; }

        public string Author { get; set; }
    }
}
