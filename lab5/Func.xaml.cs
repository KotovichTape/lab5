using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для Func.xaml
    /// </summary>
    public partial class Func : Window
    {
        DrugsTableAdapter Drugs = new DrugsTableAdapter();
        Type_of_packagingTableAdapter pack = new Type_of_packagingTableAdapter();
        Type_of_drugsTableAdapter drugs = new Type_of_drugsTableAdapter();
        CostTableAdapter cost = new CostTableAdapter();
        StorehouseTableAdapter sklad = new StorehouseTableAdapter();
        CompanyTableAdapter company = new CompanyTableAdapter();    
        public Func()
        {
            InitializeComponent();
            DrugsDataGrid.ItemsSource = Drugs.GetData();
            PackagingCbx.ItemsSource = pack.GetData();
            PackagingCbx.DisplayMemberPath = "name";
            PackagingCbx.SelectedValuePath = "id";
            TypeCbx.ItemsSource = drugs.GetData();
            TypeCbx.DisplayMemberPath = "name";
            TypeCbx.SelectedValuePath = "id";
            CostCbx.ItemsSource = cost.GetData();
            CostCbx.DisplayMemberPath = "name";
            CostCbx.SelectedValuePath = "id";
            StorehouseCbx.ItemsSource = sklad.GetData();
            StorehouseCbx.DisplayMemberPath = "name";
            StorehouseCbx.SelectedValuePath = "id";
            CompanyCbx.ItemsSource = company.GetData();
            CompanyCbx.DisplayMemberPath = "name";
            CompanyCbx.SelectedValuePath = "id";
           




            /* DrugsDataGrid.DisplayMemberPath = "id";
             DrugsDataGrid.DisplayMemberPath = "name";
             DrugsDataGrid.DisplayMemberPath = "cost";
             DrugsDataGrid.DisplayMemberPath = "packanging";
             DrugsDataGrid.DisplayMemberPath = "storehouse";
             DrugsDataGrid.DisplayMemberPath = "company";*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Drugs.InsertQuery(DrugsTbx.Text, Convert.ToInt32(CostCbx.SelectedValue), Convert.ToInt32(PackagingCbx.SelectedValue), Convert.ToInt32(TypeCbx.SelectedValue), Convert.ToInt32(StorehouseCbx.SelectedValue), Convert.ToInt32(CompanyCbx.SelectedValue));
            //DrugsDataGrid.ItemsSource = null;  
            DrugsDataGrid.ItemsSource = Drugs.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (DrugsDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите строку, которую хотите удалить");
                return;
            }
            else
            {
                object id = (DrugsDataGrid.SelectedItem as DataRowView).Row[0];
                Drugs.DeleteQuery(Convert.ToInt32(id));
                DrugsDataGrid.ItemsSource = Drugs.GetData();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Comp window = new Comp();
            window.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Sklad window = new Sklad();
            window.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Cost window = new Cost();
            window.ShowDialog();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Type window = new Type();
            window.ShowDialog();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Packing window = new Packing();
            window.ShowDialog();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (DrugsDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите строку, которую хотите изменить");
                return;
            }
            else
            {
                object id = (DrugsDataGrid.SelectedItem as DataRowView).Row[0];
                Drugs.UpdateQuery(DrugsTbx.Text, Convert.ToInt32(CostCbx.SelectedValue), Convert.ToInt32(PackagingCbx.SelectedValue), Convert.ToInt32(TypeCbx.SelectedValue), Convert.ToInt32(StorehouseCbx.SelectedValue), Convert.ToInt32(CompanyCbx.SelectedValue), Convert.ToInt32(id));
                //DrugsDataGrid.ItemsSource = null;  
                DrugsDataGrid.ItemsSource = Drugs.GetData();
            }
        }
    }
}
