using ProductManagerCore.View.Customers;
using ProductManagerCore.View.Orders;
using ProductManagerCore.View.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace ProductManagerCore.View
{
    class NavigationController
    {
        private static NavigationController _instance;


        private Dictionary<string, Page> _pageCollection;

        public MainWindow Root
        {
            get;
            set;
        }

        public static NavigationController Instance
        {
            get
            {
                if(_instance is null)
                {
                    _instance = new NavigationController();
                }
                return _instance;
            }
        }
        private NavigationController()
        {
            this._pageCollection = new Dictionary<string, Page>();
            //main menu loading
            this._pageCollection.Add("Menu", new MainMenuView());
            //Products views Loading
            this._pageCollection.Add("Products.view", new ProductView());
            this._pageCollection.Add("Products.edit", new EditProductView());

            //Customers views Loading
            this._pageCollection.Add("Customers.view", new CustomerView());
            this._pageCollection.Add("Customers.edit", new EditCustomerView());

            //Orders views Loading
            this._pageCollection.Add("Orders.view", new OrdersView());
            this._pageCollection.Add("Orders.edit", new EditOrderView());
        }

        public Page getPage(string title)
        {
            return this._pageCollection[title];
        }

        public void navigateTo(string title)
        {
            this.Root.MainFrame.Navigate(this.getPage(title));
        }
    }
}
