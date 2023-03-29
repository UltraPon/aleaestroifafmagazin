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
    /// Логика взаимодействия для Page8.xaml
    /// </summary>
    public partial class Page8 : Page
    {
        Provider1TableAdapter provider = new Provider1TableAdapter();
        public Page8()
        {
            InitializeComponent();
            postav.ItemsSource = provider.GetData();
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
            if (postavname.Text != "" & postavcity.Text != "")
            {
                provider.InsertQuery(postavname.Text, postavcity.Text);
                postav.ItemsSource = provider.GetData();
            }
            else 
            {
                MessageBox.Show("Заполнены не все поля.");
            }
        }
        private void obnov_Click(object sender, RoutedEventArgs e)
        {
            if (postavname.Text != "" & postavcity.Text != "")
            {
                if (postav.SelectedItem != null)
                {
                    var item = postav.SelectedItem as DataRowView;
                    provider.UpdateQuery(postavname.Text, postavcity.Text, (int)item.Row[0]);
                    postav.ItemsSource = provider.GetData();
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
            if (postav.SelectedItem != null)
            {
                int id = (int)(postav.SelectedItem as DataRowView).Row[0];
                provider.DeleteQuery(id);
                postav.ItemsSource = provider.GetData();
            }
            else
            {
                MessageBox.Show("Строка не выбрана");
            }
        }
        private void postav_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (postav.SelectedItem != null)
            {
                var item = postav.SelectedItem as DataRowView;
                postavname.Text = Convert.ToString(item.Row[1]);
                postavcity.Text = Convert.ToString(item.Row[2]);
            }
        }
    }
}