using AutoMapper;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IRentalItemPiecesService
    {
        void Add(RentalItemPieces items);
        void Remove(RentalItemPieces items);
        IEnumerable<RentalItemPieces> GetAll();
    }
    public class RentItemPiecesService : IRentalItemPiecesService
    {
        IUnitOfWork unitOfWork;
        IRepository<RentalItemPieces> rentItemPieces;
        IMapper mapper;

        LightingModel context = new LightingModel();

        public RentItemPiecesService()
        {
            unitOfWork = new UnitOfWork(context);
            rentItemPieces = unitOfWork.RentalItemPiecesRepository;
            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RentalItemPieces, RentalItemPieces>();
            });
            mapper = new Mapper(config);
        }
        public void Add(RentalItemPieces items)
        {
            unitOfWork.RentalItemPiecesRepository.Insert(items);
            unitOfWork.Save();
        }

        public IEnumerable<RentalItemPieces> GetAll()
        {
            foreach (var item in rentItemPieces.Get())
            {
                yield return new RentalItemPieces()
                {
                    Id = item.Id,
                    Barcode = item.Barcode,
                    SerialNumber = item.SerialNumber,
                    RentalItems = item.RentalItems
                };
            }
        }

        public void Remove(RentalItemPieces items)
        {
            unitOfWork.RentalItemPiecesRepository.Delete(items);
            unitOfWork.Save();
        }
    }
}
