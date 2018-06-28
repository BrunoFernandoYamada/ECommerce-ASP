using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Classes
{
    public class ComboHelper : IDisposable
    {
        private static ECommerceContext db = new ECommerceContext();

        public static List<Departments> GetDepartments()
        {
            var dep = db.Departments.ToList();
            dep.Add(new Departments
            {
                DepartmentsId = 0,
                Name = "[ Selecione um Departamento ]"
            });

            return dep = dep.OrderBy(d => d.Name).ToList();
        }

        public static List<Cities> GetCities()
        {
            var dep = db.Cities.ToList();
            dep.Add(new Cities
            {
                DepartmentsId = 0,
                Name = "[ Selecione uma Cidade ]"
            });

            return dep = dep.OrderBy(d => d.Name).ToList();
        }

        public static List<Company> GetCompanies()
        {
            var dep = db.Companies.ToList();
            dep.Add(new Company
            { 
                CompanyId = 0,
                Name = "[ Selecione uma Cidade ]"
            });

            return dep = dep.OrderBy(d => d.Name).ToList();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}