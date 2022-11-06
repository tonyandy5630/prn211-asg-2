using BusinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public class ProductDAO : BaseDAL
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();

        private ProductDAO() { }

        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public List<ProductObject> GetProducts()
        {
            string SQLSelect = "SELECT ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitsInStock FROM Product";
            var products = new List<ProductObject>();
            IDataReader dataReader = null;
            try
            {
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    products.Add(new ProductObject
                    {
                        ProductId = dataReader.GetInt32(0),
                        CategoryId = dataReader.GetInt32(1),
                        ProductName = dataReader.GetString(2),
                        Weight = dataReader.GetString(3),
                        UnitPrice = dataReader.GetDecimal(4),
                        UnitslnStock = dataReader.GetInt32(5),
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
            return products;
        }

        public ProductObject GetProductWithID(int productID)
        {
            string SQLSelect = "SELECT ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitsInStock from Product WHERE ProductId = @ProductId";
            ProductObject product = null;
            IDataReader dataReader = null;
            try
            {
                var param = DataProvider.CreateParameter("@ProductId", 4, productID, DbType.Int32);
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    product = new ProductObject
                    {
                        ProductId = dataReader.GetInt32(0),
                        CategoryId = dataReader.GetInt32(1),
                        ProductName = dataReader.GetString(2),
                        Weight = dataReader.GetString(3),
                        UnitPrice = dataReader.GetDecimal(4),
                        UnitslnStock = dataReader.GetInt32(5),
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if(dataReader!= null)
                { 
                    dataReader.Close();
                }
                CloseConnection();
            }
            return product;
        }

        public void Create(ProductObject product)
        {
            try
            {
                ProductObject productByID = GetProductWithID(product.ProductId);
                if (productByID == null)
                {
                    string SQLInsert = "INSERT Product VALUES(@ProductId, @CategoryId, @ProductName, @Weight, @UnitPrice, @UnitsInStock)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@ProductId", 4, product.ProductId, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@CategoryId", 4, product.CategoryId, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@ProductName", 50, product.ProductName, DbType.String));
                    parameters.Add(DataProvider.CreateParameter("@Weight", 50, product.Weight, DbType.String));
                    parameters.Add(DataProvider.CreateParameter("@UnitPrice", 50, product.UnitPrice, DbType.Decimal));
                    parameters.Add(DataProvider.CreateParameter("@UnitsInStock", 4, product.UnitslnStock, DbType.Int32));
                    DataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("this product has already existd");
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

        public void Update(ProductObject product)
        {
            try
            {
                ProductObject productByID = GetProductWithID(product.ProductId);
                if (productByID != null)
                {
                    string SQLInsert = "UPDATE Product SET ProductId = @ProductId, CategoryId = @CategoryId, ProductName = @ProductName, Weight = @Weight, UnitPrice = @UnitPrice, UnitsInStock = @UnitsInStock WHERE ProductId = @ProductId";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@ProductId", 4, product.ProductId, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@CategoryId", 4, product.CategoryId, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@ProductName", 40, product.ProductName, DbType.String));
                    parameters.Add(DataProvider.CreateParameter("@Weight", 20, product.Weight, DbType.String));
                    parameters.Add(DataProvider.CreateParameter("@UnitPrice", 50, product.UnitPrice, DbType.Decimal));
                    parameters.Add(DataProvider.CreateParameter("@UnitsInStock", 4, product.UnitslnStock, DbType.Int32));
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

        public void Delete(int productID)
        {
            try
            {
                ProductObject productByID = GetProductWithID(productID);
                if (productByID != null)
                {
                    string SQLDelete = "DELETE Product WHERE productID = @productID";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@productID", 4, productID, DbType.Int32));
                    DataProvider.Update(SQLDelete, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("This product does not exist");
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
