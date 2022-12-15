using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.Models;

namespace WPF.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TestWPFContext context = new TestWPFContext();
        
        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
           string email = txtEmail.Text.Trim();
           string password = txtPassword.Password.Trim();
            if (!AllowLogin())
                return;
            if(email == txtEmail.Text && password != txtPassword.Password)
            {
                MessageBox.Show("password fail!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtEmail.Focus();
            }
            if (email != txtEmail.Text && password == txtPassword.Password)
            {
                MessageBox.Show("Email fail!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtPassword.Focus();
            }
            if (email == txtEmail.Text && password == txtPassword.Password)
            {
                MessageBox.Show("Logn success", "Successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                Menu m = new Menu();
                m.Show();
                this.Close();
            }

        }
        private bool AllowLogin()
        {
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Email not emty!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtEmail.Focus();
                return false;
            }
            if (txtPassword.Password.Trim() == "")
            {
                MessageBox.Show("Password not emty!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

        }
    }   
}
