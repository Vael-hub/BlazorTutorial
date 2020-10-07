using EmployeeManagement.Models.ValidatorsCustom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.Models
{
    public class Employee
    {

        public int EmployeeId { get; set; }
        /// <summary>
        /// prénom de l'employé
        /// </summary>
        [Required (ErrorMessage = "Le prénom est obligatoire")]
        [MinLength(2, ErrorMessage = "Le prénom doit posséder deux caractères minimum")]
        public string FirstName { get; set; }
        /// <summary>
        /// nom de l'employé
        /// </summary>
        [Required (ErrorMessage = "Le Nom est obligatoire")]
        [MinLength(2, ErrorMessage = "Le nom doit posséder deux caractères minimum")]
        public string LastName { get; set; }
        /// <summary>
        /// Email de l'employé
        /// </summary>
        [EmailAddress (ErrorMessage = "L'adresse mail n'est pas valide")]
        [EmailValidator (DomainName = "orange.com",
            ErrorMessage = "Uniquement les adresses mails orange.com sont autorisées")]
        public string Email { get; set; }
        /// <summary>
        /// Date de naissance de l'employé
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Genre de l'employé sujet de contreverse 
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Chemin du stockage de la photo de l'employé
        /// </summary>
        public string PhotoPath { get; set; }

        public Department Department { get; set; }
        /// <summary>
        /// Id du pole de l'employé
        /// </summary>
        public int DepartmentId { get; set; }
        
    }
}
