using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SalesWinApp
{    
    public partial class frmMemberViewOrder : Form
    {
        public IOrderRepository OrderRepository = new OrderRepository();
        public IOrderDetailRepository OrderDetailRepository = new OrderDetailRepository();
        BindingSource source;
        BindingSource source2;
        public int MemberID { get; set; }
        public frmMemberViewOrder()
        {
            InitializeComponent();
        }

        private void frmMemberViewOrder_Load(object sender, EventArgs e)
        {
            try
            {
                List<OrderObject> orders = new List<OrderObject>();
                List<OrderDetailObject> orderDetails = new List<OrderDetailObject>();
                orders = OrderRepository.GetOrdersWithUserId(MemberID).ToList<OrderObject>();
                source = new BindingSource();
                source.DataSource = orders;
                dataGridOrder.DataSource = null;
                dataGridOrder.DataSource = source;
                orders.ForEach(order =>
                {
                    var listOrderDetailByOrderID = OrderDetailRepository.GetOrdersByOrderID(order.OrderId);
                    orderDetails.AddRange(listOrderDetailByOrderID);
                });
                source2 = new BindingSource();
                source2.DataSource = orderDetails;
                dataGridOrderDetail.DataSource = null;
                dataGridOrderDetail.DataSource = orderDetails;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Something went wrong");
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}
