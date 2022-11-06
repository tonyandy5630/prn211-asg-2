using BusinessObject;
using DataAccess.Repository;
using Microsoft.Extensions.Configuration;
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
    public partial class frmLogin : Form
    {
        public IMemberRepository MemberRepository = new MemberRepository();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var adminDefaultSettings = Program.Configuration.GetSection("AdminAccount").Get<MemberObject>();
            var adminEmail = adminDefaultSettings.Email;
            var adminPassword = adminDefaultSettings.Password;
            var email = txtEmail.Text;
            var password = txtPassword.Text;

            if (String.IsNullOrEmpty(email))
            {
                MessageBox.Show("Your is email is empty", "wrong Information and try again!");
 
            }
            else if (String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Your is password is empty", "wrong Information and try again!");
            }
            else
            {
                try
                {
                    if (email.Equals(adminEmail) && password.Equals(adminPassword))
                    {
                        frmMain frmMain = new frmMain();
                        this.Hide();
                        frmMain.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MemberObject accountInfo = MemberRepository.Login(email, password);
                        if (accountInfo == null)
                        {
                            MessageBox.Show("Email or password is incorrect", "wrong Information and try again!");
                        }
                        else
                        {
                            frmMemberInfo frmMemberInfo = new frmMemberInfo()
                            {
                                Text = "Update Profile",
                                InsertOrUpdate = true,
                                UserProfile = accountInfo,
                                MemberRepository = MemberRepository
                            };
                            this.Hide();
                            frmMemberInfo.ShowDialog();
                            this.Show();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Something went wrong");
                }
            }
        }

    }
}
