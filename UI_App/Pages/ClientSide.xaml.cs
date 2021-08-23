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
    /// Interaction logic for ClientSide.xaml
    /// </summary>
    public partial class ClientSide : Page
    {
        IRentItemsService rentItems = new RentItemsService();
        public ClientSide()
        {
            InitializeComponent();
            LoadAllRentalItems();
        }
        private void LoadAllRentalItems()
        {
            dgRentalItems.ItemsSource = rentItems.GetAll().ToList();
        }

        private void btnNewRentalItems_Click(object sender, RoutedEventArgs e)
        {
            rentItems.Add(new RentalItems()
            {
                ECode = tbECode.Text,
                Descriprion = tbDescription.Text
            });
        }
    }
}
