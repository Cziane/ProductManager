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

namespace ProductManagerCore.View
{
    /// <summary>
    /// Interaction logic for MainMenuView.xaml
    /// </summary>
    public partial class MainMenuView : Page
    {
        public MainMenuView()
        {
            InitializeComponent();
        }

        private void NavigateBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement target = sender as FrameworkElement;
            if (target.Name == "NavigateProductBtn")
            {
                NavigationController.Instance.navigateTo("Products.view");
            }
            else if(target.Name == "NavigateCustomerBtn")
            {
                NavigationController.Instance.navigateTo("Customers.view");
            }
            else if (target.Name == "NavigateOrdersBtn")
            {
                NavigationController.Instance.navigateTo("Orders.view");
            }
            else
            {
                System.Environment.Exit(0);
            }
            
        }
    }
}
