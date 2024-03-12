using System.ComponentModel;

namespace ZJAllemanWeb.Models
{
    public class Demo1UserModel
    {
        public int Id { get; set; }

        [DisplayName("Username")]
        public required string UserName { get; set; }
        
        public required string Password { get; set; }
    }
}
