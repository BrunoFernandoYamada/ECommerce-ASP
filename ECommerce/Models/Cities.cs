using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Cities
    {
        [Key]
        [Display(Name = "Cidade Id")]
        public int CityId { get; set; }

        [Required(ErrorMessage ="O Campo Nome é requerido!!")]
        [Display(Name = "Cidade")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O Campo Departamento é requerido!!")]
        [Display(Name = "Departamento")]
        [Range(1, Double.MaxValue, ErrorMessage = "Selecione um de partamento!!")]
        public int DepartmentsId { get; set; }

        public virtual Departments Department { get; set; }

        public virtual ICollection<Company> Company { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}