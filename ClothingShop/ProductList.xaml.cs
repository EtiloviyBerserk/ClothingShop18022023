using ClothingShop.ClassHelper;
using ClothingShop.DB;
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
using System.Windows.Shapes;

using ClothingShop.Properties;


//namespace ClothingShop
//{
//    /// <summary>
//    /// Логика взаимодействия для ProductList.xaml
//    /// </summary>
//    public partial class ProductList : Window
//    {
//        public ProductList()
//        {
//            InitializeComponent();
//            GetListProduct();
//        }
//        private void GetListProduct()
//        {
//            List<Product> products = new List<Product>();
//            products = EFClass.Context.Product.ToList();

//            LvProduct.ItemsSource = products;
//        }

//        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
//        {
//            // переход на окно добавления товара
//            EditProductList addEditProductWindow = new EditProductList();
//            addEditProductWindow.ShowDialog();

//            GetListProduct();
//        }

//        private void BtnMore_Click(object sender, RoutedEventArgs e)
//        {
//            Button button = sender as Button;
//            if (button == null)
//            {
//                return;
//            }

//            Product selectedProduct = button.DataContext as Product;

//            EditProductList addEditProductWindow = new EditProductListWin(selectedProduct);
//            addEditProductWindow.ShowDialog();

//            GetListProduct();

//        }
//    }
//}