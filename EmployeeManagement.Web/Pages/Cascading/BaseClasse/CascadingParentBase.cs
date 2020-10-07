using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages.Cascading
{
    public class CascadingParentBase : ComponentBase
    {
        public string Style { get; set; } = "color:red";

        public string BorderStyle { get; set; } = "border:1px solid red";

        public int Counter { get; set; } = 0;

        protected void IncrementCounter()
        {
            Counter = Counter + 1;
        }
        
        protected void ResetCounter()
        {
            Counter = 0;
        }
    }
}
