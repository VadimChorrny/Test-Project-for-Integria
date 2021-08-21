using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Customer { get; set; }
        [MaxLength(50)]
        public string OrderName { get; set; }
    }
}
