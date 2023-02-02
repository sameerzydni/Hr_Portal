using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hr_Portal.Models
{
    public class LoginModel
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="nvarchar(30)")]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Password { get; set; }
    }
}
