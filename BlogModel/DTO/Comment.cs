using System.ComponentModel.DataAnnotations;

namespace BlogModel.DTO
{
    public class Comment
    {
        [Required]
        public int CommentId { get; set; }

        [Required, StringLength(200)]
        public string Content { get; set; }

        public Post Post { get; set; }
    }
}
