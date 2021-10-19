using Microsoft.Extensions.DependencyInjection;
using Service.IService.Employees;
using Service.Service.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi
{
    public class Services
    {
        public Services(IServiceCollection services)
        {
            services.AddTransient<IEmployeeService, EmployeeService>();
        }
    }
}
