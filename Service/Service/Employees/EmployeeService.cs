using Repository.IRepositoy.Employees;
using Service.IService.Employees;
using Service.ViewModel.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeVM> Add(EmployeeVM entity)
        {
            try
            {
                entity.Id = Guid.NewGuid();
                var res = await _employeeRepository.Add(entity.ToEntity());
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> Delete(Guid Id)
        {
            try
            {
                return _employeeRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EmployeeVM> Get(Guid Id)
        {
            try
            {
                var data = await _employeeRepository.Get(Id);
                var vm = new EmployeeVM
                {
                    Id = data.Id,
                    FirstName = data.FirstName,
                    MiddleName = data.MiddleName,
                    LastName = data.LastName,
                };
                return vm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<EmployeeVM>> GetAll()
        {
            var data = (from t1 in await _employeeRepository.GetAll()
                        select new EmployeeVM
                        {
                            Id = t1.Id,
                            FirstName = t1.FirstName,
                            MiddleName = t1.MiddleName,
                            LastName = t1.LastName,
                        }).ToList();
            return data;
        }

        public async Task<EmployeeVM> Update(EmployeeVM entity)
        {
            try
            {
                var res = await _employeeRepository.Update(entity.ToEntity());
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
