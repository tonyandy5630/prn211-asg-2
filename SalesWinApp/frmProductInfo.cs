using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmProductInfo : Form
    {
        public IProductRepository ProductRepository { get; set; }

        public bool InsertOrUpdate { get; set; }

        public ProductObject ProductInfo { get; set; }
        public frmProductInfo()
        {
            InitializeComponent();
        }

        private void frmProductInfo_Load(object sender, EventArgs e)
        {
            txtProductID.Enabled = !InsertOrUpdate;

            if (InsertOrUpdate)
            {
                txtProductID.Text = ProductInfo.ProductId.ToString();
                txtProductName.Text = ProductInfo.ProductName;
                txtCategory.Text = ProductInfo.CategoryId.ToString();
                txtWeight.Text = ProductInfo.Weight;
                txtPrice.Text = ProductInfo.UnitPrice.ToString();
                txtUnitslnStock.Text = ProductInfo.UnitslnStock.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var product = new ProductObject()
                {
                    ProductId = int.Parse(txtProductID.Text.Trim()),
                    ProductName = txtProductName.Text.Trim(),
                    CategoryId = int.Parse(txtCategory.Text.Trim()),
                    Weight = txtWeight.Text.Trim(),
                    UnitPrice = decimal.Parse(txtPrice.Text.Trim()),
                    UnitslnStock = int.Parse(txtUnitslnStock.Text.Trim())
                };
                if (InsertOrUpdate == false)
                {
                    if(txtProductID.Text.Trim().Length != 0 && txtProductName.Text.Trim().Length != 0 && txtCategory.Text.Trim().Length != 0 && txtPrice.Text.Trim().Length != 0 && txtUnitslnStock.Text.Trim().Length != 0)
                    {
                        ProductRepository.InsertProduct(product);
                        MessageBox.Show("Add new product successfully");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("One of field is empty, please fill all the field");
                    }
                }
                else
                {
                    if (txtProductName.Text.Trim().Length != 0 && txtCategory.Text.Trim().Length != 0 && txtPrice.Text.Trim().Length != 0 && txtUnitslnStock.Text.Trim().Length != 0)
                    {
                        ProductRepository.UpdateProduct(product);
                        MessageBox.Show("Update product successfully");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("One of field is empty, please fill all the field");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Adding product failed" : "Updating product failed");
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void txtUnitslnStock_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
