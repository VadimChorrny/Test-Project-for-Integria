using BLL.Services;
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
    /// Interaction logic for OrderLines.xaml
    /// </summary>
    public partial class OrderLines : Page
    {
        IOrderLineService orderLine = new OrderLineService();
        public OrderLines()
        {
            InitializeComponent();
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            dgOrderLine.ItemsSource = orderLine.GetAll().ToList();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in dgOrderLine.SelectedItems)
            {
                OrderLines line = item as OrderLines;
                if (line != null)
                {
                    orderLine.Update((DAL.Entities.OrderLines)item);
                }
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in dgOrderLine.SelectedItems)
            {
                OrderLines rent = item as OrderLines;
                orderLine.Remove((DAL.Entities.OrderLines)item);
            }
        }
    }
}
