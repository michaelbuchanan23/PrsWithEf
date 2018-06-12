using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsEf
{
    public class PurchaseRequestLineitem
    {

        public int Id { get; set; }

        [StringLength(80)]
        [Required]
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int PurchaseRequestId { get; set; }
        public virtual PurchaseRequest PurchaseRequest { get; set; }
    }
}
