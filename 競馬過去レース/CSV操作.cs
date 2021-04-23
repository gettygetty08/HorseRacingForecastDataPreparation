using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CsvHelper.Configuration;

namespace 競馬過去レース
{
   　public class CSV操作
    {
        public static List<レース情報格納クラス> GetCsv(string failePath)
        {
            List<レース情報格納クラス> list1 = new List<レース情報格納クラス>();

            using(var csv = new CsvReader(new StreamReader(failePath), CultureInfo.InvariantCulture))
            {
                var config = csv.Configuration;
                config.HasHeaderRecord = true;
                config.RegisterClassMap<レース情報マッピング>();
                list1 = csv.GetRecords<レース情報格納クラス>().ToList();

            }
            return list1;
        }


        public static void CSV出力<CMAP, T>(string f_Path, IEnumerable<T> 出力リスト)
           where CMAP : ClassMap
           where T : class
        {
            using (var csv = new CsvWriter(new StreamWriter(f_Path), CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.ShouldQuote = (filed, context) => true;
                csv.Configuration.RegisterClassMap<CMAP>();
                csv.WriteRecords(出力リスト);
            }
        }


    }
}
