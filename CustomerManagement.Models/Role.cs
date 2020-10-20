using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessManagement.Models
{
    public class Role
    {
        /// <summary>
        /// Id du role
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// Nom du role dans la team
        /// </summary>
        [Required(ErrorMessage = "Le nom du pôle est obligatoire")]
        public string RoleName { get; set; }
    }
}
