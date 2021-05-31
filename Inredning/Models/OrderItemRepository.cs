using System.Collections.Generic;

namespace Inredning.Models
{
    public class OrderItemRepository : IOrderItemRepository
    {
        AppDbContext _appDbContext;

        public OrderItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<OrderItem> AllOrderItems
        {
            get
            {
                return _appDbContext.OrderItems;
            }
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            _appDbContext.OrderItems.Add(orderItem);
            _appDbContext.SaveChanges();
        }

        public void UpdateOrderItem(OrderItem updatedOrderItem)
        {
            foreach (OrderItem o in AllOrderItems)
                if (o.Name == updatedOrderItem.Name)
                {
                    o.Supplier = updatedOrderItem.Supplier;
                    o.IndividualPrice = updatedOrderItem.IndividualPrice;
                    o.Amount = updatedOrderItem.Amount;
                    o.Info = updatedOrderItem.Info;
                }
            _appDbContext.SaveChanges();
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            _appDbContext.OrderItems.Remove(orderItem);
            _appDbContext.SaveChanges();
        }
    }
}