
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogData.Entities
{
    [Table("PostStatus")]
    public class PostStatusEntity
    {
        [Key]
        public int PostStatusId { get; set; }

        [Required, StringLength(10)]
        public string Name { get; set; }
    }
}
