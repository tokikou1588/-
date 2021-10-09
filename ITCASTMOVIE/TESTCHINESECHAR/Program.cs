using Microsoft.International.Converters.PinYinConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NPOI.HSSF.UserModel;

namespace TESTCHINESECHAR
{
    class Program
    {
        static void Main(string[] args)
        {

            FileStream fs = new FileStream(@"C:\Users\NeeKin\Desktop\1.xls", FileMode.Create);
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = workbook.CreateSheet("工资表");
            HSSFRow row = sheet.CreateRow(0);
            HSSFCell cell = row.CreateCell(0);
            cell.SetCellValue("第一格");
            workbook.Write(fs);
            fs.Close();
            ChineseChar ch = new ChineseChar('中');
            // int i = ChineseChar.GetCharCount(13);
            // int s =ChineseChar.GetStrokeNumber('凹');
             bool b =  ChineseChar.IsValidPinyin("ni1");
             for (int i = 0; i < ch.PinyinCount; i++)
             {
                 string str =  ch.Pinyins[i];
                 string strnew = str.Substring(0,str.Length -1);
                 Console.WriteLine(strnew);

             }
             Console.WriteLine(b);
             Console.ReadKey();
        }
    }
}
