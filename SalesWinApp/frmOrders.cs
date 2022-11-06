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
    public partial class frmOrders : Form
    {
        public IOrderRepository OrderRepository = new OrderRepository();
        public IOrderDetailRepository OrderDetailRepository = new OrderDetailRepository();
        public IMemberRepository MemberRepository = new MemberRepository();
        public IProductRepository ProductRepository = new ProductRepository();

        public List<string> userIDs;
        public List<ProductObject> products;

        BindingSource source;
        public frmOrders()
        {
            InitializeComponent();
        }
        private void frmOrders_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            GetProducts();
            GetUserIDs();
        }
        public void ClearText()
        {
            txtOrderID.Text = "";
            txtMemberID.Text = "";
            txtFreight.Text = "";
            dtOrderDate.Value = DateTime.Now;
            dtRequiredDate.Value = DateTime.Now;
            dtShippedDate.Value = DateTime.Now;
        }
        public void LoadOrders()
        {
            try
            {
                var orderList = OrderRepository.GetOrders();

                source = new BindingSource();
                source.DataSource = orderList;

                txtOrderID.DataBindings.Clear();
                txtMemberID.DataBindings.Clear();
                txtFreight.DataBindings.Clear();
                dtOrderDate.DataBindings.Clear();
                dtRequiredDate.DataBindings.Clear();
                dtShippedDate.DataBindings.Clear();

                txtOrderID.DataBindings.Add("Text", source, "OrderID");
                txtMemberID.DataBindings.Add("Text", source, "MemberID");
                txtFreight.DataBindings.Add("Text", source, "Freight");
                dtOrderDate.DataBindings.Add("Text", source, "OrderDate");
                dtRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                dtShippedDate.DataBindings.Add("Text", source, "ShippedDate");

                dataGridOrders.DataSource = null;
                dataGridOrders.DataSource = source;

                if (orderList.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading orders failed");
            }
        }
        public void GetUserIDs()
        {
            try
            {
                userIDs = MemberRepository.GetMemberIDs().ToList<string>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading userIds failed");
            }
        }
        public void GetProducts()
        {
            try
            {
                products = ProductRepository.GetProducts().ToList<ProductObject>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading products failed");
            }
        }
        public OrderObject GetOrder()
        {
            OrderObject order = null;
            try
            {
                order = new OrderObject()
                {
                    OrderId = int.Parse(txtOrderID.Text),
                    MemberId = int.Parse(txtMemberID.Text),
                    Freight = decimal.Parse(txtFreight.Text),
                    OrderDate = dtOrderDate.Value,
                    RequiredDate = dtRequiredDate.Value,
                    ShippedDate = dtShippedDate.Value,

                };
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Getting order information error");
            }
            return order;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadOrders();
            GetProducts();
            GetUserIDs();
            dataGridOrders.CellDoubleClick += DvgOrderList_CellDoubleClick;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmOrderInfo frmOrderInfo = new frmOrderInfo()
            {
                Text = "Create Order",
                InsertOrUpdate = false,
                ListOrderDetail = new List<OrderDetailObject>(),
                ListMemberID = userIDs,
                ListProduct = products,
                OrderDetailRepository = OrderDetailRepository,
                OrderRepository = OrderRepository,
            };
            if (frmOrderInfo.ShowDialog() == DialogResult.OK)
            {
                LoadOrders();
                source.Position = source.Count - 1;
            }
        }

        private void DvgOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmOrderInfo frmOrderInfo = new frmOrderInfo()
            {
                Text = "Update Order",
                InsertOrUpdate = true,
                ListMemberID = userIDs,
                ListProduct = products,
                OrderDetailRepository = OrderDetailRepository,
                OrderRepository = OrderRepository,
                ListOrderDetail = OrderDetailRepository.GetOrdersByOrderID(int.Parse(txtOrderID.Text)).ToList<OrderDetailObject>(),
                OrderInfo = GetOrder()
            };
            if (frmOrderInfo.ShowDialog() == DialogResult.OK)
            {
                LoadOrders();
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var order = GetOrder();
                List<OrderDetailObject> listDetail = OrderDetailRepository.GetOrdersByOrderID(order.OrderId).ToList<OrderDetailObject>();
                DialogResult isDeleted = MessageBox.Show("Do you really want to delete?", "Deleting", MessageBoxButtons.YesNo);
                if (isDeleted == DialogResult.Yes)
                {
                    if (listDetail.Count > 0)
                    {
                        OrderDetailRepository.DeleteListOrderDetail(order.OrderId);
                    }
                    OrderRepository.DeleteOrder(order.OrderId);
                    MessageBox.Show("Delete order successfully");
                    LoadOrders();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Deleting order failed");
            }
        }
    }
}
