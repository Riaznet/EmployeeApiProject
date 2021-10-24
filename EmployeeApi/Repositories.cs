using Microsoft.Extensions.DependencyInjection;
using Repository.IRepositoy.Departments;
using Repository.IRepositoy.Employees;
using Repository.Repositoy.Departments;
using Repository.Repositoy.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi
{
    public class Repositories
    {
        public Repositories(IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
        }
    }
}
