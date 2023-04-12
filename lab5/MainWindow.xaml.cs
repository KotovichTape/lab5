using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using lab5.AptekaDataSetTableAdapters;

namespace lab5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AutorisationTableAdapter autorisation = new AutorisationTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            AutorisationDataGrid.ItemsSource = autorisation.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var allLogins = autorisation.GetData().Rows;

            for (int i = 0; i < allLogins.Count; i++)
            {



                if (allLogins[i][2].ToString() == loginTbx.Text &&
                    allLogins[i][3].ToString() == passwordTbx.Password)
                {



                    string fio = (string)allLogins[i][2];

                    switch (fio)
                    {
                        case "Admin":

                            Func func = new Func();
                            func.Show();
                            break;
                        case "Guest":

                            vibor vibor = new vibor();
                            vibor.Show();
                            break;

                    }
                }
                
            }
           
            
            
            //Func window = new Func();
            //window.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vibor window = new vibor();
            window.ShowDialog();
        }
    }
}
