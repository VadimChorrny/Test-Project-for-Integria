using BLL.Services;
using DAL.Entities;
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

namespace UI_App.Pages
{
    /// <summary>
    /// Interaction logic for OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        IOrderService orders = new OrderService();
        public OrdersPage()
        {
            InitializeComponent();
        }

        private void ClearInput()
        {
            tbCustomer.Text = null;
            tbOrderName.Text = null;
        }
        private void btnNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbCustomer.Text != null && tbOrderName.Text != null)
                {
                    orders.Add(new Orders()
                    { Customer = tbCustomer.Text, OrderName = tbOrderName.Text });
                    ClearInput();
                }
                else
                {
                    throw new NullReferenceException("Sorry, you don't enter Customer Name" +
                        "Or Order Name");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
