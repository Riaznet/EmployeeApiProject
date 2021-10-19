using Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Repository.DBContext;
using Repository.IRepositoy.Employees;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositoy.Employees
{
    public class EmployeeRepository : Repository<Employee, SqlDbContext>, IEmployeeRepository
    {
        
    }
}
