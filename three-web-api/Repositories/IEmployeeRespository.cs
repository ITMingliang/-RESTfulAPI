using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Models;

namespace Three.Services
{
    public interface IEmployeeRespository
    {
        Task<Employee> Add(Employee employee);//Task<Employee> Add(Employee employee); //
        Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId);
        Task<Employee> GetById(int id);
        Task<Employee> Fire(int Id);
    }
}
