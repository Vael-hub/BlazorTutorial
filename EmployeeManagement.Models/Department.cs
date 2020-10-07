using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Department
    {
        /// <summary>
        /// Id du pôle
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// Nom du pôle
        /// </summary>
        [Required(ErrorMessage = "Le nom du pôle est obligatoire")]
        public string DepartmentName { get; set; }
    }
}
