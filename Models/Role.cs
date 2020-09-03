
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
        [ForeignKey("RoleId")]
        public ICollection<User>User { get; set; }
        [ForeignKey("RoleId")]
        public ICollection<Permission>Permissions { get; set; }

    }
}
