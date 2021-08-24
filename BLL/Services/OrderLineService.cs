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
    public interface IOrderLineService
    {
        void Add(OrderLines orderLines);
        void Remove(OrderLines orderLines);
        IEnumerable<OrderLines> GetAll();
        void Update(OrderLines order);
    }
    public class OrderLineService : IOrderLineService
    {
        IUnitOfWork unitOfWork;
        IRepository<OrderLines> lines;
        IMapper mapper;

        LightingModel context = new LightingModel();

        public OrderLineService()
        {
            unitOfWork = new UnitOfWork(context);
            lines = unitOfWork.OrderLinesRepository;
            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderLines, OrderLines>();
            });
            mapper = new Mapper(config);
        }
        public void Add(OrderLines orderLines)
        {
            unitOfWork.OrderLinesRepository.Insert(orderLines);
            unitOfWork.Save();
        }

        public IEnumerable<OrderLines> GetAll()
        {
            foreach (var item in lines.Get())
            {
                yield return new OrderLines()
                {
                    Id = item.Id,
                    Orders = item.Orders,
                    RentalItems = item.RentalItems,
                    Quantity = item.Quantity
                };
            }
        }

        public void Remove(OrderLines orderLines)
        {
            unitOfWork.OrderLinesRepository.Delete(orderLines);
            unitOfWork.Save();
        }

        public void Update(OrderLines order)
        {
            unitOfWork.OrderLinesRepository.Update(order);
            unitOfWork.Save();
        }
    }
}
