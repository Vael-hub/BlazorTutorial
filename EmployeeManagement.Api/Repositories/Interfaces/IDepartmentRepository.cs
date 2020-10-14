using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
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
        /// <summary>
        /// ajoute un pole
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        Task<Department> AddDepartment(Department department);
        /// <summary>
        /// modifie un pole exitant
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        Task<ActionResult<Department>> UpdateDepartment(Department department);
    }
}
