using Microsoft.AspNetCore.Http;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-Za-z]{2}\d{5}$", ErrorMessage = "Invalid Employee Code. First 2 letters are alphabets and then 5 letters should be numeric.")]
        public string? EmployeeCode { get; set; }
        public string? Name { get; set; }
        public string? MobileNo { get; set; }
        public DateTime? DOB { get; set; }
        public string? Gender { get; set; }
        public string? Photo { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
    }
}
