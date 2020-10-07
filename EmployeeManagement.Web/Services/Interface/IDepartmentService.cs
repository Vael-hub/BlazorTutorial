using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public interface IDepartmentService
    {
        /// <summary>
        /// Récupère la liste des poles
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Department>> GetDepartments();
        /// <summary>
        /// Récupère un pole 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Department> GetDepartment(int id);
    }
}
