using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Category
    {

        public int Id { get; set; }
        [Required (ErrorMessage = "Cannot be empty!")]
        [StringLength(60,ErrorMessage ="Max 60 characters allowed!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Cannot be empty!")]
        [StringLength(160, ErrorMessage = "Max 160 characters allowed!")]
        public string Description { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
