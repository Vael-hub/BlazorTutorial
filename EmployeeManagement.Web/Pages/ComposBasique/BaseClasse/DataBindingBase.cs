using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages.ComposBasique
{
    public class DataBindingBase : ComponentBase
    {
        /// <summary>
        /// Nom utilisé pour l'exemple d'association de données
        /// </summary>
        protected string Name { get; set; } = "De Ceglie";
        /// <summary>
        /// Genre utilisé pour l'exemple d'association de données
        /// </summary>
        protected string Gender { get; set; } = "Male";
        /// <summary>
        /// Modification de style utilisé pour le second exemple d'association de données
        /// </summary>
        protected string Color { get; set; } = "background-color:white";
        /// <summary>
        /// Champ de description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Mise à jour du nom en fonction de la saisie dans l'input
        /// </summary>
        /// <param name="changeEvent"></param>
        protected void Name_Change(ChangeEventArgs changeEvent)
        {
            Name = changeEvent.Value.ToString();
        }
    }
}
