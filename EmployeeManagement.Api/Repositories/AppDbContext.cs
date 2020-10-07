using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 2, DepartmentName = "RH" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 3, DepartmentName = "Paye" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 4, DepartmentName = "Admin" });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Tanguy",
                LastName = "Helbert",
                Email = "tanguy.helbert1@orange.com",
                DateOfBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/tigre.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "Nicolas",
                LastName = "Launay",
                Email = "nicolas.launay@orange.com",
                DateOfBirth = new DateTime(1981, 12, 22),
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "images/panda.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FirstName = "François",
                LastName = "Couant",
                Email = "francois.couant@orange.com",
                DateOfBirth = new DateTime(1979, 11, 11),
                Gender = Gender.Female,
                DepartmentId = 3,
                PhotoPath = "images/vache.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 4,
                FirstName = "Alexandre",
                LastName = "Vicente",
                Email = "alexanre.vicente@orange.com",
                DateOfBirth = new DateTime(1982, 9, 23),
                Gender = Gender.Other,
                DepartmentId = 4,
                PhotoPath = "images/koala.jpg"
            });
        }
    }
}
