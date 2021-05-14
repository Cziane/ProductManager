using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductManagerCore.View.Orders
{
    /// <summary>
    /// Interaction logic for EditOrderView.xaml
    /// </summary>
    public partial class EditOrderView : Page
    {
        public EditOrderView()
        {
            InitializeComponent();
        }

        private void AttachCustomerBtnToOrder(object sender, RoutedEventArgs e)
        {
            //Controller
        }

        private void AddOrderLineToOrder(object sender, RoutedEventArgs e)
        {
            //Do in controller before
        }

        private void RemoveLineOrderBtnClick(object sender, RoutedEventArgs e)
        {
            if (!(this.OrderLines.SelectedItem is null))
            {
                //Do with controller
                this.OrderLines.Items.Remove(this.OrderLines.SelectedItem);
            }
        }

        private void SaveBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationController.Instance.navigateTo("Orders.view");
        }

        private void CancelBtnClick(object sender, RoutedEventArgs e)
        {
            this.QuantityInput.Clear();
            this.VatContent.Text = "";
            this.subtotalContent.Text = "";
            this.totalContent.Text = "";
            NavigationController.Instance.navigateTo("Orders.view");
        }
    }
}
