using System.ComponentModel.DataAnnotations;

namespace mvcAuthentication.Models.Entities
{
    public class Manager
    {
        [Key]
        public int ManagerID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
