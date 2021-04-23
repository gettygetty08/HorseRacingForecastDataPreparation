using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace 競馬過去レース
{
    public class レース予想用ファイル出力マッピング : ClassMap<レース情報格納クラス>
    {
        private レース予想用ファイル出力マッピング()
            {
                Map(x => x.馬).Index(0).Name("馬");
                Map(x => x.レース名).Index(1).Name("レース名");
                Map(x => x.開催).Index(2).Name("開催");
                Map(x => x.着順).Index(3).Name("着順");
                Map(x => x.距離).Index(4).Name("距離");
                Map(x => x.馬場).Index(5).Name("馬場");
                Map(x => x.タイム).Index(6).Name("タイム");
                Map(x => x.馬体重).Index(7).Name("馬体重");
                Map(x => x.日付).Index(8).Name("日付");
            }
        
    }
}
