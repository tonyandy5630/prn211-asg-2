using BusinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO : BaseDAL
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();

        private OrderDetailDAO() { }

        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public List<OrderDetailObject> GetOrderDetailsWithOrderId(int orderID)
        {
            string SQLSelect = "SELECT OrderId, ProductId, UnitPrice, Quantity, Discount FROM OrderDetail WHERE OrderId = @OrderId";
            List<OrderDetailObject> orderDetails = null;
            IDataReader dataReader = null;
            try
            {
                var param = DataProvider.CreateParameter("@OrderId", 4, orderID, DbType.Int32);
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                orderDetails = new List<OrderDetailObject>();
                while (dataReader.Read())
                {
                    orderDetails.Add(new OrderDetailObject
                    {
                        OrderId = dataReader.GetInt32(0),
                        ProductId = dataReader.GetInt32(1),
                        UnitPrice = dataReader.GetDecimal(2),
                        Quantity = dataReader.GetInt32(3),
                        Discount = dataReader.GetDouble(4),
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return orderDetails;
        }

        public OrderDetailObject GetOrderDetailByID(int orderID, int productID)
        {
            string SQLSelect = "SELECT OrderId, ProductId, UnitPrice, Quantity, Discount FROM OrderDetail WHERE OrderId = @OrderId AND ProductId = @ProductId";
            OrderDetailObject orderDetail = null;
            IDataReader dataReader = null;
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(DataProvider.CreateParameter("@OrderId", 4, orderID, DbType.Int32));
                parameters.Add(DataProvider.CreateParameter("@ProductId", 4, productID, DbType.Int32));
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, parameters.ToArray());
                if (dataReader.Read())
                {
                    orderDetail = new OrderDetailObject
                    {
                        OrderId = dataReader.GetInt32(0),
                        ProductId = dataReader.GetInt32(1),
                        UnitPrice = dataReader.GetDecimal(2),
                        Quantity = dataReader.GetInt32(3),
                        Discount = dataReader.GetDouble(4),
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return orderDetail;
        }

        public void Create(OrderDetailObject orderDetail)
        {
            try
            {
                OrderDetailObject orderDetailByID = GetOrderDetailByID(orderDetail.OrderId, orderDetail.ProductId);
                if (orderDetailByID == null)
                {
                    string SQLInsert = "INSERT OrderDetail VALUES(@OrderId, @ProductId, @UnitPrice, @Quantity, @Discount)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@OrderId", 4, orderDetail.OrderId, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@ProductId", 4, orderDetail.ProductId, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@UnitPrice", 50, orderDetail.UnitPrice, DbType.Decimal));
                    parameters.Add(DataProvider.CreateParameter("@Quantity", 4, orderDetail.Quantity, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@Discount", 50, orderDetail.Discount, DbType.Double));
                    DataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("This orderDetail has been already existed");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update(OrderDetailObject orderDetail)
        {
            try
            {
                OrderDetailObject orderDetailByID = GetOrderDetailByID(orderDetail.OrderId, orderDetail.ProductId);
                if (orderDetailByID != null)
                {
                    string SQLInsert = "UPDATE OrderDetail SET OrderId = @OrderId, ProductId = @ProductId, UnitPrice = @UnitPrice, Quantity = @Quantity, Discount = @Discount WHERE OrderId = @OrderId AND ProductId = @ProductId";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@OrderId", 4, orderDetail.OrderId, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@ProductId", 4, orderDetail.ProductId, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@UnitPrice", 50, orderDetail.UnitPrice, DbType.Decimal));
                    parameters.Add(DataProvider.CreateParameter("@Quantity", 4, orderDetail.Quantity, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@Discount", 50, orderDetail.Discount, DbType.Double));
                    DataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("Updating orderDetail has been error");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Remove(int orderID, int productID)
        {
            try
            {
                OrderDetailObject orderDetailByID = GetOrderDetailByID(orderID, productID);
                if (orderDetailByID != null)
                {
                    string SQLDelete = "DELETE OrderDetail WHERE OrderId = @OrderId AND ProductId = @ProductId";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@OrderId", 4, orderID, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@ProductId", 4, productID, DbType.Int32));
                    DataProvider.Update(SQLDelete, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("this orderDetail does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

        }

        public void DeleteOrderDetailsByOrderID(int orderID)
        {
            try
            {
                List<OrderDetailObject> orderDetails = GetOrderDetailsWithOrderId(orderID);
                if (orderDetails != null && orderDetails.Count() > 0)
                {
                    string SQLDelete = "DELETE OrderDetail WHERE OrderId = @OrderId";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@OrderId", 4, orderID, DbType.Int32));
                    DataProvider.Update(SQLDelete, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("this order does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
