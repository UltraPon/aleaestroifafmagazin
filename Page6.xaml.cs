using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using stroimagazin1111.stroi_magazinDataSetTableAdapters;
using System.Text.RegularExpressions;

namespace stroimagazin1111
{
    /// <summary>
    /// Логика взаимодействия для Page6.xaml
    /// </summary>
    public partial class Page6 : Page
    {
        Service1TableAdapter service = new Service1TableAdapter();
        Service_typeTableAdapter tipservice = new Service_typeTableAdapter();
        public Page6()
        {
            InitializeComponent();
            uslugi.ItemsSource = service.GetData();
            tipuslugicombo.ItemsSource = tipservice.GetData();
            tipuslugicombo.DisplayMemberPath = "Name";
            tipuslugicombo.SelectedValuePath = "id";
        }
        private void net(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
                MessageBox.Show("В цену нельзя вводить буквы и символы.");
            }
        }
        private void probel(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
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

        private void dobav_Click(object sender, RoutedEventArgs e)
        {
            if (servicename.Text != "" & serviceprice.Text != "")
            {
                int servid = (int)tipuslugicombo.SelectedValue;
                service.InsertQuery(servicename.Text, Convert.ToInt32(serviceprice.Text), servid);
                uslugi.ItemsSource = service.GetData();
            }
            else
            {
                MessageBox.Show("Заполнены не все поля");
            }
        }
        private void obnov_Click(object sender, RoutedEventArgs e)
        {
            if (servicename.Text != "" & serviceprice.Text != "")
            {
                if (uslugi.SelectedItem != null)
                {
                    var item = uslugi.SelectedItem as DataRowView;
                    service.UpdateQuery(servicename.Text, Convert.ToInt32(serviceprice.Text), (int)tipuslugicombo.SelectedValue, (int)item.Row[0]);
                    uslugi.ItemsSource = service.GetData();
                }
                else
                {
                    MessageBox.Show("Строка не выбрана");
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля");
            }
        }
        private void udali_Click(object sender, RoutedEventArgs e)
        {
            if (uslugi.SelectedItem != null)
            {
                int id = (int)(uslugi.SelectedItem as DataRowView).Row[0];
                service.DeleteQuery(id);
                uslugi.ItemsSource = service.GetData();           
            }
            else
            {
                MessageBox.Show("Строка не выбрана");
            }
        }
        private void uslugi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (uslugi.SelectedItem != null)
            {
            var item = uslugi.SelectedItem as DataRowView;
            servicename.Text = Convert.ToString(item.Row[1]);
            serviceprice.Text = Convert.ToString(item.Row[2]);
            tipuslugicombo.SelectedValue = (item.Row[3]);
            }
        }

    }
}
