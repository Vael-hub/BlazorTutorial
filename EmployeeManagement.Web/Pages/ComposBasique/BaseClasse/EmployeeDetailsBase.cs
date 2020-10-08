using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoBlazorCustom.Components;

namespace EmployeeManagement.Web.Pages.ComposBasique
{
    public class EmployeeDetailsBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();

        /// <summary>
        /// Variable de texte en fonction de l'état du footer
        /// </summary>
        protected string ButtonText { get; set; } = "Replie le footer";
        /// <summary>
        /// variable pour la classe CSS pour rendre ou non visible le footer
        /// </summary>
        protected string CssClass { get; set; } = null;

        /// <summary>
        /// récupération de la position de la souris
        /// </summary>
        protected string Coordinates { get; set; }

        /// <summary>
        /// injection du service 
        /// </summary>
        [Inject]
        public IEmployeeService EmployeeService { get; set; }


        /// <summary>
        /// paramètre de la route spécifiée dans le composants Razor
        /// variable en string car récupération depuis l'url
        /// </summary>
        [Parameter]
        public string Id { get; set; }

        /// <summary>
        /// Booléen du composant de confirmation custom
        /// </summary>
        protected ConfirmBase ConfirmationSuppression { get; set; }

        /// <summary>
        /// injection de la classe Navigation manager
        /// </summary>
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        /// <summary>
        /// initialisation de la page de visualisation d'employée 
        /// avec les données récupérées de sa fiche renseignée par son id
        /// </summary>
        /// <returns></returns>
        protected async override Task OnInitializedAsync()
        {
            //gestion du paramètre optionnel ici l'Id en initialisant une valeur par défaut
            //ou tout autre pages choisies
            // Id = Id ?? "1"

            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
        }

        /// <summary>
        /// Permet d'afficher les coordonnées de la position de la souris 
        /// avec l'évènement qui est @onmousmove déclaré dans la vue
        /// </summary>
        /// <param name="mouseEvent"></param>
        protected void Mouse_Move(MouseEventArgs mouseEvent)
        {
            Coordinates = $"X = {mouseEvent.ClientX} Y = {mouseEvent.ClientY}";
        }

        /// <summary>
        /// Permet d'afficher et de cacher le footer et son contenu
        /// le texte du bouton change en fonction de l'état du footer
        /// </summary>
        protected void Button_Click()
        {
            if (ButtonText == "Replie le footer")
            {
                ButtonText = "Déplie le footer";
                CssClass = "HideFooter";
            }
            else
            {
                CssClass = null;
                ButtonText = "Replie le footer";
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
