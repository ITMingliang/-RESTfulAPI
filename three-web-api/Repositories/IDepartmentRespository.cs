﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Models;

namespace ThreeApi.Repositories
{
    public interface IDepartmentRespository
    {
        Task<Department> Add(Department department);

        Task<IEnumerable<Department>> GetAll();

        Task<Department> GetById(int id);
    }
}
