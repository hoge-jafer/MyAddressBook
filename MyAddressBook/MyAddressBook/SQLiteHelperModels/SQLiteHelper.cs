using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using SQLite.Net.Platform.WinRT;
using MyAddressBook.Models;
using System.Collections.ObjectModel;

namespace MyAddressBook.SQLiteHelperModels
{
   internal class SQLiteHelper
    {
        public string DataBaseName = "MyContactSQLite.db";
        public string DataBasePath;
        //创建数据库连接
        internal SQLite.Net.SQLiteConnection CreactConnection()
        {
            DataBasePath = Path.Combine(ApplicationData.Current.LocalFolder.Path,DataBaseName);
            var Connection = new SQLite.Net.SQLiteConnection(new SQLitePlatformWinRT(),DataBasePath);
            return Connection;
        }
        //创建数据库
        internal void CreateDataBase()
        {
            DataBasePath = Path.Combine(ApplicationData.Current.LocalFolder.Path,DataBaseName);
            using (var Connection=CreactConnection())
            {
                Connection.CreateTable<MyContactData>();
            }
        }
        //增加
        internal int AddData(MyContactData mycontactdata)
        {
            int mydata = 0;
            using (var Connection=CreactConnection())
            {
                mydata = Connection.Insert(mycontactdata);
            }
            return mydata;
        }
        //删除
        internal int DelData(MyContactData mycontactdataid)
        {
            int mydata = 0;
            DataBasePath = Path.Combine(ApplicationData.Current.LocalFolder.Path,DataBaseName);
            using (var Connection=CreactConnection())
            {
                mydata = Connection.Delete(mycontactdataid);
            }
            return mydata;
        }
        //修改
        internal int UpData(MyContactData mycontactupdata)
        {
            int mydata = 0;
            DataBasePath = Path.Combine(ApplicationData.Current.LocalFolder.Path,DataBaseName);
            using (var Connection=CreactConnection())
            {
                mydata = Connection.Update(mycontactupdata);
            }
            return mydata;
        }
        //查询
        internal List<MyContactData> QueryData(string QueryTerm)
        {
            var Terms = "%" + QueryTerm + "%";
            using (var Conneciton=CreactConnection())
            {
                return Conneciton.Query<MyContactData>("select * from MyContactData where MyContactName like ? or MyPhoneNumber like ? or MyConstactDesrc like ?;", Terms, Terms, Terms);
            }
        }
        //读取
        internal ObservableCollection<MyContactData> ReadData(ObservableCollection<MyContactData> myContactData)
        {
            myContactData.Clear();
            DataBasePath = Path.Combine(ApplicationData.Current.LocalFolder.Path,DataBaseName);
            using (var Connection=CreactConnection())
            {
                var DataBaseMyContactDatas = Connection.Table<MyContactData>();
                foreach (var item in DataBaseMyContactDatas)
                {
                    myContactData.Add(item);
                }
            }
            return myContactData;
        }
        internal void UpDelData(string deleteSqliteSequence)
        {

            DataBasePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DataBaseName);

        }
    }
}
