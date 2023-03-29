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
    /// Логика взаимодействия для Page10.xaml
    /// </summary>
    public partial class Page10 : Page
    {
        Order1TableAdapter order = new Order1TableAdapter();
        User1TableAdapter user = new User1TableAdapter();
        public Page10()
        {
            InitializeComponent();
            zakazorder.ItemsSource = order.GetData();
            zakazchikid.ItemsSource = user.GetData();
            zakazchikid.DisplayMemberPath = "Name";
            zakazchikid.SelectedValuePath = "id";
            datasegodnya.Text = DateTime.Now.ToShortDateString();
            datasegodnya.IsEnabled = false;
        }
        private static readonly Regex regex = new Regex("^[-а-яА-Я]+$");
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            if (!regex.IsMatch(e.Text))
                e.Handled = true;
            base.OnPreviewTextInput(e);
        }
        private void dobav_Click(object sender, RoutedEventArgs e)
        {
            if (zakazchikid.Text != "")
            {
                int usid = (int)zakazchikid.SelectedValue;
                order.InsertQuery(usid, datasegodnya.Text);
                datasegodnya.Text = DateTime.Now.ToShortDateString();
                zakazorder.ItemsSource = order.GetData();
            }
            else
            {
                MessageBox.Show("Заполнены не все поля");
            }
        }

        private void obnov_Click(object sender, RoutedEventArgs e)
        {
            if (zakazchikid.Text != "")
            {
                if (zakazorder.SelectedItem != null)
                {
                    var item = zakazorder.SelectedItem as DataRowView;
                    order.UpdateQuery(Convert.ToInt32(zakazchikid), datasegodnya.Text, (int)item.Row[0]);
                    datasegodnya.Text = DateTime.Now.ToShortDateString();
                    zakazorder.ItemsSource = order.GetData();
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
            if (zakazorder.SelectedItem != null)
            {
                int id = (int)(zakazorder.SelectedItem as DataRowView).Row[0];
                order.DeleteQuery(id);
                datasegodnya.Text = DateTime.Now.ToShortDateString();
                zakazorder.ItemsSource = order.GetData();
            }
            else
            {
                MessageBox.Show("Строка не выбрана");
            }
        }

        private void zakazorder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (zakazorder.SelectedItem != null)
            {
                var item = zakazorder.SelectedItem as DataRowView;
                zakazchikid.SelectedValue = Convert.ToString(item.Row[1]);
                datasegodnya.Text = Convert.ToString(item.Row[2]);
            }
        }
    }
}
