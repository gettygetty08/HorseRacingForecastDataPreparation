using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace 競馬過去レース
{
    public class レース情報マッピング : ClassMap<レース情報格納クラス>
    {
        private レース情報マッピング()
        {
            Map(x => x.レース名).Index(0);
            Map(x => x.開催).Index(1);
            Map(x => x.着順).Index(2);
            Map(x => x.距離).Index(3);
            Map(x => x.馬場).Index(4);
            Map(x => x.タイム).Index(5);
            Map(x => x.馬体重).Index(6);
            Map(x => x.日付).Index(7);
        }
    }
}
