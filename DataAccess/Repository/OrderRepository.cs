using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {

        public IEnumerable<OrderObject> GetOrders() => OrderDAO.Instance.GetOrders();

        public IEnumerable<OrderObject> GetOrdersWithUserId(int userID) => OrderDAO.Instance.GetOrdersByUserID(userID);

        public void InsertOrder(OrderObject order) => OrderDAO.Instance.Create(order);

        public void DeleteOrder(int orderID) => OrderDAO.Instance.Delete(orderID);

        public void UpdateOrder(OrderObject order) => OrderDAO.Instance.Update(order);
    }
}
