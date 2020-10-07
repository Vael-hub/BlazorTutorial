using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoBlazorCustom.Components
{
    public class CustomInputSelect<TValue> : InputSelect<TValue>
    {
        /// <summary>
        /// Surcharge de la méthode try parse de l'input select de base pour inclure la prise en compte des valeurs en int
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <param name="validationErrorMessage"></param>
        /// <returns></returns>
        protected override bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage)
        {
            if(typeof(TValue) == typeof(int))
            {
                if(int.TryParse(value, out var resultInt))
                {
                    result = (TValue)(object)resultInt;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationErrorMessage =
                        $"La valeur séléctionnée {value} n'est pas un nombre valide";
                    return false;
                }
            }
            else
            {
                return base.TryParseValueFromString(value, out result, out validationErrorMessage);
            }
            
        }
    }
}
