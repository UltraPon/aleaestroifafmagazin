using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using stroimagazin1111.stroi_magazinDataSetTableAdapters;

namespace stroimagazin1111
{
    /// <summary>
    /// Логика взаимодействия для Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        Service_typeTableAdapter servicetip11 = new Service_typeTableAdapter();
        public Page5()
        {
            InitializeComponent();
            tipservisa.ItemsSource = servicetip11.GetData();
        }

        private void net(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
                MessageBox.Show("В данном поле нельзя вводить цифры.");
            }
        }
        private void probel(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
        private void dobav_Click(object sender, RoutedEventArgs e)
        {
            if (servtip.Text != "")
            {
                servicetip11.InsertQuery(servtip.Text);
                tipservisa.ItemsSource = servicetip11.GetData();
            }
            else
            {
                MessageBox.Show("Заполнены не все поля.");
            }
        }
        private void obnov_Click(object sender, RoutedEventArgs e)
        {
            if (servtip.Text != "")
            {
                if (tipservisa.SelectedItem != null)
                {
                    var item = tipservisa.SelectedItem as DataRowView;
                    servicetip11.UpdateQuery(servtip.Text, (int)item.Row[0]);
                    tipservisa.ItemsSource = servicetip11.GetData();
                }
                else
                {
                    MessageBox.Show("Строка не выбрана");
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля.");
            }
        }
        private void udali_Click(object sender, RoutedEventArgs e)
        {
            if (tipservisa.SelectedItem != null)
            {
                int id = (int)(tipservisa.SelectedItem as DataRowView).Row[0];
                servicetip11.DeleteQuery(id);
                tipservisa.ItemsSource = servicetip11.GetData();
            }
            else
            {
                MessageBox.Show("Строка не выбрана");
            }
        }
        private void tipservisa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tipservisa.SelectedItem != null)
            {
                var item = tipservisa.SelectedItem as DataRowView;
                servtip.Text = Convert.ToString(item.Row[1]);
            }
        }
    }
}
