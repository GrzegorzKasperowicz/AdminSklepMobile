using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Product
    {
        [Key]
        public int IdProduct { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool IsActive { get; set; }
        public int IdProductType { get; set; }
        [ForeignKey("IdProductType")]
        public virtual ProductType? ProductType { get; set; }

        public int IdProductCategory { get; set; }
        [ForeignKey("IdProductCategory")]
        public virtual ProductCategory? ProductCategory { get; set; }

        public int IdProductProducer { get; set; }
        [ForeignKey("IdProductProducer")]
        public virtual ProductProducer? ProductProducer { get; set; }

        public virtual ICollection<Order>? Order { get; set; }
    }
}
