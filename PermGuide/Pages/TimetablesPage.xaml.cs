﻿using PermGuide.Classes;
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
    /// Логика взаимодействия для TimetablePage.xaml
    /// </summary>
    public partial class TimetablesPage : Page
    {
        public TimetablesPage(User user)
        {
            InitializeComponent();
            mUser = user;
        }

        private User mUser;
    }
}
