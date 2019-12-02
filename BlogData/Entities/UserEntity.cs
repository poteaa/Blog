using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogData.Entities
{
    [Table("User")]
    public class UserEntity
    {
        [Key]
        public int UserId { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required, StringLength(10)]
        public string Username { get; set; }

        [Required, StringLength(20)]
        public string Password { get; set; }

        public virtual RoleEntity Role { get; set; }
    }
}
