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
    public interface IRentItemsService
    {
        void Add(RentalItems items);
        void Remove(RentalItems items);
        IEnumerable<RentalItems> GetAll();
    }
    public class RentItemsService : IRentItemsService
    {
        IUnitOfWork unitOfWork;
        IRepository<RentalItems> rentItems;
        IMapper mapper;
        LightingModel context = new LightingModel();
        public RentItemsService()
        {
            unitOfWork = new UnitOfWork(context);
            rentItems = unitOfWork.RentalItemsRepository;
            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RentalItems, RentalItems>();
            });
            mapper = new Mapper(config);
        }
        public void Add(RentalItems items)
        {
            unitOfWork.RentalItemsRepository.Insert(items);
            unitOfWork.Save();
        }
        public IEnumerable<RentalItems> GetAll()
        {
            foreach (var item in rentItems.Get())
            {
                yield return new RentalItems()
                {
                    Id = item.Id,
                    ECode = item.ECode,
                    Descriprion = item.Descriprion,
                    RentalItemPieces = item.RentalItemPieces
                };
            }
        }
        public void Remove(RentalItems items)
        {
            unitOfWork.RentalItemsRepository.Delete(items);
            unitOfWork.Save();
        }
    }
}
