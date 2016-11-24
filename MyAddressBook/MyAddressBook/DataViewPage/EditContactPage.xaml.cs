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
    public sealed partial class EditContactPage : Page
    {
        ObservableCollection<MyContactData> mycontactdata = new ObservableCollection<MyContactData>();
        SQLiteHelper sqlitehelper = new SQLiteHelper();
        MyContactData updataitem;
        int updataitemindex;
        public EditContactPage()
        {
            this.InitializeComponent();
            this.Loaded += Page_Loaded;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var EditMyData = new MyContactData()
            {
                ID = updataitem.ID,
                MyContactName = NameTextBox.Text.Trim(),
                MyPhoneNumber = Convert.ToInt32(PhoneTextBox.Text.Trim()),
                MyConstactDesrc = DesrcTextBox.Text.Trim()
            };
            

            sqlitehelper.UpData(EditMyData);
            mycontactdata.Remove(updataitem);
            mycontactdata.Insert(updataitemindex, new MyContactData(updataitem.ID, NameTextBox.Text.Trim(), Convert.ToInt32(PhoneTextBox.Text.Trim()), DesrcTextBox.Text.Trim()));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            mycontactdata.Clear();
            mycontactdata = sqlitehelper.ReadData(mycontactdata);
            EditContactListView.ItemsSource = mycontactdata;
        }

        private void EditContactListView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            updataitem = EditContactListView.SelectedItem as MyContactData;
            var updataindex = mycontactdata.IndexOf(updataitem);

            EditIDTextBlock.Text = Convert.ToString(updataitem.ID).Trim();
            NameTextBox.Text = Convert.ToString(updataitem.MyContactName).Trim();
            PhoneTextBox.Text = Convert.ToString(updataitem.MyPhoneNumber).Trim();
            DesrcTextBox.Text = Convert.ToString(updataitem.MyConstactDesrc).Trim();
        }
    }
}
