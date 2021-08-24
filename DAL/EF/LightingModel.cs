using DAL.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace DAL.EF
{
    public class LightingModel : DbContext
    {
        public LightingModel() : base("name=LightingModel"){}
        public virtual DbSet<RentalItems> RentalItems { get; set; }
        public virtual DbSet<RentalItemPieces> RentalItemPieces { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderLines> OrderLines { get; set; }
    }
}