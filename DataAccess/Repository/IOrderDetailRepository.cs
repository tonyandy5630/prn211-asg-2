using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetailObject> GetOrdersByOrderID(int orderID);

        void InsertOrderDetail(OrderDetailObject order);

        void DeleteOrderDetail(int orderID, int productID);

        void UpdateOrderDetail(OrderDetailObject order);

        void DeleteListOrderDetail(int orderID);
    }
}
