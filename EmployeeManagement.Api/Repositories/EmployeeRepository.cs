using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        /// <summary>
        /// Requête de recherche d'employés par nom ou genre
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = appDbContext.Employees;

            if(!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));
            }

            if(gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }

        /// <summary>
        /// Récupère la liste des employés
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await appDbContext.Employees.ToListAsync();
        }

        /// <summary>
        /// Récupère un employé
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await appDbContext.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }

        /// <summary>
        /// Récupération de l'employé en fonction de son adresse email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await appDbContext.Employees
                .FirstOrDefaultAsync(e => e.Email == email);
        }

        /// <summary>
        /// Ajoute un employé
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<Employee> AddEmployee(Employee employee)
        {
           EntityEntry<Employee> result = await appDbContext.Employees.AddAsync(employee);
           await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        /// <summary>
        /// Modifie un employé
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            Employee result = await appDbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        /// <summary>
        /// Supprime un employé
        /// </summary>
        /// <param name="employeeId"></param>
        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            Employee result = await appDbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (result != null)
            {
                appDbContext.Employees.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }       
    }
}
