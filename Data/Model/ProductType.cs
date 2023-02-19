using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class ProductType
    {
        [Key]
        public int IdProductType { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Product>? Product { get; set; }
    }
}
