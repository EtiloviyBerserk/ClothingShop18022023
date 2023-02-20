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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClothingShop.ClassHelper;
using ClothingShop.DB;

namespace ClothingShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CmbGender.ItemsSource=EFClass.Context.Gender.ToList();
            CmbGender.DisplayMemberPath = "Name";
            CmbGender.SelectedIndex = 0;
            CmbRole.ItemsSource = EFClass.Context.Role.ToList();
            CmbRole.DisplayMemberPath = "Name";
            CmbRole.SelectedIndex = 0;
        }
        private void BtnAdduser_Click(object sender, RoutedEventArgs e)
        {
            // валидация
            if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                MessageBox.Show("Логин не может быть пустым");
                return;
            }

            // добавление новой записи 
            EFClass.Context.User.Add(new User()
            {
                Login = TbLogin.Text,
                Password = PbPassword.Password,
                LastName = TbLName.Text,
                FirstName = TbFName.Text,
                Mail = TbEmail.Text,
                IdRole = (CmbRole.SelectedItem as Role).idRole,
                Phone = TbPhone.Text,
                Birthday = DPDateOfBirth.SelectedDate.Value,
                IdGender = (CmbGender.SelectedItem as Gender).IdGender,
            });


            // сохранение изменений
            EFClass.Context.SaveChanges();


            // оповещение об успехе
            MessageBox.Show("Ok");


        }

        private void CmbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
