using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<ProductObject> GetProducts() => ProductDAO.Instance.GetProducts();

        public ProductObject GetProductByID(int productID) => ProductDAO.Instance.GetProductWithID(productID);

        public void InsertProduct(ProductObject product) => ProductDAO.Instance.Create(product);

        public void DeleteProduct(int productID) => ProductDAO.Instance.Delete(productID);

        public void UpdateProduct(ProductObject product) => ProductDAO.Instance.Update(product);
    }
}
