using PermGuide.Classes;
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

namespace PermGuide.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        MainWindow mParent;

        public RegisterPage(MainWindow parent)
        {
            InitializeComponent();
            mParent = parent;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mParent.mUser = mParent.mManager.Login(
                    LoginTextBox.Text,
                    Password.Password
                );
            }
            catch (UserNotRegisteredException)
            {
                Password.Clear();
                // MessageBox
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mParent.mUser = mParent.mManager.Register(
                    LoginTextBox.Text,
                    Password.Password, 
                    NicknameTextBox.Text
                );
            }
            catch (UserNotRegisteredException)
            {
                LoginTextBox.Clear();
                // MessageBox
            }
        }
    }
}
