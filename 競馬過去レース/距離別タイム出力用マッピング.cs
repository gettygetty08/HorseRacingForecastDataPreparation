using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace 競馬過去レース
{
    public class 距離別タイム出力用マッピング : ClassMap<距離別タイム格納クラス>
    {
        private 距離別タイム出力用マッピング()
        {
            Map(x => x.馬名).Index(0).Name("馬名");
            Map(x => x.馬場状態).Index(1).Name("馬場状態");
            Map(x => x.芝1000).Index(2).Name("芝1000");
            Map(x => x.芝1200).Index(3).Name("芝1200");
            Map(x => x.芝1400).Index(4).Name("芝1400");
            Map(x => x.芝1600).Index(5).Name("芝1600");
            Map(x => x.芝1800).Index(6).Name("芝1800");
            Map(x => x.芝2000).Index(7).Name("芝2000");
            Map(x => x.芝2400).Index(8).Name("芝2400");
            Map(x => x.ダ1200).Index(9).Name("ダ1200");
            Map(x => x.ダ1400).Index(10).Name("ダ1400");
            Map(x => x.ダ1600).Index(11).Name("ダ1600");
            Map(x => x.ダ1800).Index(12).Name("ダ1800");
        }
    }
}
