using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Récupère la liste des employés
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Employee>>GetEmployees();
        /// <summary>
        /// Récuère un employé 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Employee> GetEmployee(int id);
        /// <summary>
        /// Modifie un employé
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Employee> UpdateEmployee(Employee updatedEmployee);
        /// <summary>
        /// Ajoute un employé
        /// </summary>
        /// <param name="newEmployee"></param>
        /// <returns></returns>
        Task<Employee> CreateEmployee(Employee newEmployee);
        /// <summary>
        /// Supprime un employé
        /// </summary>
        /// <returns></returns>
        Task DeleteEmployee(int id);

    }
}
