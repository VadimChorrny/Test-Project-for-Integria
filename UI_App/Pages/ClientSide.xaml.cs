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
        #region init
        IRentItemsService rentItems = new RentItemsService();
        IRentalItemPiecesService rentalItemPieces = new RentItemPiecesService();
        IOrderService orders = new OrderService();
        #endregion
        public ClientSide()
        {
            InitializeComponent();
            LoadDataGrid();
        }
        private void LoadDataGrid()
        {
            dgRentalItems.ItemsSource = rentItems.GetAll().ToList();
            dgRentalItemsPieces.ItemsSource = rentalItemPieces.GetAll().ToList();
            // new future :D
            txtCustomerName.Text = SystemParameters.PrimaryScreenWidth.ToString();
            txtCurrentTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnNewRentalItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                rentItems.Add(new RentalItems()
                {
                    ECode = tbECode.Text,
                    Descriprion = tbDescription.Text//,
                    //RentalItemPieces = new RentalItemPieces() { }
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnNewRentalItemPieces_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                rentalItemPieces.Add(new RentalItemPieces() { 
                    Barcode = tbBarCode.Text,
                    SerialNumber = tbSerialNumber.Text,
                    RentalItems = rentItems.GetAll().ToList()
                });;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnRemovePieces_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in dgRentalItemsPieces.SelectedItems)
            {
                RentalItemPieces rent = item as RentalItemPieces;
                rentalItemPieces.Remove((RentalItemPieces)item);
            }
        }

        private void btnRemoveItems_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in dgRentalItems.SelectedItems)
            {
                RentalItems rent = item as RentalItems;
                rentItems.Remove((RentalItems)item);
            }
        }
    }
}
