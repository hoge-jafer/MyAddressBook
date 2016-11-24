using MyAddressBook.DataViewPage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyAddressBook.ViewPage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditPage : Page
    {
        public EditPage()
        {
            this.InitializeComponent();
        }

        private void HomeAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void ZoomAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ZoomPage));
        }

        private void ReportHackedAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ReportHackedPage));
        }

        private void AddContactButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddContactPage));
        }

        private void FixContactButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EditContactPage));
        }

        private void BolckContactButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BlockContactPage));
        }

        private void DelContactButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ContactPage));
        }
    }
}
