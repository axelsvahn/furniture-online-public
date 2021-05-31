using System.Collections.Generic;

namespace Inredning.Models
{
    public interface IOrderItemRepository
    {
        IEnumerable<OrderItem> AllOrderItems { get; }

        void AddOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem orderItem);
        void RemoveOrderItem(OrderItem orderItem);
    }
}