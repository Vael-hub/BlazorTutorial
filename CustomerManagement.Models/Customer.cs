using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Models
{
    public class Customer
    {
        /// <summary>
        /// Prénom du client
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Nom du client
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Numéro de téléphone
        /// </summary>
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Mail de contact
        /// </summary>
        [EmailAddress(ErrorMessage = "L'adresse mail n'est pas valide")]
        public string Mail { get; set; }
        /// <summary>
        /// Nom de la société
        /// </summary>
        public string SocietyName { get; set; }
        /// <summary>
        /// Adresse de la société
        /// </summary>
        public string SocietyAdress { get; set; }
        
    }
}
