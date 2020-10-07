using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages.Cascading
{
    public class CascadingChildBase : ComponentBase
    {
        [CascadingParameter(Name = "Style")]
        public string ChildStyle { get; set; }
        [CascadingParameter(Name = "BorderStyle")]
        public string ChildBorderStyle { get; set; }
        [CascadingParameter]
        public int Counter { get; set; }
    }
}
