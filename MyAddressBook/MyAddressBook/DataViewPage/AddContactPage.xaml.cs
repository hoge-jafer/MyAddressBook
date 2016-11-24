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
    public sealed partial class AddContactPage : Page
    {
        ObservableCollection<MyContactData> mycontactdata = new ObservableCollection<MyContactData>();
        SQLiteHelper sqlitehelper = new SQLiteHelper();
        //MyContactData updataitem;
        //int updataitemindex;
        public AddContactPage()
        {
            this.InitializeComponent();
            this.Loaded += page_Loaded;
        }

        private void TrueButton_Click(object sender, RoutedEventArgs e)
        {
            sqlitehelper.CreateDataBase();
            var AddMyData = new MyContactData()
            {
                MyContactName = NameTextBox.Text.Trim(),
                MyPhoneNumber=Convert.ToInt32(PhoneTextBox.Text.Trim()),
                MyConstactDesrc=DesrcTextBox.Text.Trim()
            };
            sqlitehelper.AddData(AddMyData);
            mycontactdata.Add(new MyContactData(mycontactdata.Count+1,NameTextBox.Text.Trim(),
                Convert.ToInt32(PhoneTextBox.Text.Trim()),DesrcTextBox.Text.Trim()));
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            mycontactdata.Clear();
            mycontactdata = sqlitehelper.ReadData(mycontactdata);
            AddContactListView.ItemsSource = mycontactdata;
        }

        //private void page_Loaded(object sender, RoutedEventArgs e)
        //{
        //    mycontactdata.Clear();
        //    mycontactdata = sqlitehelper.ReadData(mycontactdata);

        //}
    }
}
