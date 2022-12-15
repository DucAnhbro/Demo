using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF.Logic;
using WPF.Models;

namespace WPF.View
{
    /// <summary>
    /// Interaction logic for Students.xaml
    /// </summary>
    public partial class Students : Window
    {
        TestWPFContext context = new TestWPFContext();
       // StudentQuery studentQuery= new StudentQuery();
        public static DataGrid dataGrid;
        public Students()
        {
            InitializeComponent();
            Load_data();
        }

        public void Load_data()
        {
            var students = context.Students.ToList();
            dataTable.ItemsSource = students;
            dataGrid = dataTable;
        }

        private void ResetData()
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtAddress.Text = string.Empty; 
            txtDob.DataContext= DateTime.Now;
        }

        private Student GetStudentExceptId()
        {
            Student s = new Student();
            s.Name = txtName.Text.Trim();
            s.Age = Convert.ToInt32(txtAge.Text.Trim());
            s.Dob = DateTime.Today.AddDays(Convert.ToInt32(txtDob.Text.Trim()));
            s.Adress = txtAddress.Text.Trim();
            return s;
        }
         private void Add_Click(object sender, RoutedEventArgs e)                                                                                                          
        {
            try
            {
                Student st = new Student();
                var date = txtDob.SelectedDate.Value.Date;
                st.Name = txtName.Text.Trim();
                st.Age = Convert.ToInt32(txtAge.Text.Trim());
                st.Dob = date;
                st.Adress = txtAddress.Text.Trim();
                context.Students.Add(st);
                context.SaveChanges();
                Load_data();
                ResetData();
                MessageBox.Show("Add successfull");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("co du lieu khong dung format.");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {  
            if (MessageBox.Show("Do you want to Delete Data?","Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                int idTest = 0;
                if(Int32.TryParse(txtID.Text, out idTest))
                {
                    var result = context.Students.FirstOrDefault(x => x.Id == idTest);
                    if(result!= null)
                    {
                        context.Students.Remove(result);
                        context.SaveChanges();
                        Load_data();
                        ResetData();
                    }
                    else
                    {
                        throw new Exception("Id not exit");
                    }
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            int idTest = 0;
            if (Int32.TryParse(txtID.Text, out idTest))
            {
                if(idTest != 0)
                {
                    var result = context.Students.FirstOrDefault(x => x.Id == idTest);
                    result.Name = txtName.Text.Trim();
                    var date = txtDob.SelectedDate.Value.Date;
                    result.Age = Convert.ToInt32(txtAge.Text.Trim());
                    result.Dob = date;
                    result.Adress = txtAddress.Text.Trim();
                    context.SaveChanges();
                    Load_data();
                    ResetData();
                    MessageBox.Show("Update successfull");
                }
                else
                {
                    throw new Exception("Id not exit");
                }
            }
            
        }

        private void dataTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
