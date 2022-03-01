using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Models;

namespace ThreeApi.Repositories
{
    public class SummaryRespository : ISummaryRespository
    {
        private readonly IDepartmentRespository _departmentRespository;

        public SummaryRespository(IDepartmentRespository departmentRespository)
        {
            _departmentRespository = departmentRespository;
        }

        public Task<CompanySummary> GetCompanySummary()
        {
            return Task.Run(() =>
            {
                var all = _departmentRespository.GetAll().Result;
                return new CompanySummary
                {
                    EmployeeCount = all.Sum(x => x.EmployeeCount),
                    AverageDepartmentEmployeeCount = (int)all.Average(x => x.EmployeeCount)
                };
            });
        }
    }
}
