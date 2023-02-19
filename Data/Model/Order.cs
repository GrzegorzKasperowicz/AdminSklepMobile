using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Order
    {
        [Key]
        public int IdOrder { get; set; }
        public DateTime OrderDate { get; set; }
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Product? Product { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
        public int IdClient { get; set; }
        [ForeignKey("IdClient")]
        public virtual Client? Client { get; set; }
    }
}
