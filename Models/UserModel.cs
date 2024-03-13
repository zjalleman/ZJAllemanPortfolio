using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZJAllemanWeb.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [DisplayName("Username")]
        [StringLength(20, MinimumLength = 4)]
        public required string UserName { get; set; }

        [StringLength(20, MinimumLength = 4)]
        public required string Password { get; set; }

        [DisplayName("Hashed Password")]
        public string HashedPassword { get; set; } = string.Empty;
    }
}
