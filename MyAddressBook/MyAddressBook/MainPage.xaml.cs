using MyAddressBook.DataViewPage;
using MyAddressBook.ViewPage;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyAddressBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void EditAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EditPage));
        }

        private void ZoomAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ZoomPage));
        }

        private void ReportHackedAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ReportHackedPage));
        }

        private void FamilyCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MyContacterPage));
        }

        private void ClassmateCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MyContacterPage));
        }

        private void ColleagueCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MyContacterPage));
        }

        private void FriendCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MyContacterPage));
        }
    }
}
