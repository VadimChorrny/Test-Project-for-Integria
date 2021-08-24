using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class RentalItemPieces
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Barcode { get; set; }
        [MaxLength(50)]
        public string SerialNumber { get; set; }
        public ICollection<RentalItems> RentalItems { get; set; }
        public RentalItemPieces()
        {
            RentalItems = new List<RentalItems>();
        }
    }
}
