using Domain;
using Domain.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Departments
{
    public class DepartmentVM : Entity
    {
        public string DepartmentName { get; set; }
        public string DepartmentShortName { get; set; }
         
        public Department ToEntity()
        {
            return new Department()
            {
                Id = this.Id,
                DepartmentName = this.DepartmentName,
                DepartmentShortName = this.DepartmentShortName, 
            };
        }
    }
}
