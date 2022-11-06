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
    public class OrderDAO : BaseDAL
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();

        private OrderDAO() { }

        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public List<OrderObject> GetOrders()
        {
            string SQLSelect = "SELECT OrderId, MemberId, OrderDate, RequireDate, ShipperDate, Freight FROM [Order] ";
            var listOrder = new List<OrderObject>();
            IDataReader dataReader = null;
            try
            {
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    listOrder.Add(new OrderObject
                    {
                        OrderId = dataReader.GetInt32(0),
                        MemberId = dataReader.GetInt32(1),
                        OrderDate = dataReader.GetDateTime(2),
                        RequiredDate = dataReader.GetDateTime(3),
                        ShippedDate = dataReader.GetDateTime(4),
                        Freight = dataReader.GetDecimal(5),
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if(dataReader != null)
                {
                    dataReader.Close();
                }
                CloseConnection();
            }
            return listOrder;
        }

        public OrderObject GetOrderWithID(int orderID)
        {
            OrderObject order = null;
            IDataReader dataReader = null;
            string SQLSelect = "SELECT OrderId, MemberId, OrderDate, RequireDate, ShipperDate, Freight FROM [Order]  WHERE OrderId = @OrderId";
            try
            {
                var param = DataProvider.CreateParameter("@OrderId", 4, orderID, DbType.Int32);
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    order = new OrderObject
                    {
                        OrderId = dataReader.GetInt32(0),
                        MemberId = dataReader.GetInt32(1),
                        OrderDate = dataReader.GetDateTime(2),
                        RequiredDate = dataReader.GetDateTime(3),
                        ShippedDate = dataReader.GetDateTime(4),
                        Freight = dataReader.GetDecimal(5),
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
            return order;
        }
        public void Create(OrderObject order)
        {
            try
            {
                OrderObject orderWithID = GetOrderWithID(order.OrderId);
                if (orderWithID == null)
                {
                    string SQLInsert = "INSERT [Order] VALUES(@OrderId, @UserId, @OrderDate, @RequiredDate, @ShippedDate, @Freight)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@OrderId", 4, order.OrderId, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@UserId", 4, order.MemberId, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@OrderDate", 50, order.OrderDate, DbType.DateTime));
                    parameters.Add(DataProvider.CreateParameter("@RequiredDate", 50, order.RequiredDate, DbType.DateTime));
                    parameters.Add(DataProvider.CreateParameter("@ShippedDate", 50, order.ShippedDate, DbType.DateTime));
                    parameters.Add(DataProvider.CreateParameter("@Freight", 30, order.Freight, DbType.Decimal));
                    DataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("this order has already existed");
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

        public void Update(OrderObject order)
        {
            try
            {
                OrderObject orderWithID = GetOrderWithID(order.OrderId);
                if (orderWithID != null)
                {
                    string SQLInsert = "UPDATE [Order] SET OrderId = @OrderId, MemberId = @UserId, OrderDate = @OrderDate, RequiredDate = @RequiredDate, ShippedDate = @ShippedDate, Freight = @Freight WHERE OrderId = @OrderId";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@OrderId", 4, order.OrderId, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@UserId", 4, order.MemberId, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@OrderDate", 50, order.OrderDate, DbType.DateTime));
                    parameters.Add(DataProvider.CreateParameter("@RequiredDate", 50, order.RequiredDate, DbType.DateTime));
                    parameters.Add(DataProvider.CreateParameter("@ShippedDate", 50, order.ShippedDate, DbType.DateTime));
                    parameters.Add(DataProvider.CreateParameter("@Freight", 30, order.Freight, DbType.Decimal));
                    DataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("Updating product has been error");
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

        public void Delete(int orderID)
        {
            try
            {
                OrderObject orderWithID = GetOrderWithID(orderID);
                if (orderWithID != null)
                {
                    string SQLDelete = "DELETE [Order] WHERE OrderId = @OrderID";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@OrderID", 4, orderID, DbType.Int32));
                    DataProvider.Update(SQLDelete, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("This Order does not exist");
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
        public List<OrderObject> GetOrdersByUserID(int userID)
        {
            string SQLSelect = "SELECT OrderId, MemberId, OrderDate, RequiredDate, ShippedDate, Freight FROM [Order] WHERE MemberId = @UserId";
            List<OrderObject> orders = null;
            IDataReader dataReader = null;
            try
            {
                var param = DataProvider.CreateParameter("@UserId", 4, userID, DbType.Int32);
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                orders = new List<OrderObject>();
                while (dataReader.Read())
                {
                    orders.Add(new OrderObject
                    {
                        OrderId = dataReader.GetInt32(0),
                        MemberId = dataReader.GetInt32(1),
                        OrderDate = dataReader.GetDateTime(2),
                        RequiredDate = dataReader.GetDateTime(3),
                        ShippedDate = dataReader.GetDateTime(4),
                        Freight = dataReader.GetDecimal(5),
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
            return orders;
        }
    }
}
