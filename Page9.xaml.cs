using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using Microsoft.Win32;
using stroimagazin1111.stroi_magazinDataSetTableAdapters;

namespace stroimagazin1111
{
    /// <summary>
    /// Логика взаимодействия для Page9.xaml
    /// </summary>
    public partial class Page9 : Page
    {
        ProductsTableAdapter prod1 = new ProductsTableAdapter();
        Provider1TableAdapter prov1 = new Provider1TableAdapter();
        Product_typeTableAdapter prodtype1 = new Product_typeTableAdapter();
        public Page9()
        {
            InitializeComponent();
            alltov.ItemsSource = prod1.GetData();
            tovartype.ItemsSource = prodtype1.GetData();
            postav1.ItemsSource = prov1.GetData();
            tovartype.DisplayMemberPath = "Name";
            tovartype.SelectedValuePath = "id";
            postav1.DisplayMemberPath = "Name";
            postav1.SelectedValuePath = "id";
        }
        private void net(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
                MessageBox.Show("В цену нельзя вводить буквы и символы.");
            }
        }
        private void net1(object sender, TextCompositionEventArgs e)
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
            if (tovarname.Text != "" & tovarprice.Text != "" & tovartype.Text != "" & postav1.Text != "")
            {
                int prodtypeid = (int)tovartype.SelectedValue;
                int prodid = (int)postav1.SelectedValue;
                prod1.InsertQuery(tovarname.Text, prodtypeid, Convert.ToInt32(tovarprice.Text), prodid);
                alltov.ItemsSource = prod1.GetData();           
            }
            else
            {
                MessageBox.Show("Заполнены не все поля.");
            }
        }
        private void obnov_Click(object sender, RoutedEventArgs e)
        {
            if (alltov.SelectedItem != null)
            {
                if (tovarname.Text != "" & tovarprice.Text != "" & tovartype.Text != "" & postav1.Text != "")
                {
                    var item = alltov.SelectedItem as DataRowView;
                    prod1.UpdateQuery(tovarname.Text, (int)tovartype.SelectedValue, Convert.ToInt32(tovarprice.Text), (int)postav1.SelectedValue, (int)item.Row[0]);
                    alltov.ItemsSource = prod1.GetData();
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
            if (alltov.SelectedItem != null)
            {
                int id = (int)(alltov.SelectedItem as DataRowView).Row[0];
                prod1.DeleteQuery(id);
                alltov.ItemsSource = prod1.GetData();
            }
            else
            {
                MessageBox.Show("Строка не выбрана");
            }
        }

        private void alltovar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (alltov.SelectedItem != null)
            {
                var item = alltov.SelectedItem as DataRowView;
                tovarname.Text = Convert.ToString(item.Row[1]);
                tovartype.SelectedValue = Convert.ToString(item.Row[2]);
                tovarprice.Text = Convert.ToString(item.Row[3]);
                postav1.SelectedValue = Convert.ToString(item.Row[4]);
            }
        }
    }
}
