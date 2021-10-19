using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Employees;
using System.Threading.Tasks;

namespace Repository.IRepositoy.Employees
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
}
