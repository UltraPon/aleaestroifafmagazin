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
using static System.Net.Mime.MediaTypeNames;

namespace stroimagazin1111
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        RegistrationTableAdapter registration = new RegistrationTableAdapter();
        User1TableAdapter user1 = new User1TableAdapter();
        Role1TableAdapter role1 = new Role1TableAdapter();
        public Page3()
        {
            InitializeComponent();
            registr.ItemsSource = registration.GetData();
            username.ItemsSource = user1.GetData();
            userrole.ItemsSource = role1.GetData();
            username.DisplayMemberPath = "Name";
            username.SelectedValuePath = "id";
            userrole.DisplayMemberPath = "Name";
            userrole.SelectedValuePath = "id";
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
            if (login1.Text != "" & pass1.Text != "" & username.Text != "" & userrole.Text != "")
            {
                int usid = (int)username.SelectedValue;
                int usrol = (int)userrole.SelectedValue;
                registration.InsertQuery(login1.Text, pass1.Text, usid, usrol);
                registr.ItemsSource = registration.GetData();
            }
            else
            {
                MessageBox.Show("Заполнены не все поля");
            }
        }
        private void obnov_Click(object sender, RoutedEventArgs e)
        {
            if (login1.Text != "" & pass1.Text != "" & username.Text != "" & userrole.Text != "")
            {
                if (registr.SelectedItem != null)
                {
                    var item = registr.SelectedItem as DataRowView;
                    registration.UpdateQuery(login1.Text, pass1.Text, (int)username.SelectedValue, (int)userrole.SelectedValue, (int)item.Row[0]);
                    registr.ItemsSource = registration.GetData();
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
            if (registr.SelectedItem != null)
            {
                int id = (int)(registr.SelectedItem as DataRowView).Row[0];
                registration.DeleteQuery(id);
                registr.ItemsSource = registration.GetData();
            }
            else
            {
                MessageBox.Show("Строка не выбрана");
            }
        }

        private void registr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (registr.SelectedItem != null)
            {
                var item = registr.SelectedItem as DataRowView;
                login1.Text = Convert.ToString(item.Row[1]);
                pass1.Text = Convert.ToString(item.Row[2]);
                username.SelectedValue = (item.Row[3]);
                userrole.SelectedValue = (item.Row[4]);
            }
        }
    }
}
