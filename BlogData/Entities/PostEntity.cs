using BlogData.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogData.Entities
{
    [Table("Post")]
    public class PostEntity
    {
        [Key]
        public int PostId { get; set; }

        [Required, StringLength(50)]
        public string Title { get; set; }

        [Required]
        public int PostStatusId { get; set; }

        public PostStatusEntity PostStatus { get; set; }

        public IEnumerable<CommentEntity> Comments { get; set; }
    }
}
