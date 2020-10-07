using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            //Mapping entre l'objet employés et le modèle pour l'édition de l'employé
            CreateMap<Employee, EditEmployeeModel>()
                .ForMember(dest => dest.ConfirmEmail, opt => opt.MapFrom(src => src.Email));
            CreateMap<EditEmployeeModel, Employee>();
        }
    }
}
