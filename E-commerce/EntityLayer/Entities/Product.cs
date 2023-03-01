using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Cannot be empty!")]
        [StringLength(60, ErrorMessage = "Max 60 characters allowed!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Cannot be empty!")]
        [StringLength(160, ErrorMessage = "Max 160 characters allowed!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Cannot be empty!")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Cannot be empty!")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "Cannot be empty!")]
        public bool Popular { get; set; }
        [Required(ErrorMessage = "Cannot be empty!")]
        public bool isApproved { get; set; }
        [Required(ErrorMessage = "Cannot be empty!")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Cannot be empty!")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Cannot be empty!")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
