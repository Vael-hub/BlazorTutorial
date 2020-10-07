using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.Models.ValidatorsCustom
{
    public class EmailValidator: ValidationAttribute
    {

        public string DomainName { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                //récupère l'adresse mail saisie la split après l'arobase 
                //et vérifie que le nom de domaine correspond
                string[] strings = value.ToString().Split('@');
                if (strings.Length > 1 && strings[1].ToUpper() == DomainName.ToUpper())
                {
                    return null;
                }
                else
                {
                    return new ValidationResult(ErrorMessage,
                        new[] { validationContext.MemberName });
                }
            }
            return null;
        }
    }
}
