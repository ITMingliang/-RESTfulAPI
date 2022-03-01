using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Models;

namespace Three.Services
{
    public class EmployeeRespository : IEmployeeRespository
    {
        private readonly List<Employee> _employees = new List<Employee>();

        public EmployeeRespository()
        {
            _employees.Add(new Employee
            {
                Id = 1,
                DepartmentId = 1,
                FirstName = "Nick",
                LastName = "Carter",
                Gender = Gender.男
            });
            _employees.Add(new Employee
            {
                Id = 2,
                DepartmentId = 1,
                FirstName = "Michael",
                LastName = "Jackson",
                Gender = Gender.男
            });
            _employees.Add(new Employee
            {
                Id = 3,
                DepartmentId = 1,
                FirstName = "Mariah",
                LastName = "Cary",
                Gender = Gender.女
            });
            _employees.Add(new Employee
            {
                Id = 4,
                DepartmentId = 2,
                FirstName = "Axl",
                LastName = "Rose",
                Gender = Gender.男
            });
            _employees.Add(new Employee
            {
                Id = 5,
                DepartmentId = 2,
                FirstName = "Kate",
                LastName = "Winslet",
                Gender = Gender.女
            });
            _employees.Add(new Employee
            {
                Id = 6,
                DepartmentId = 3,
                FirstName = "Rob",
                LastName = "Thomas",
                Gender = Gender.男
            });
            _employees.Add(new Employee
            {
                Id = 7,
                DepartmentId = 3,
                FirstName = "Avril",
                LastName = "Lavigne",
                Gender = Gender.女
            });
        }


        public Task<Employee> Add(Employee employee)
        {
            employee.Id = _employees.Max(x => x.Id) + 1;
            _employees.Add(employee);
            return Task.Run(() => employee); 
        }
        public Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId)
        {
            return Task.Run(() => _employees.Where(x => x.DepartmentId == departmentId));
        }

        public Task<Employee> GetById(int id)
        {
            var employee = _employees.FirstOrDefault(x => x.Id == id);
            return Task.Run(() => employee);
        }
        public Task<Employee> Fire(int Id)
        {
            return Task.Run(() =>
            {
                var employee = _employees.FirstOrDefault(x => x.Id == Id);
                if (employee != null)
                {
                    employee.Fired = true;
                    return employee;
                }
                return null;
            });
        }
    }
}
