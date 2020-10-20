using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Models
{
    public class Team
    {
        /// <summary>
        /// Employés sur le projet
        /// </summary>
        public IEnumerable<Employee> Employees { get; set; }
        /// <summary>
        /// Nom du client
        /// </summary>
        public IEnumerable<ClientContact> Customer { get; set; }
        /// <summary>
        /// Ressources de la team doit correspondre aux ressources du projet
        /// </summary>
        public int TeamResources { get; set; }
    }
}
