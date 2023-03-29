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
    /// Логика взаимодействия для Page7.xaml
    /// </summary>
    public partial class Page7 : Page
    {
        Product_typeTableAdapter productitip = new Product_typeTableAdapter();
        public Page7()
        {
            InitializeComponent();
            tiptovara.ItemsSource = productitip.GetData();
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
            if (tovartip.Text != "")
            {
                productitip.InsertQuery(tovartip.Text);
                tiptovara.ItemsSource = productitip.GetData();
            }
            else
            {
                MessageBox.Show("Заполнены не все поля.");
            }
        }
        private void obnov_Click(object sender, RoutedEventArgs e)
        {
            if (tovartip.Text != "")
            {
                if (tiptovara.SelectedItem != null)
                {
                    var item = tiptovara.SelectedItem as DataRowView;
                    productitip.UpdateQuery(tovartip.Text, (int)item.Row[0]);
                    tiptovara.ItemsSource = productitip.GetData();
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
            if (tiptovara.SelectedItem != null)
            {
                int id = (int)(tiptovara.SelectedItem as DataRowView).Row[0];
                productitip.DeleteQuery(id);
                tiptovara.ItemsSource = productitip.GetData();
            }
            else
            {
                MessageBox.Show("Строка не выбрана");
            }
        }
        private void tiptov_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tiptovara.SelectedItem != null)
            {
                var item = tiptovara.SelectedItem as DataRowView;
                tovartip.Text = Convert.ToString(item.Row[1]);
            }
        }
    }
}
