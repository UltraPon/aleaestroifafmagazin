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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }
        private void table_spisok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (table_spisok.SelectedIndex == 0)
            {
                PageFrame.Content = new Page2();
            }
            if (table_spisok.SelectedIndex == 1)
            {
                PageFrame.Content = new Page3();
            }
            if (table_spisok.SelectedIndex == 2)
            {
                PageFrame.Content = new Page4();
            }
            if (table_spisok.SelectedIndex == 3)
            {
                PageFrame.Content = new Page5();
            }
            if (table_spisok.SelectedIndex == 4)
            {
                PageFrame.Content = new Page6();
            }
            if (table_spisok.SelectedIndex == 5)
            {
                PageFrame.Content = new Page7();
            }
            if (table_spisok.SelectedIndex == 6)
            {
                PageFrame.Content = new Page8();
            }
            if (table_spisok.SelectedIndex == 7)
            {
                PageFrame.Content = new Page9();
            }
            if (table_spisok.SelectedIndex == 8)
            {
                PageFrame.Content = new Page10();
            }
            if (table_spisok.SelectedIndex == 9)
            {
                PageFrame.Content = new Page11();
            }
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            back_button.Visibility = Visibility.Hidden;
            table_spisok.Visibility = Visibility.Hidden;
            PageFrame2.Content = new Page12();
            
        }
    }
}