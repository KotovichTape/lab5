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
using System.Windows.Shapes;
using lab5.AptekaDataSetTableAdapters;

namespace lab5
{
    /// <summary>
    /// Логика взаимодействия для Comp.xaml
    /// </summary>
    public partial class Comp : Window
    {
        CompanyTableAdapter company = new CompanyTableAdapter();  
        public Comp()
        {
            InitializeComponent();
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            company.InsertQuery(CompTbx.Text);
            //DrugsDataGrid.ItemsSource = null;  
            CompDataGrid.ItemsSource = company.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CompDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите строку, которую хотите удалить");
                return;
            }
            else
            {
                object id = (CompDataGrid.SelectedItem as DataRowView).Row[0];
                company.DeleteQuery(Convert.ToInt32(id));
                CompDataGrid.ItemsSource = company.GetData();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (CompDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите строку, которую хотите изменить");
                return;
            }
            else
            {
                object id = (CompDataGrid.SelectedItem as DataRowView).Row[0];
                company.UpdateQuery(CompTbx.Text, Convert.ToInt32(id));
                //DrugsDataGrid.ItemsSource = null;  
                CompDataGrid.ItemsSource = company.GetData();
            }
        }
    }
}
