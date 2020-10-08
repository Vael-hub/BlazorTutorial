using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages.ComposBasique
{
    public class EmployeeListBase : ComponentBase
    {
        /// <summary>
        /// injection du service 
        /// </summary>
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        /// <summary>
        /// Liste des employés
        /// </summary>
        public IEnumerable<Employee> Employees { get; set; }
        /// <summary>
        /// Permet l'affichage ou non du footer et de ses boutons
        /// </summary>
        public bool ShowFooter { get; set; } = true;
        /// <summary>
        /// Nombre d'employés sélectionnés avec la checkbox
        /// </summary>
        protected int EmployeeSelectionCount { get; set; } = 0;

        /// <summary>
        /// Affichage de la liste des employés à l'initialisation de la page
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
        }
        /// <summary>
        /// Incrémente ou décrémente le compteur d'employés sélectionnés
        /// </summary>
        /// <param name="isSelected"></param>
        protected void EmployeeSelectionChange(bool isSelected)
        {
            if(isSelected)
            {
                EmployeeSelectionCount++;
            }
            else
            {
                EmployeeSelectionCount--;
            }
        }

        protected async Task EmployeeDeletedChange()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
        }
    }
}
