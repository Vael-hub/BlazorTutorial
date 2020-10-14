using EmployeeManagement.Api.Repositories;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;


        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetDepartments()
        {
            try
            {
                return Ok(await departmentRepository.GetDepartments());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Impossible de récupérer la liste des pôle depuis la base de données");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            try
            {
                Department result = await departmentRepository.GetDepartment(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Impossible de récupérer le pôle depuis la base de données");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Department>> AddDepartment(Department department)
        {
            try
            {
                if(department == null)
                {
                    return BadRequest();
                }

                Department dep = await departmentRepository.GetDepartment(department.DepartmentId);

                if (dep.DepartmentName == department.DepartmentName)
                {
                    ModelState.AddModelError("DepartmentName","Le pole existe déjà");
                    return BadRequest(ModelState);
                }

                Department departmentCreated = await departmentRepository.AddDepartment(department);

                return CreatedAtAction(nameof(GetDepartment), new { id = departmentCreated.DepartmentId }, departmentCreated);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Impossible de créer le pole ");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Department>> UpdateEmployee(Department department)
        {
            try
            {
                Department departmentToUpdate = await departmentRepository.GetDepartment(department.DepartmentId);

                if (departmentToUpdate == null)
                {
                    return NotFound($"Le pole avec l'id = {department.DepartmentId} n'existe pas");
                }

                return await departmentRepository.UpdateDepartment(department);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Impossible de modifier le pole ");
            }
        }

    }
}
