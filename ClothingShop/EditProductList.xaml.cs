using ClothingShop.ClassHelper;
using ClothingShop.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace ClothingShop
{
    /// <summary>
    /// Логика взаимодействия для EditProductList.xaml
    /// </summary>
    public partial class EditProductList : Window
    {
        public EditProductList()
        {
            InitializeComponent();
        }
        public EditProductList(Product product)
        {
            InitializeComponent();

            // Заполнение комбобокса

            CmbCategory.ItemsSource = EFClass.Context.Type.ToList();
            CmbCategory.DisplayMemberPath = "Name";
            CmbCategory.SelectedIndex = 0;

            // заполнение полей значениями 
            TbName.Text = product.Name;
            TbPrice.Text = product.Price.ToString();
            CmbCategory.SelectedItem = EFClass.Context.Type.ToList().Where(i => i.IdType == product.IdType).FirstOrDefault();

            // вывод фото

            if (product.ProductImage != null)
            {
                using (MemoryStream ms = new MemoryStream(product.ProductImage))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = ms;
                    bitmapImage.EndInit();
                    ImgProduct.Source = bitmapImage;
                }
            }


            // Изменение заголовка и кнопки 

            TblockTitle.Text = "Изменение товара";
            BtnAddProduct.Content = "Изменить";

            // флаг на изменение
            isEdit = true;

            // выводим из контекста класса полученный продукт
            editProduct = product;
        }



        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgProduct.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                pathImageProduct = openFileDialog.FileName;
            }
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            // валидация 

            if (isEdit)
            {
                // редактирование

                editProduct.Name = TbName.Text;
                editProduct.Price = Convert.ToDecimal(TbPrice.Text);
                editProduct.IDCategory = (CmbCategory.SelectedItem as Category).IDCategory;
                if (pathImageProduct != null)
                {
                    editProduct.ProductImage = File.ReadAllBytes(pathImageProduct);
                }

                EFClass.Context.SaveChanges();

                MessageBox.Show("Товар успешно изменен");


            }
            else
            {
                // добавление
                Product product = new Product();
                product.Name = TbName.Text;
                product.Price = Convert.ToDecimal(TbPrice.Text);
                product.IdType = (CmbCategory.SelectedItem as Product).IdT;
                if (pathImageProduct != null)
                {
                    product.ProductImage = File.ReadAllBytes(pathImageProduct);
                }

                EFClass.Context.Product.Add(product);
                EFClass.Context.SaveChanges();

                MessageBox.Show("Товар добавлен");
            }


            this.Close();
        }
    }
}   