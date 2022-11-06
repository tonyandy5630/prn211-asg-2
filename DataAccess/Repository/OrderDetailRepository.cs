using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void DeleteListOrderDetail(int orderID) => OrderDetailDAO.Instance.DeleteOrderDetailsByOrderID(orderID);

        public void DeleteOrderDetail(int orderID, int productID) => OrderDetailDAO.Instance.Remove(orderID, productID);

        public IEnumerable<OrderDetailObject> GetOrdersByOrderID(int orderID) => OrderDetailDAO.Instance.GetOrderDetailsWithOrderId(orderID);

        public void InsertOrderDetail(OrderDetailObject order) => OrderDetailDAO.Instance.Create(order);

        public void UpdateOrderDetail(OrderDetailObject order) => OrderDetailDAO.Instance.Update(order);
    }
}
