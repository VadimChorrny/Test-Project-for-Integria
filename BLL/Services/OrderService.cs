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
    public interface IOrderService
    {
        void Add(Orders orders);
        void Remove(Orders orders);
        IEnumerable<Orders> GetAll();
        IEnumerable<string> GetCustomerName();
    }
    public class OrderService : IOrderService
    {
        IUnitOfWork unitOfWork;
        IRepository<Orders> orders;
        IMapper mapper;

        LightingModel context = new LightingModel();

        public OrderService()
        {
            unitOfWork = new UnitOfWork(context);
            orders = unitOfWork.OrdersRepository;
            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Orders, Orders>();
            });
            mapper = new Mapper(config);
        }
        public void Add(Orders orders)
        {
            unitOfWork.OrdersRepository.Insert(orders);
            unitOfWork.Save();
        }

        public IEnumerable<Orders> GetAll()
        {
            foreach (var item in orders.Get())
            {
                yield return new Orders()
                {
                    Id = item.Id,
                    Customer = item.Customer,
                    OrderName = item.OrderName
                };
            }
        }

        public IEnumerable<string> GetCustomerName()
        {
            return unitOfWork.OrdersRepository.Get().Select(a => a.Customer);
        }

        public void Remove(Orders orders)
        {
            unitOfWork.OrdersRepository.Delete(orders);
            unitOfWork.Save();
        }
    }
}
