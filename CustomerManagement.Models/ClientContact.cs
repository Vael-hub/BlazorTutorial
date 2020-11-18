using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessManagement.Models
{
    public class ClientContact
    {
        public int ContactId { get; set; }
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
        /// Société du contact
        /// </summary>
        public Society Society { get; set; }

    }
}
