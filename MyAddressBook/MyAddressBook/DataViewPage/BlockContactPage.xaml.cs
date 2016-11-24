using MyAddressBook.Models;
using MyAddressBook.SQLiteHelperModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MyAddressBook.DataViewPage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlockContactPage : Page
    {
        ObservableCollection<MyContactData> mycontactdata = new ObservableCollection<MyContactData>();
        SQLiteHelper sqlitehelper = new SQLiteHelper();
        MyContactData updataitem;
        public BlockContactPage()
        {
            this.InitializeComponent();
            this.Loaded += Page_Loaded;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            mycontactdata.Clear();
            mycontactdata = sqlitehelper.ReadData(mycontactdata);
            BlockContactListView.ItemsSource = mycontactdata;
        }

        private void BlockContactListView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            updataitem = BlockContactListView.SelectedItem as MyContactData;
            var updataindex = mycontactdata.IndexOf(updataitem);
        }

        private void BlockDataButton_Click(object sender, RoutedEventArgs e)
        {
            var blocktemp = BlockContactListView.SelectedItem as MyContactData;

            sqlitehelper.DelData(blocktemp);
            var sqldatas = "delete from sqlite_sequence where name='MyContactData';";
            sqlitehelper.UpDelData(sqldatas);
            mycontactdata.Remove(blocktemp);
        }
    }
}
