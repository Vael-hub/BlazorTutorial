using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Récupère la liste des poles
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await httpClient.GetJsonAsync<Department[]>("api/departments");
        }
        /// <summary>
        /// Récupère un pole 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Department> GetDepartment(int id)
        {
            return await httpClient.GetJsonAsync<Department>($"api/departments/{id}");
        }        
    }
}
