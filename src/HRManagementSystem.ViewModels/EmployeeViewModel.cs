using System;
using System.ComponentModel.DataAnnotations;
using HRManagementSystem.Models;

namespace HRManagementSystem.ViewModels
{
    public class EmployeeCreateViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        
        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        
        public string Department { get; set; }
        
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        
        public decimal Salary { get; set; }
        
        [Display(Name = "Manager")]
        public string ManagerId { get; set; }
    }

    public class EmployeeDetailsViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public EmploymentStatus Status { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string ProfilePicturePath { get; set; }
    }

    // Add other ViewModels from previous shared code
}
