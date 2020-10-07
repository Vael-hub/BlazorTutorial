using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;
using TutoBlazorCustom.Components;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase : ComponentBase
    {        

        /// <summary>
        /// injection du service pour accéder aux méthodes de l'api employees
        /// </summary>
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        /// <summary>
        /// injection du service pour accéder aux méthodes de l'api departments
        /// </summary>
        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        /// <summary>
        /// injection de la classe Navigation manager
        /// </summary>
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        /// <summary>
        /// injection du mapper
        /// </summary>
        [Inject]
        public IMapper Mapper { get; set; }
        /// <summary>
        /// Objet employé pour stocker les données renvoyées de l'api
        /// </summary>
        private Employee Employee { get; set; } = new Employee();
        /// <summary>
        /// Modèle editemployé pour utiliser les données de l'objet employé dans la vue
        /// </summary>
        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();
        /// <summary>
        /// Initialisation de la liste de pole
        /// </summary>
        public List<Department> Departments { get; set; } = new List<Department>();
        /// <summary>
        /// Id de l'employé passé en paramètre
        /// </summary>
        [Parameter]
        public string Id { get; set; }

        /// <summary>
        /// String pour rendre le header dynamique en fonction de l'édition ou la création d'employés
        /// </summary>
        public string PageHeader { get; set; }

        /// <summary>
        /// Booléen du composant de confirmation custom
        /// </summary>
        protected ConfirmBase ConfirmationSuppression { get; set; }

        /// <summary>
        /// Id du pole
        /// Déclaré pour l'utilisation de l'input select 
        /// inutile avec la création d'un composant custom 
        /// </summary>
        //public string DepartmentId { get; set; }

        /// <summary>
        /// Les données à afficher à l'initialisation de la page
        /// </summary>
        /// <returns></returns>
        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeId);

            if(employeeId != 0)
            {
                PageHeader = "Modification de l'employé";
                Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            }
            else
            {
                PageHeader = "Création d'un employé";
                Employee = new Employee
                {
                    DepartmentId = 1,
                    DateOfBirth = DateTime.Now,
                    PhotoPath = "images/nophoto.jpg"                                    
                };
            }

            
            Departments = (await DepartmentService.GetDepartments()).ToList();

            Mapper.Map(Employee, EditEmployeeModel);

            //Parse de l'id du pole car l'inputselect de base ne gère pas les int
            //inutile suite à la surcharge de l'inputselect par la création d'un composant custom
            //DepartmentId = Employee.DepartmentId.ToString();

        }

        /// <summary>
        /// Vérifie la validité du formulaire 
        /// Appel la création de l'employé ou la modification si un id est déjà renseigné
        /// </summary>
        /// <returns></returns>
        protected async Task HandleValidSubmit()
        {
            Mapper.Map(EditEmployeeModel, Employee);

            Employee result = null;

            if(Employee.EmployeeId != 0)
            {
                result = await EmployeeService.UpdateEmployee(Employee);
            }
            else
            {
                result = await EmployeeService.CreateEmployee(Employee);
            }
            
            if(result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }

        /// <summary>
        /// Affiche la popup de confirmation de suppression
        /// </summary>
        /// <returns></returns>
        protected void Delete_Onclick()
        {
            ConfirmationSuppression.Show();
        }

        /// <summary>
        /// Confirmation de la suppression puis redirection à la liste des employés
        /// </summary>
        /// <param name="deleteConfirmed"></param>
        /// <returns></returns>
        protected async Task ConfirmDelete_Onclick(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
