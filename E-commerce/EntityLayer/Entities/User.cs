using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Cannot be empty!")]
        [StringLength(50, ErrorMessage = "Max 50 characters allowed!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Cannot be empty!")]
        [StringLength(60, ErrorMessage = "Max 60 characters allowed!")]
        public string SurName { get; set; }
        [Required(ErrorMessage = "Cannot be empty!")]
        [StringLength(80, ErrorMessage = "Max 80 characters allowed!")]
        [EmailAddress(ErrorMessage = "Check your mail format!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Cannot be empty!")]
        [StringLength(50, ErrorMessage = "Max 50 characters allowed!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Cannot be empty!")]
        [StringLength(16, ErrorMessage = "Max 16 characters allowed!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Cannot be empty!")]
        [StringLength(16, ErrorMessage = "Max 16 characters allowed!")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password cannot match!")]
        public string ConfirmPassword { get; set; }
        [StringLength(20, ErrorMessage = "Max 20 characters allowed!")]
        public string Role { get; set; }

    }
}
