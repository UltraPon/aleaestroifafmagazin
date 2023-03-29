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
    /// Логика взаимодействия для Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        User1TableAdapter user_table = new User1TableAdapter();
        public Page4()
        {
            InitializeComponent();
            users.ItemsSource = user_table.GetData();
        }

        private void probel(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
        private void net(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
                MessageBox.Show("В данном поле нельзя вводить цифры.");
            }
        }
        private void dobav_Click(object sender, RoutedEventArgs e)
        {
            if (imya.Text != "" & familiya.Text != "")
            {
                user_table.InsertQuery(familiya.Text, imya.Text);
                users.ItemsSource = user_table.GetData();             
            }
            else
            {
                MessageBox.Show("Заполнены не все поля.");
            }
        }
        private void obnov_Click(object sender, RoutedEventArgs e)
        {
            if (users.SelectedItem != null)
            {
                if (imya.Text != "" & familiya.Text != "")
                {
                    var item = users.SelectedItem as DataRowView;
                    user_table.UpdateQuery(familiya.Text, imya.Text, (int)item.Row[0]);
                    users.ItemsSource = user_table.GetData();
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
            if (users.SelectedItem != null)
            {
                int id = (int)(users.SelectedItem as DataRowView).Row[0];
                user_table.DeleteQuery(id);
                users.ItemsSource = user_table.GetData();
            }
            else
            {
                MessageBox.Show("Строка не выбрана");
            }
        }

        private void users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (users.SelectedItem != null)
            {
                var item = users.SelectedItem as DataRowView;
                familiya.Text = Convert.ToString(item.Row[1]);
                imya.Text = Convert.ToString(item.Row[2]);
            }
        }

    }
}
