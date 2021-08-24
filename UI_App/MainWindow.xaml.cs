using System;
using System.Collections.Generic;
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
using UI_App.Pages;

namespace UI_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OrdersPage ordersPage = new OrdersPage();
        ClientSide clientSide = new ClientSide();
        OrderLines orderLines = new OrderLines();
        public MainWindow()
        {
            InitializeComponent();
            LoadSignInPage();
        }

        private void LoadSignInPage()
        {
            Main.Content = ordersPage;
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = clientSide;
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = orderLines;
        }
    }
}
