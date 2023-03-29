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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        Role1TableAdapter roli = new Role1TableAdapter();
        public Page2()
        {
            InitializeComponent();
            role.ItemsSource = roli.GetData();
        }

        private void net(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
                MessageBox.Show("В название нельзя вводить цифры.");
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
            if (roleselect1.Text != "")
            {
                roli.InsertQuery(roleselect1.Text);
                role.ItemsSource = roli.GetData();
            }
            else
            {
                MessageBox.Show("Заполнены не все поля.");
            }
        }
        private void obnov_Click(object sender, RoutedEventArgs e)
        {
            if (roleselect1.Text != "")
            {
                if (role.SelectedItem != null)
                {
                    var item = role.SelectedItem as DataRowView;
                    roli.UpdateQuery(roleselect1.Text, (int)item.Row[0]);
                    role.ItemsSource = roli.GetData();
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
            if (role.SelectedItem != null)
            {
                int id = (int)(role.SelectedItem as DataRowView).Row[0];
                roli.DeleteQuery(id);
                role.ItemsSource = roli.GetData();
            }
            else
            {
                MessageBox.Show("Строка не выбрана");
            }
        }

        private void role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (role.SelectedItem != null)
            {
                var item = role.SelectedItem as DataRowView;
                roleselect1.Text = Convert.ToString(item.Row[1]);
            }
        }
    }
}