using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// récupère la liste des employés
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetJsonAsync<Employee []>("api/employees");
        }


        /// <summary>
        /// récupère un employé en fonction de l'id renseigné
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetJsonAsync<Employee>($"api/employees/{id}");
        }

        /// <summary>
        /// Met à jour les informations d'un employé 
        /// </summary>
        /// <param name="updatedEmployee"></param>
        /// <returns></returns>
        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            return await httpClient.PutJsonAsync<Employee>($"api/employees", updatedEmployee);
        }

        /// <summary>
        /// Créer un nouvel employé
        /// </summary>
        /// <param name="newEmployee"></param>
        /// <returns></returns>
        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            return await httpClient.PostJsonAsync<Employee>($"api/employees", newEmployee);
        }

        /// <summary>
        /// Supprime un employé
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteEmployee(int id)
        {
             await httpClient.DeleteAsync($"api/employees/{id}");
        }
    }
}
