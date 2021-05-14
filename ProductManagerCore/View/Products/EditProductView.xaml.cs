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

namespace ProductManagerCore.View.Products
{
    /// <summary>
    /// Interaction logic for EditProductView.xaml
    /// </summary>
    public partial class EditProductView : Page
    {
    
        public EditProductView()
        {
            InitializeComponent();
        }

        private void CancelProductClick(object sender, RoutedEventArgs e)
        {
            this.titleInput.Clear();
            this.priceInput.Clear();
            this.DescriptionInput.Clear();
            NavigationController.Instance.navigateTo("Products.view");

        }

        private void SaveProductClick(object sender, RoutedEventArgs e)
        {
            string title = this.titleInput.Text;
            string description = this.DescriptionInput.Text;
            double price = double.Parse(this.priceInput.Text);

            //Call the controller to call the model
            //ProductController.Instance.AddProduct(title, description, price);
            NavigationController.Instance.navigateTo("Products.view");
        }
    }
}
