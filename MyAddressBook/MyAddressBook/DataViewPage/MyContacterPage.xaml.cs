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
    public sealed partial class MyContacterPage : Page
    {
        ObservableCollection<MyContactData> mycontactdata = new ObservableCollection<MyContactData>();
        SQLiteHelper sqlitehelper = new SQLiteHelper();
        public MyContacterPage()
        {
            this.InitializeComponent();
            this.Loaded += Page_Loaded;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            mycontactdata.Clear();
            mycontactdata = sqlitehelper.ReadData(mycontactdata);
        }
    }
}
