using Domain;
using Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Employees
{
    public class EmployeeVM : Entity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName()
        {
            return this.FirstName +  " "  +  this.MiddleName +  " "  +  this.LastName;
        }
        public Employee ToEntity()
        {
            return new Employee()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                MiddleName = this.MiddleName,
                LastName = this.LastName,
            };
        }
    }
}
