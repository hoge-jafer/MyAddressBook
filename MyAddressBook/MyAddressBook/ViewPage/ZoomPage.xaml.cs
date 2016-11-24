using MyAddressBook.Models;
using MyAddressBook.SQLiteHelperModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class ZoomPage : Page
    {
        ObservableCollection<MyContactData> mycontactdata = new ObservableCollection<MyContactData>();
        SQLiteHelper sqlitehelper = new SQLiteHelper();
        public ZoomPage()
        {
            this.InitializeComponent();
            this.Loaded += Page_Loaded;
        }

        private void HomeAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void EditAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EditPage));
        }

        private void ReportHackedAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ReportHackedPage));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            mycontactdata.Clear();
            mycontactdata = sqlitehelper.ReadData(mycontactdata);
            SearchContactListView.ItemsSource = mycontactdata;
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder message = new StringBuilder();
            ObservableCollection<MyContactData> mycontactdata = new ObservableCollection<MyContactData>();
            var searchresult = sqlitehelper.QueryData(SearchAutoSuggestBox.Text.Trim());
            foreach (var item in searchresult)
            {
                message.AppendLine($"索引:{item.ID};联系人:{item.MyContactName};号码:{item.MyPhoneNumber};备注:{item.MyConstactDesrc}");
            }
            await new MessageDialog(message.ToString()).ShowAsync();
        }
    }
}
