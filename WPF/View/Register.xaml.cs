using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF.Models;

namespace WPF.View
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }
        public bool checkAccountEmail(string ac)//check username va password
        {
            return Regex.IsMatch(ac, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }
        public bool checkAccountPassword(string ac)//check username va password
        {
            return Regex.IsMatch(ac, @"^[a-za-z0-9]$");
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            TestWPFContext context = new TestWPFContext();
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string pass = txtPassword.Password.Trim();
            if (checkAccountEmail(email))
            {
                MessageBox.Show("Email not vaild");
                return;
            }
            if (!checkAccountPassword(pass))
            {
                MessageBox.Show("password not valid");
                return;
            }

            Account a = new Account();
            a.Name = name;
            a.Email = email;
            a.Password = pass;
            context.Accounts.Add(a);
            context.SaveChanges();
            MessageBox.Show("register successful!");
            Close();
            MainWindow main = new MainWindow();
            main.ShowDialog();
        }
    }
}
