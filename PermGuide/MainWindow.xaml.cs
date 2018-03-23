using PermGuide.Classes;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
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
using PermGuide.Pages;

namespace PermGuide
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mManager = new DatabaseManager();

            try
            {
                mManager.Register("sunmax1234@mail.ru", "1234");
            }
            catch
            {

            }

            mUser = mManager.Login("sunmax1234@mail.ru", "1234");
        }

        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = (Button)sender;
                mPage = mPages[(string)button.Tag](mUser);
                ShowCurrentPage();
            }
            catch (AccessDeniedException)
            {

            }
            catch
            {
                throw new InvalidOperationException(
                    "Данная функция должна вызываться только от кнопок с установленным Tag."
                );
            }
        }

        private void ShowCurrentPage()
        {
            MainFrame.Navigate(mPage);
            MainFrame.NavigationService.RemoveBackEntry();
            // Width = MinWidth;
        }

        private static Dictionary<string, Func<User, Page>> mPages = 
            new Dictionary<string, Func<User, Page>>
        {
            { "profile", (u) => new ProfilePage(u) },
            { "map", (u) => new MapPage(u) },
            { "articles", (u) => new ArticlesPage(u) },
            { "timetables", (u) => new TimetablesPage(u) },
            { "privileges", (u) => new PrivilegesPage(u) },
            { "reviews", (u) => new ReviewsPage(u) },
        };

        private DatabaseManager mManager;
        private User mUser;
        private Page mPage;
    }
}