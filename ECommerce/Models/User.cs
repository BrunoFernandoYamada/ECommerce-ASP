using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Campo E-mail é obrigatório!")]
        [MaxLength(250, ErrorMessage = "O campo E-mail recebe no máximo 250 caracteres!")]
        [Display(Name = "E-mail")]
        [Index("User_UserName_Index", IsUnique = true)]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O campo nome recebe no máximo 50 caracteres!")]
        [Display(Name = "Nome")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Campo Sobrenome é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O campo Sobrenome recebe no máximo 50 caracteres!")]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Campo Telefone é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O campo nome recebe no máximo 50 caracteres!")]
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Campo Endereço é obrigatório!")]
        [MaxLength(100, ErrorMessage = "O campo nome recebe no máximo 50 caracteres!")]
        [Display(Name = "Endereço")]
        public string Address { get; set; }

        [Display(Name = "Imagem")]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [NotMapped]
        public HttpPostedFileBase PhotoFile { get; set; }

        [Required(ErrorMessage = "O Departamento é obrigatório!")]
        [Display(Name = "Departamento")]
        public int DepartmentsId { get; set; }

        [Required(ErrorMessage = "A Cidade é obrigatória!")]
        [Display(Name = "Cidade")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "A Companhia é obrigatória!")]
        [Display(Name = "Companhia")]
        public int CompanyId { get; set; }

        [Display(Name = "Usuário")]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        public virtual Departments Departments { get; set; }

        public virtual Cities Cities { get; set; }

        public virtual Company Comapanies{ get; set; }
    }
}