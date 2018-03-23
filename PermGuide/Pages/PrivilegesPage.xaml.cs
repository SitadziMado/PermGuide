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
    /// Логика взаимодействия для PrivilegesPage.xaml
    /// </summary>
    public partial class PrivilegesPage : Page
    {
        public PrivilegesPage(User user)
        {
            InitializeComponent();
            mUser = user;
        }

        private User mUser;
    }
}
