using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Departments
    {
        [Key]
        [Display(Name = "Departamento")]
        public int DepartmentsId { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório!")]
        [MaxLength(50,  ErrorMessage = "O campo nome recebe no máximo 50 caracteres!")]
        [Display(Name = "Nome")]
        [Index("Department_Name_Index",IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Cities> Cities{ get; set; }

        public virtual ICollection<Company> Company { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}