using Microsoft.Maps.MapControl.WPF;
using PermGuide.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
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
    /// Логика взаимодействия для MapPage.xaml
    /// </summary>
    public partial class MapPage : Page
    {
        private User mUser;
        private bool mAdd = false;

        public MapPage(User user)
        {
            InitializeComponent();
            mUser = user;

            Task.Factory.StartNew(() =>
            {
                List<Sight> sights = new List<Sight>(mUser.GetSights());

                foreach (var sight in sights)
                {
                    Pushpin pin = new Pushpin
                    {
                        Location = new Location(
                            sight.Point.Latitude,
                            sight.Point.Longitude
                        )
                    };

                    GuideMap.Children.Add(pin);
                }
            });
        }

        private void GuideMap_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (mAdd)
                {
                    e.Handled = true;

                    Point mousePosition = e.GetPosition(this);
                    Location pinLocation = GuideMap.ViewportPointToLocation(mousePosition);

                    Pushpin pin = new Pushpin
                    {
                        Location = pinLocation
                    };

                    var sight = new Sight(mUser)
                        .SetLocation(mUser, pinLocation)
                        .SetAddress(mUser, AddressTextBox.Text)
                        .SetName(mUser, NameTextBox.Text);

                    mUser.Propose(sight).Commit();

                    GuideMap.Children.Add(pin);
                }
            }
            catch (AccessDeniedException)
            {
                // Обработать!!!
            }
            catch
            {
                throw;
            }
        }

        private void AddOption_Checked(object sender, RoutedEventArgs e)
        {
            mAdd = true;
        }

        private void ChooseOption_Checked(object sender, RoutedEventArgs e)
        {
            mAdd = false;
        }
    }
}
