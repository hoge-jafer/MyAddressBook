using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAddressBook.Models
{
   internal class MyContactData
    {
        [PrimaryKey] //主键
        [AutoIncrement]//自增
        [NotNull]//不能为空
        public int ID { get; set; }
        public string MyContactName { get; set; }
        public int MyPhoneNumber { get; set; }
        public string MyConstactDesrc { get; set; }

        public MyContactData() { }
        public MyContactData(int ID,string MyContactName,int MyPhoneNumber,string MyConstactDesrc)
        {
            this.ID = ID;
            this.MyContactName = MyContactName;
            this.MyPhoneNumber = MyPhoneNumber;
            this.MyConstactDesrc = MyConstactDesrc;
        }
    }
}
