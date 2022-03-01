using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Models;

namespace ThreeApi.Repositories
{
    public interface ISummaryRespository
    {
        Task<CompanySummary> GetCompanySummary();
    }
}
