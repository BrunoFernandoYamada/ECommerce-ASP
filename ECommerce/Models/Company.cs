using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Company
    {
        [Key]
        [Display(Name = "Compania Id")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O campo nome recebe no máximo 50 caracteres!")]
        [Display(Name = "Nome")]
        [Index("Company_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo Telefone é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O campo nome recebe no máximo 50 caracteres!")]
        [Display(Name = "Telefone")]
        [Index("Company_Phone_Index", IsUnique = true)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Campo Endereço é obrigatório!")]
        [MaxLength(100, ErrorMessage = "O campo nome recebe no máximo 50 caracteres!")]
        [Display(Name = "Endereço")]
        public string Address { get; set; }

        [Display(Name = "Imagem")]
        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }

        [NotMapped]
        public  HttpPostedFileBase LogoFile { get; set; }

        [Required(ErrorMessage = "O Departamento é obrigatório!")]
        [Display(Name = "Departamento")]
        public int DepartmentsId { get; set; }

        [Required(ErrorMessage = "A Cidade é obrigatória!")]
        [Display(Name = "Cidade")]
        public int CityId { get; set; }

        public virtual Departments Departments { get; set; }

        public virtual Cities Cities { get; set; }

        public virtual ICollection<User> Users { get; set; }
        
    }
}