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
    /// Логика взаимодействия для Packing.xaml
    /// </summary>
    public partial class Packing : Window
    {
        Type_of_packagingTableAdapter pack = new Type_of_packagingTableAdapter();
        public Packing()
        {
            InitializeComponent();
            PackDataGrid.ItemsSource = pack.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pack.InsertQuery(PackTbx.Text);
            //DrugsDataGrid.ItemsSource = null;  
            PackDataGrid.ItemsSource = pack.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (PackDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите строку, которую хотите удалить");
                return;
            }
            else
            {
                object id = (PackDataGrid.SelectedItem as DataRowView).Row[0];
                pack.DeleteQuery(Convert.ToInt32(id));
                PackDataGrid.ItemsSource = pack.GetData();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (PackDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите строку, которую хотите изменить");
                return;
            }
            else
            {
                object id = (PackDataGrid.SelectedItem as DataRowView).Row[0];
                pack.UpdateQuery(PackTbx.Text, Convert.ToInt32(id));
                //DrugsDataGrid.ItemsSource = null;  
                PackDataGrid.ItemsSource = pack.GetData();
            }
        }
    }
}
