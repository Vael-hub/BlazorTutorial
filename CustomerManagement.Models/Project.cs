using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Models
{
    public class Project
    {
        /// <summary>
        /// Nom du client
        /// </summary>
        public Customer Customer { get; set; }
        /// <summary>
        /// Code projet pour imputation
        /// </summary>
        public string ProjectCode { get; set; }
        /// <summary>
        /// Date de début du projet
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Date de fin du projet
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Durée du projet
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// Nombre de personnes sur le projet
        /// </summary>
        public int Resources { get; set; }
        /// <summary>
        /// Employés sur le projet
        /// </summary>
        public Employee Employee { get; set; }
        /// <summary>
        /// Projet dans les temps ou non
        /// </summary>
        public bool IsLate { get; set; }
        /// <summary>
        /// Méthode de gestion du projet
        /// </summary>
        public Method Method { get; set; }
    }
}
