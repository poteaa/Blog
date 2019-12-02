using BlogData.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogModel.DTO
{
    public class Post
    {
        [Required]
        public int PostId { get; set; }

        [Required, StringLength(50)]
        public string Title { get; set; }

        [Required]
        public PostStatus PostStatusId { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
