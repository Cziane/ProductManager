using ProductManager.Model;
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
    /// Interaction logic for OrdersView.xaml
    /// </summary>
    public partial class OrdersView : Page
    {
        public OrdersView()
        {
            InitializeComponent();
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            //
            NavigationController.Instance.navigateTo("Orders.edit");
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            //Code it with wontroller
        }

        private void CreateBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationController.Instance.navigateTo("Orders.edit");
        }

        private void OrderSelect(object sender, SelectionChangedEventArgs e)
        {
            if(!(this.OrderList.SelectedItem is null))
            {
                Order ord = this.OrderList.SelectedItem as Order;
                this.orderLineList.Items.Clear();
                this.OrderId.Text ="#" + ord.ID;
                foreach(LineOrder line in ord.LineOrders)
                {
                    this.OrderList.Items.Add(line);
                }
                this.subTotalContent.Text = ord.subTotal().ToString();
                this.VatContent.Text = ord.getVat().ToString();
                this.Total.Text = ord.getTotal().ToString();
            }
        }
    }
}
