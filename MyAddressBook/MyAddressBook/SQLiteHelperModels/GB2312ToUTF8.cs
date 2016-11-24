using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAddressBook.SQLiteHelperModels
{
   public class GB2312ToUTF8
    {
        public static string ToUTF8(string gb2312string)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] encodedBytes = utf8.GetBytes(gb2312string);
            string decodedString = utf8.GetString(encodedBytes);
            return decodedString;
        }
        //UTF8转GB2312
        public static string ToGB2312(string utf8string)
        {
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            byte[] encodedBytes = gb2312.GetBytes(utf8string); //编码为GB2312
            string decodedString = gb2312.GetString(encodedBytes);//得到编码后的字符串
            return decodedString;
        }
    }
}
