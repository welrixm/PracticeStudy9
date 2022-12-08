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
using PracticeStudy.Components;

namespace PracticeStudy.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Login != null)
                LoginTb.Text = Properties.Settings.Default.Login;
            if (Properties.Settings.Default.Password != null)
                PasswordTb.Password = Properties.Settings.Default.Password;

        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Password.Trim();
            if (login.Length == 0 && password.Length == 0)
            {
                MessageBox.Show("Пусто! Пожалуйста заполните поля.");
            }
            else
            {
                Navigation.AuthUser = DBConnect.db.User.ToList().Find(x => x.Login == login && x.Password == password);
                if (Navigation.AuthUser == null)
                {
                    MessageBox.Show("Извините, такого пользователя не существует!");
                }
                else
                {
                    if (SaveCb.IsChecked == true)
                    {
                        Properties.Settings.Default.Login = LoginTb.Text;
                        Properties.Settings.Default.Password = PasswordTb.Password;
                        Properties.Settings.Default.Save();
                    }
                    Navigation.isAuth = true;
                    

                }
            }
            //if(LoginTb.Text != "123" && LoginTb.Enabled)
            //{
            //    K++;
            //    if(K > 3)
            //    {
            //        ed = DateTime.Now.AddSeconds((K + 1)60);

            //    }
            //}
            Navigation.NextPage(new Navig("", new ProductPage()));

        }
        //int K = 0;
        //DateTime ed;


        private void RegistBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new Navig("Регистрация", new RegistrationPage()));
            
        }
        //public class LoginTb : TextBox
        //{
        //    public int ErrorInputCount { get; set; }
        //}
        //private void LoginTb_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    var tb = sender as LoginTb; 
        //    if(tb.Text != "123")
        //    {
        //        tb.IsEnabled = false;
        //        tb.ErrorInputCount++;
        //        switch (tb.ErrorInputCount)
        //        {
        //            case 1:
        //                break;
        //            case 2:
        //                await Task.Delay(1000);
        //        break;;

        //        }
        //    }
        //}
    }

}
