using Domain.Department;
using Repository.DBContext;
using Repository.IRepositoy.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositoy.Departments
{
    public class DepartmentRepository : Repository<Department, SqlDbContext>, IDepartmentRepository
    {
    }
}
