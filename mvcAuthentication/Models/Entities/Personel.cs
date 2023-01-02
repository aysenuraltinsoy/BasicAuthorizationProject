using System.ComponentModel.DataAnnotations.Schema;

namespace mvcAuthentication.Models.Entities
{
    public class Personel
    {
        public int PersonelID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public virtual Department? Department { get; set; }
    }
}
