using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages.Cascading
{
    public class CascadingGrandChildBase : ComponentBase
    {
        
        //[CascadingParameter(Name = "Style")]
        //public string GrandChildStyle { get; set; }

        //[CascadingParameter(Name = "BorderStyle")]
        //public string GrandChildBorderStyle { get; set; }

        //Les deux propriétés sont de type string et récupère toutes les deux la dernière valeur
        //qui est passé en cascade dans ce cas le style sur la bordure et donc le style sur la couleur ne fonctionne plus
        [CascadingParameter]
        public string GrandChildStyle { get; set; }
        [CascadingParameter]
        public string GrandChildBorderStyle { get; set; }
        [CascadingParameter]
        public int Counter { get; set; }

    }
}
