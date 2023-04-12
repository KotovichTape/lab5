using lab5.AptekaDataSetTableAdapters;
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
    /// Логика взаимодействия для Cost.xaml
    /// </summary>
    public partial class Cost : Window
    {
        CostTableAdapter stoimost = new CostTableAdapter();
        public Cost()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //stoimost.InsertQuery(CostTbx.Text);
            //DrugsDataGrid.ItemsSource = null;  
            CostDataGrid.ItemsSource = stoimost.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CostDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите строку, которую хотите удалить");
                return;
            }
            else
            {
                object id = (CostDataGrid.SelectedItem as DataRowView).Row[0];
                stoimost.DeleteQuery(Convert.ToInt32(id));
                CostDataGrid.ItemsSource = stoimost.GetData();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            /*if (CostDataGrid.SelectedItem == null)
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
            }*/
        }
    }
}
