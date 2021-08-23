using DAL.EF;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUnitOfWork
    {
        void Save();
        GenericRepository<OrderLines> OrderLinesRepository { get; }
        GenericRepository<Orders> OrdersRepository { get; }
        GenericRepository<RentalItemPieces> RentalItemPiecesRepository { get; }
        GenericRepository<RentalItems> RentalItemsRepository { get; }
    }
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private LightingModel context;

        private GenericRepository<OrderLines> orderLinesRepository;
        private GenericRepository<Orders> ordersRepository;
        private GenericRepository<RentalItemPieces> rentalItemPiecesRepository;
        private GenericRepository<RentalItems> rentalItemsRepository;

        public UnitOfWork(LightingModel context)
        {
            this.context = context;
        }

        public GenericRepository<OrderLines> OrderLinesRepository
        {
            get
            {
                // lazy loading
                if (this.orderLinesRepository == null)
                {
                    this.orderLinesRepository = new GenericRepository<OrderLines>(context);
                }
                return orderLinesRepository;
            }
        }
        public GenericRepository<Orders> OrdersRepository
        {
            get
            {
                // lazy loading
                if (this.ordersRepository == null)
                {
                    this.ordersRepository = new GenericRepository<Orders>(context);
                }
                return ordersRepository;
            }
        }
        public GenericRepository<RentalItemPieces> RentalItemPiecesRepository
        {
            get
            {
                // lazy loading
                if (this.rentalItemPiecesRepository == null)
                {
                    this.rentalItemPiecesRepository = new GenericRepository<RentalItemPieces>(context);
                }
                return rentalItemPiecesRepository;
            }
        }
        public GenericRepository<RentalItems> RentalItemsRepository
        {
            get
            {
                // lazy loading
                if (this.rentalItemsRepository == null)
                {
                    this.rentalItemsRepository = new GenericRepository<RentalItems>(context);
                }
                return rentalItemsRepository;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
