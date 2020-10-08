using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoBlazorCustom.Components;

namespace EmployeeManagement.Web.Pages.ComposBasique
{
    public class DisplayEmployeeBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }
        [Parameter]
        public bool ShowFooter { get; set; }
        [Parameter]
        public EventCallback<bool> EmployeeSelected { get; set; }
        [Parameter]
        public EventCallback<int> EmployeeDeleted { get; set; }

        protected ConfirmBase ConfirmationSuppression { get; set;}
        /// <summary>
        /// injection du service pour accéder aux méthodes de l'api employees
        /// </summary>
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        protected async Task Checked(ChangeEventArgs eventArgs)
        {
           await EmployeeSelected.InvokeAsync((bool)eventArgs.Value);
        }

        protected void Delete_Onclick()
        {
            ConfirmationSuppression.Show();
        }

        protected async Task ConfirmDelete_Onclick(bool deleteConfirmed)
        {
            if(deleteConfirmed)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                await EmployeeDeleted.InvokeAsync(Employee.EmployeeId);
            }
        }
    }
}
