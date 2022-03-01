using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Models;
using ThreeApi.Repositories;

namespace Three.Services
{
    public class DepartmentRespository : IDepartmentRespository
    {
        public readonly List<Department> _departments = new List<Department>();

        public DepartmentRespository()
        {
            _departments.Add(new Department
            {
                Id = 1,
                Name = "HR",
                EmployeeCount = 16,
                Location = "BeiJing"
            });
            _departments.Add(new Department
            {
                Id = 2,
                Name = "R&D",
                EmployeeCount = 54,
                Location = "ShangHai"
            });
            _departments.Add(new Department
            {
                Id = 3,
                Name = "Sales",
                EmployeeCount = 200,
                Location = "China"
            });
            _departments.Add(new Department
            {
                Id = 4,
                Name = "BeiDa",
                EmployeeCount = 1000,
                Location = "NanJing"
            });
        }
        public Task<IEnumerable<Department>> GetAll()
        {
            return Task.Run(() => _departments.AsEnumerable());
        }
        public Task<Department> GetById(int Id)
        {
            return Task.Run(() => _departments.FirstOrDefault(x => x.Id == Id));
        }
        public Task<Department> Add(Department department)
        {
            department.Id = _departments.Max(x => x.Id) + 1;
            _departments.Add(department);
            return Task.Run(() => department);
        }
    }
}
