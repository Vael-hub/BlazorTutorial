using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Repositories
{
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Récupère la totalité des poles
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Department>> GetDepartments();
        /// <summary>
        /// récupère un pole
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        Task<Department> GetDepartment(int departmentId);
    }
}
