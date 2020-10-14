using EmployeeManagement.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TutoBlazorCustom.Components.ValidatorsCustom;

namespace EmployeeManagement.Web.Models
{
    public class EditEmployeeModel
    {
        public int EmployeeId { get; set; }
        /// <summary>
        /// prénom de l'employé
        /// </summary>
        [Required(ErrorMessage = "Le prénom est obligatoire")]
        [MinLength(2, ErrorMessage = "Le prénom doit posséder deux caractères minimum")]
        public string FirstName { get; set; }
        /// <summary>
        /// nom de l'employé
        /// </summary>
        [Required(ErrorMessage = "Le Nom est obligatoire")]
        [MinLength(2, ErrorMessage = "Le nom doit posséder deux caractères minimum")]
        public string LastName { get; set; }
        /// <summary>
        /// Email de l'employé
        /// </summary>
        [EmailAddress (ErrorMessage = "L'adresse mail n'est pas valide")]
        [EmailValidator(DomainName = "orange.com",
            ErrorMessage = "Uniquement les adresses mails orange.com sont autorisées")]
        public string Email { get; set; }
        /// <summary>
        /// Confirmation de l'email
        /// </summary>
        [EmailAddress]
        [EmailValidator(DomainName = "orange.com",
            ErrorMessage = "Uniquement les adresses mails orange.com sont autorisées")]
        [CompareProperty("Email", ErrorMessage = "L'email ne correspond pas")]
        public string ConfirmEmail { get; set; }
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
        [ValidateComplexType]
        public Department Department { get; set; } = new Department();
        /// <summary>
        /// Id du pole de l'employé
        /// </summary>
        public int DepartmentId { get; set; }
    }
}
