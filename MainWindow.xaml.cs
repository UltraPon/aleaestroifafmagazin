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
using MaterialDesignColors;
using stroimagazin1111.stroi_magazinDataSetTableAdapters;

namespace stroimagazin1111
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RegistrationTableAdapter adapter = new RegistrationTableAdapter();
        public MainWindow()
        {
            InitializeComponent();        
        }

        private void vhod_button_Click(object sender, RoutedEventArgs e)
        {
            var allreg = adapter.GetData().Rows;
            for (int i = 0; i < allreg.Count; i++)
            {
                if (allreg[i][1].ToString() == log1.Text && 
                    allreg[i][2].ToString() == par1.Password)
                {
                    int RoleId = (int)allreg[i][3];
                    switch(RoleId)
                    {
                        case 1:
                            first.Content = new Page1();
                            break;
                    }
                    log1.Visibility = Visibility.Hidden;
                    par1.Visibility = Visibility.Hidden;
                    avtor_text.Visibility = Visibility.Hidden;
                    vhod_button.Visibility = Visibility.Hidden;
                    break;
                }
                if (log1.Text != "" & par1.Password != "")
                {
                    {
                        MessageBox.Show("Неверно введён логин или пароль, повторите попытку.");
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Не все строки были заполнены");
                    break;
                }
            }
        }
    }
}
