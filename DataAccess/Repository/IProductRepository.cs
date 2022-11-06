using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<ProductObject> GetProducts();

        ProductObject GetProductByID(int productID);

        void InsertProduct(ProductObject product);

        void UpdateProduct(ProductObject product);

        void DeleteProduct(int productID);
    }
}
