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
    public partial class frmOrderDetailInfo : Form
    {
        public IOrderDetailRepository OrderDetailRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public List<ProductObject> ListProduct { get; set; }
        public frmOrderDetailInfo()
        {
            InitializeComponent();
        }

        private void frmOrderDetailInfo_Load(object sender, EventArgs e)
        {
            if(InsertOrUpdate == true)
            {
                cbProductID.Text = ProductID.ToString();
                txtDiscount.Text = Discount.ToString();
                txtQuantity.Text = Quantity.ToString();
            }
            else
            {
                ListProduct.ForEach(product => cbProductID.Items.Add(product.ProductId));
                cbProductID.DropDownStyle = ComboBoxStyle.DropDownList;
                cbProductID.SelectedIndex = 0;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(InsertOrUpdate == false)
                {
                    var orderDetail = new OrderDetailObject()
                    {
                        OrderId = OrderID,
                        ProductId = ListProduct.ElementAt(cbProductID.SelectedIndex).ProductId,
                        Quantity = int.Parse(txtQuantity.Text),
                        Discount = double.Parse(txtDiscount.Text),
                        UnitPrice = ListProduct.ElementAt(cbProductID.SelectedIndex).UnitPrice,
                    };
                    OrderDetailRepository.InsertOrderDetail(orderDetail);
                    MessageBox.Show("Add new order detail successfully");
                    Close();
                }
                else
                {
                    int index = ListProduct.FindIndex(product => product.ProductId == int.Parse(cbProductID.Text));
                    var orderDetail = new OrderDetailObject()
                    {
                        OrderId = OrderID,
                        ProductId = ListProduct.ElementAt(index).ProductId,
                        Quantity = int.Parse(txtQuantity.Text),
                        Discount = double.Parse(txtDiscount.Text),
                        UnitPrice = ListProduct.ElementAt(index).UnitPrice,
                    };
                    OrderDetailRepository.UpdateOrderDetail(orderDetail);
                    MessageBox.Show("Update order detail successfully");
                    Close();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Adding orderDetail failed" : "Updating orderDetail failed");
                Close();
            }
        }
    }
}
