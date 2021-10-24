using Repository.IRepositoy.Departments;
using Service.IService.Department;
using Service.ViewModel.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Departments
{
    public class EmployeeService : IDepartmentService
    {
        private IDepartmentRepository _departmentRepository;
        public EmployeeService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<DepartmentVM> Add(DepartmentVM entity)
        {
            try
            {
                entity.Id = Guid.NewGuid();
                var res = await _departmentRepository.Add(entity.ToEntity());
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
                return _departmentRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DepartmentVM> Get(Guid Id)
        {
            try
            {
                var data = await _departmentRepository.Get(Id);
                var vm = new DepartmentVM
                {
                    Id = data.Id,
                    DepartmentName = data.DepartmentName,
                    DepartmentShortName = data.DepartmentShortName, 
                };
                return vm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<DepartmentVM>> GetAll()
        {
            var data = (from t1 in await _departmentRepository.GetAll()
                        select new DepartmentVM
                        {
                            Id = t1.Id,
                            DepartmentName = t1.DepartmentName,
                            DepartmentShortName = t1.DepartmentShortName,
                        }).ToList();
            return data;
        }

        public async Task<DepartmentVM> Update(DepartmentVM entity)
        {
            try
            {
                var res = await _departmentRepository.Update(entity.ToEntity());
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    } 
}
