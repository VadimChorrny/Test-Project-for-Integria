using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class OrderLines
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public Orders Orders { get; set; }
        public int? RentalItemId { get; set; }
        public RentalItems RentalItems { get; set; }
        public int Quantity { get; set; }
    }
}
