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

namespace stroimagazin1111
{
    /// <summary>
    /// Логика взаимодействия для Page11.xaml
    /// </summary>
    public partial class Page11 : Page
    {
        ChequeTableAdapter cheque = new ChequeTableAdapter();
        Order1TableAdapter order1 = new Order1TableAdapter();
        ProductsTableAdapter products = new ProductsTableAdapter();
        Service1TableAdapter service1 = new Service1TableAdapter();
        public Page11()
        {
            InitializeComponent();
            allcheque.ItemsSource = cheque.GetData();
            zakazid.ItemsSource = order1.GetData();
            tovarid.ItemsSource = products.GetData();
            uslugaid.ItemsSource = service1.GetData();
            zakazid.DisplayMemberPath = "id";
            zakazid.SelectedValuePath = "id";
            tovarid.DisplayMemberPath = "Name";
            tovarid.SelectedValuePath = "id";
            uslugaid.DisplayMemberPath = "Name";
            uslugaid.SelectedValuePath = "id";
        }
        private void net(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
                MessageBox.Show("В сумму нельзя вводить буквы и символы.");
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
            if (zakazid.Text != "" & tovarid.Text != "" & uslugaid.Text != "" & chequeprice.Text != "")
            {
                int idzakaza = (int)zakazid.SelectedValue;
                int idtovara = (int)tovarid.SelectedValue;
                int iduslugi = (int)uslugaid.SelectedValue;               
                cheque.InsertQuery(idzakaza, idtovara, iduslugi, Convert.ToInt32(chequeprice.Text));
                allcheque.ItemsSource = cheque.GetData();      
            }
            else
            {
                MessageBox.Show("Заполнены не все поля.");
            }
        }
        private void obnov_Click(object sender, RoutedEventArgs e)
        {
            if (allcheque.SelectedItem != null)
            {
                if (zakazid.Text != "" & tovarid.Text != "" & uslugaid.Text != "" & chequeprice.Text != "")
                {
                    var item = allcheque.SelectedItem as DataRowView;
                    cheque.UpdateQuery((int) zakazid.SelectedValue, (int)tovarid.SelectedValue, (int)uslugaid.SelectedValue, Convert.ToInt32(chequeprice.Text), (int)item.Row[0]);
                    allcheque.ItemsSource = cheque.GetData();
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
            if (allcheque.SelectedItems != null)
            {
                int id = (int)(allcheque.SelectedItem as DataRowView).Row[0];
                cheque.DeleteQuery(id);
                allcheque.ItemsSource = cheque.GetData();
            }
            else
            {
                MessageBox.Show("Строка не выбрана");
            }
        }

        private void cheque_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (allcheque.SelectedItem != null)
            {
                var item = allcheque.SelectedItem as DataRowView;
                zakazid.SelectedValue = Convert.ToString(item.Row[1]);
                tovarid.SelectedValue = Convert.ToString(item.Row[2]);
                uslugaid.SelectedValue = Convert.ToString(item.Row[3]);
                chequeprice.Text = Convert.ToString(item.Row[4]);
            }
        }
    }
}
