using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogData.Entities
{
    [Table("Role")]
    public class RoleEntity
    {
        [Key]
        public int RoleId { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        public IEnumerable<UserEntity> Users { get; set; }
    }
}