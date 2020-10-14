using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext appDbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        /// <summary>
        /// Récupère la totalité des poles dans une liste
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await appDbContext.Departments.ToListAsync();            
        }

        /// <summary>
        /// Retourne le pole voulu
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public async Task<Department> GetDepartment (int departmentId)
        {
            return await appDbContext.Departments
                .FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
        }

        /// <summary>
        /// Ajoute un pole
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public async Task<Department> AddDepartment(Department department)
        {
            EntityEntry<Department> result = await appDbContext.Departments.AddAsync(department);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ActionResult<Department>> UpdateDepartment(Department department)
        {
            Department result = await appDbContext.Departments
                .FirstOrDefaultAsync(d => d.DepartmentId == department.DepartmentId);

            if (result != null)
            {
                result.DepartmentName = department.DepartmentName;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
