using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Shared
{
    public class NavMenuBase : ComponentBase
    {
        /// <summary>
        /// injection de la classe Navigation manager
        /// </summary>
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected bool collapseNavMenu = true;

        protected string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        protected void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        protected void HandleClick()
        {
            NavigationManager.NavigateTo("editemployee", true);
        }
    }
}
