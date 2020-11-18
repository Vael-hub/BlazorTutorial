using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Models
{
    public class Society
    {
        public int SocietyId { get; set; }
        /// <summary>
        /// Nom de la société
        /// </summary>
        public string SocietyName { get; set; }
        /// <summary>
        /// Adresse de la société
        /// </summary>
        public string SocietyAdress { get; set; }
        /// <summary>
        /// Type de société
        /// </summary>
        public SocietyType Type { get; set; }
        /// <summary>
        /// A déja travaillé avec
        /// </summary>
        public bool NewClient { get; set; }
    }
}
