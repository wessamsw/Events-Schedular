﻿using System;
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

namespace UIKitTutorials
{
    /// <summary>
    /// Interaction logic for CustomerMain.xaml
    /// </summary>
    public partial class CustomerMain : Window
    {
        public CustomerMain()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void rdHome_Click(object sender, RoutedEventArgs e)
        {

            PagesNavigation.Navigate(new System.Uri("Pages/CustomerHome.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdSounds_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/CustomerServiceHistory.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/CustomerHome.xaml", UriKind.RelativeOrAbsolute));
        }

    }
}
