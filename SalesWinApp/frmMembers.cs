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
    public partial class frmMembers : Form
    {
        public IMemberRepository MemberRepository = new MemberRepository();
        BindingSource source;
        public frmMembers()
        {
            InitializeComponent();
        }
        private void ClearText()
        {
            txtMemberID.Text = "";
            txtEmail.Text = "";
            txtPassWord.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
            txtCompany.Text = "";
        }
        private void frmMembers_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            dataGrid.CellDoubleClick += DvgUserList_CellDoubleClick;
        }
        public void LoadUsers()
        {
            var users = MemberRepository.GetMembers();
            try
            {
                source = new BindingSource();
                source.DataSource = users;

                txtMemberID.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtPassWord.DataBindings.Clear();
                txtCity.DataBindings.Clear();
                txtCountry.DataBindings.Clear();
                txtCompany.DataBindings.Clear();

                txtMemberID.DataBindings.Add("Text", source, "MemberID");
                txtEmail.DataBindings.Add("Text", source, "Email");
                txtPassWord.DataBindings.Add("Text", source, "Password");
                txtCity.DataBindings.Add("Text", source, "City");
                txtCountry.DataBindings.Add("Text", source, "Country");
                txtCompany.DataBindings.Add("Text", source, "CompanyName");

                dataGrid.DataSource = null;
                dataGrid.DataSource = source;

                if (users.Count() == 0)
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
                MessageBox.Show(ex.Message, "Loading users failed");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var user = GetUser();
                DialogResult isDeleted= MessageBox.Show("Do you really want to delete?", "Deleting", MessageBoxButtons.YesNo);
                if(isDeleted == DialogResult.Yes)
                {
                    MemberRepository.DeleteMember(user.MemberId);
                    MessageBox.Show("Delete user successfully");
                    LoadUsers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Deleting user failed");
            }

        }
        private MemberObject GetUser()
        {
            MemberObject user = null;
            try
            {
                user = new MemberObject
                {
                    MemberId = int.Parse(txtMemberID.Text),
                    Email = txtEmail.Text,
                    Password = txtPassWord.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    CompanyName = txtCompany.Text,
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Getting user Faied");
            }
            return user;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmMemberInfo memberInfo = new frmMemberInfo()
            {
                InsertOrUpdate = false,
                Text = "Create User",
                MemberRepository = MemberRepository,
            };
            if (memberInfo.ShowDialog() == DialogResult.Cancel)
            {
                LoadUsers();
                source.Position = source.Count - 1;
            }
        }
        private void DvgUserList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmMemberInfo memberInfo = new frmMemberInfo
            {
                Text = "Update User",
                InsertOrUpdate = true,
                UserProfile = GetUser(),
                MemberRepository = MemberRepository,
            };
            if (memberInfo.ShowDialog() == DialogResult.Cancel)
            {
                LoadUsers();
                source.Position = source.Count - 1;
            }
        }

        private void dataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex == 3 && e.Value != null)
            {
                e.Value = new string('*', e.Value.ToString().Length);
            }
        }
    }
}
