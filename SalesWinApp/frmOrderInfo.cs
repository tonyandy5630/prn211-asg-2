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
    public partial class frmOrderInfo : Form
    {
        public IOrderRepository OrderRepository { get; set; }
        public IOrderDetailRepository OrderDetailRepository { get; set; }

        BindingSource source;
        public OrderObject OrderInfo { get; set; }

        public List<string> ListMemberID { get; set; }

        public List<ProductObject> ListProduct { get; set; }

        public List<OrderDetailObject> ListOrderDetail { get; set; }
        public bool InsertOrUpdate { get; set; }
        public frmOrderInfo()
        {
            InitializeComponent();
        }

        private void frmOrderInfo_Load(object sender, EventArgs e)
        {
            source = new BindingSource();
            source.DataSource = ListOrderDetail;
            txtOrderID.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                cbMemberID.Text = OrderInfo.MemberId.ToString();
                txtOrderID.Text = OrderInfo.OrderId.ToString();
                txtFreight.Text = OrderInfo.Freight.ToString();
                dtOrderDate.Value = OrderInfo.OrderDate;
                dtRequiredDate.Value = OrderInfo.RequiredDate;
                dtShippedDate.Value = OrderInfo.ShippedDate;
            }
            else
            {
                ListMemberID.ForEach(memberID => cbMemberID.Items.Add(memberID));
                cbMemberID.DropDownStyle = ComboBoxStyle.DropDownList;
                cbMemberID.SelectedIndex = 0;
            }
            dataGridOrderInfo.DataSource = null;
            dataGridOrderInfo.DataSource = source;

            if (ListOrderDetail.Count == 0)
            {
                btnDeleteOrderInfo.Enabled = false;
            }
            else
            {
                btnDeleteOrderInfo.Enabled = true;
            }
            dataGridOrderInfo.CellDoubleClick += DvgOrderDetail_CellDoubleClick;
        }
        public void UpdateOrderDetails()
        {
            source = new BindingSource();
            source.DataSource = OrderDetailRepository.GetOrdersByOrderID(int.Parse(txtOrderID.Text)).ToList<OrderDetailObject>();

            dataGridOrderInfo.DataSource = null;
            dataGridOrderInfo.DataSource = source;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OrderObject order = new OrderObject()
                {
                    OrderId = int.Parse(txtOrderID.Text.Trim()),
                    MemberId = int.Parse(cbMemberID.SelectedItem != null ? cbMemberID.SelectedItem.ToString() : cbMemberID.Text),
                    OrderDate = dtOrderDate.Value,
                    RequiredDate = dtRequiredDate.Value,
                    ShippedDate = dtShippedDate.Value,
                    Freight = decimal.Parse(txtFreight.Text.Trim()),
                };
                if (InsertOrUpdate == false)
                {
                    if(txtOrderID.Text.Trim().Length != 0 && txtFreight.Text.Trim().Length != 0)
                    {
                        OrderRepository.InsertOrder(order);
                        MessageBox.Show("Add new order successfully");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("One of field is empty, please fill all the field");
                    }
                }
                else
                {
                    if (txtFreight.Text.Trim().Length != 0)
                    {
                        OrderRepository.UpdateOrder(order);
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
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Adding order failed" : "Updating order failed");
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnAddOrderInfo_Click(object sender, EventArgs e)
        {
            try
            {
                frmOrderDetailInfo frmOrderDetailInfo = new frmOrderDetailInfo()
                {
                    InsertOrUpdate = false,
                    OrderID = int.Parse(txtOrderID.Text),
                    ListProduct = ListProduct,
                    OrderDetailRepository = OrderDetailRepository,
                };
                if (frmOrderDetailInfo.ShowDialog() == DialogResult.OK)
                {
                    UpdateOrderDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Order must be existed first then adding order detail");
            }
        }
        private void DvgOrderDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                frmOrderDetailInfo frmOrderDetailInfo = new frmOrderDetailInfo()
                {
                    Text = "Update Product",
                    OrderID = int.Parse(txtOrderID.Text),
                    InsertOrUpdate = true,
                    ProductID = int.Parse(dataGridOrderInfo.CurrentRow.Cells["ProductId"].Value.ToString()),
                    Quantity = int.Parse(dataGridOrderInfo.CurrentRow.Cells["Quantity"].Value.ToString()),
                    Discount = double.Parse(dataGridOrderInfo.CurrentRow.Cells["Discount"].Value.ToString()),
                    OrderDetailRepository = OrderDetailRepository,
                    ListProduct = ListProduct
                };
                if (frmOrderDetailInfo.ShowDialog() == DialogResult.OK)
                {
                    UpdateOrderDetails();
                    source.Position = source.Count - 1;
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Something went wrong");
            }
        }

        private void btnDeleteOrderInfo_Click(object sender, EventArgs e)
        {
            try
            {
                int ProductID = int.Parse(dataGridOrderInfo.CurrentRow.Cells["ProductId"].Value.ToString());
                OrderDetailRepository.DeleteOrderDetail(OrderInfo.OrderId, ProductID);
                MessageBox.Show("Delete order detail successfully");
                UpdateOrderDetails();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Deleting orderDetail failed");
            }
        }
    }
}
