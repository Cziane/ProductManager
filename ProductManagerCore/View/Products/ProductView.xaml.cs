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
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : Page
    {
        private List<Product> myProducts;
        public ProductView()
        {
            myProducts = new List<Product>();
            myProducts.Add(new Product("Sun Glasses", "Really cool sun glasses",99.9));
            myProducts.Add(new Product("Cool T-shirt", "Cool T-shirt with colors",19.9));
            InitializeComponent();
            InitializeList();
        }

        private void InitializeList()
        {
            foreach(Product prod in this.myProducts)
            {
                this.productList.Items.Add(prod);
            }
        }

        private void SelectProductChange(object sender, SelectionChangedEventArgs e)
        {
            if(!(productList.SelectedItem is null))
            {
                Product prod = this.productList.SelectedItem as Product;
                this.DisplayProduct(prod.title, prod.description, prod.Price);
            }
        }

        private void DisplayProduct(string title, string description, double price)
        {
            this.titleLabel.Text = title;
            this.DescriptionBlock.Text = description;
            this.priceLabel.Text = price.ToString()+"€";
        }

        private void EditProductClick(object sender, RoutedEventArgs e)
        {
            // set product to edit in the controller
            NavigationController.Instance.navigateTo("Products.edit");
        }

        private void DeleteProductClick(object sender, RoutedEventArgs e)
        {
            //Managed With Controller

        }

        private void AddProductClick(object sender, RoutedEventArgs e)
        {
            NavigationController.Instance.navigateTo("Products.edit");
        }
    }
}
