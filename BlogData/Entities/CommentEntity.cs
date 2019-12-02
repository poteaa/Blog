using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogData.Entities
{
    [Table("Comment")]
    public class CommentEntity
    {
        [Key]
        public int CommentId { get; set; }

        [Required, StringLength(200)]
        public string Content { get; set; }

        public PostEntity Post { get; set; }
    }
}
