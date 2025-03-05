using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Phone]
        public string PhoneNumber { get; set; }
        
        [Required]
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        public DateTime HireDate { get; set; }
        
        public string Department { get; set; }
        
        public string JobTitle { get; set; }
        
        [Required]
        public EmploymentStatus Status { get; set; }
        
        public decimal Salary { get; set; }
        
        public string ManagerId { get; set; }
        
        public string Address { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        
        public string ProfilePicturePath { get; set; }
        
        public string BankAccountNumber { get; set; }
        public string TaxIdentificationNumber { get; set; }
        
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<LeaveRequest> LeaveRequests { get; set; }
        public ICollection<Performance> Performances { get; set; }
        public ICollection<Payroll> Payrolls { get; set; }
    }

    public enum EmploymentStatus
    {
        Active,
        Inactive,
        Suspended,
        Terminated
    }

    public class Attendance
    {
        public int Id { get; set; }
        
        [Required]
        public int EmployeeId { get; set; }
        
        [Required]
        public DateTime CheckIn { get; set; }
        
        public DateTime? CheckOut { get; set; }
        
        public bool IsLate { get; set; }
        
        public Employee Employee { get; set; }
    }

    public class LeaveRequest
    {
        public int Id { get; set; }
        
        [Required]
        public int EmployeeId { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }
        
        [Required]
        public LeaveType Type { get; set; }
        
        public string Reason { get; set; }
        
        public LeaveStatus Status { get; set; }
        
        public Employee Employee { get; set; }
    }

    public enum LeaveType
    {
        Annual,
        Sick,
        Maternity,
        Paternity,
        Unpaid,
        Bereavement
    }

    public enum LeaveStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public class Performance
    {
        public int Id { get; set; }
        
        [Required]
        public int EmployeeId { get; set; }
        
        [Required]
        public DateTime EvaluationDate { get; set; }
        
        public decimal Rating { get; set; }
        
        public string ReviewNotes { get; set; }
        
        public Employee Employee { get; set; }
    }

    public class Payroll
    {
        public int Id { get; set; }
        
        [Required]
        public int EmployeeId { get; set; }
        
        [Required]
        public DateTime PayPeriodStart { get; set; }
        
        [Required]
        public DateTime PayPeriodEnd { get; set; }
        
        public decimal BasicSalary { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetPay { get; set; }
        
        public PayrollStatus Status { get; set; }
        
        public Employee Employee { get; set; }
    }

    public enum PayrollStatus
    {
        Pending,
        Processed,
        Failed
    }
}
