using System.ComponentModel.DataAnnotations;

namespace mvcAuthentication.Models.Entities
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string? DepartmentName{ get; set; }
        public virtual List<Personel>? Personel{ get; set; }
    }
}
