using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Repositories
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Recherche d'employé par Nom et Genre(optionnel)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        Task <IEnumerable<Employee>> Search(string name, Gender? gender);
        /// <summary>
        /// Récupère une liste d'employés
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetEmployees();
        /// <summary>
        /// Récupère un employé
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<Employee> GetEmployee(int employeeId);
        /// <summary>
        /// Récupération de l'employé en fonction de son email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<Employee> GetEmployeeByEmail(string email);
        /// <summary>
        /// Ajoute un employé
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task<Employee> AddEmployee(Employee employee);
        /// <summary>
        /// Modifie un employé
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task<Employee> UpdateEmployee(Employee employee);
        /// <summary>
        /// Supprime un employé
        /// </summary>
        /// <param name="employeeId"></param>
        Task<Employee> DeleteEmployee(int employeeId);
    }
}
