using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace 競馬過去レース
{
    public class 距離別タイム出力用マッピング : ClassMap<レース分析データ格納クラス>
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

    public class 距離別スピード指数出力マッピング : ClassMap<レース分析データ格納クラス>
    {
        private 距離別スピード指数出力マッピング()
        {
            Map(x => x.馬名).Index(0).Name("馬名");
            Map(x => x.芝1000).Index(1).Name("芝1000");
            Map(x => x.芝1200).Index(2).Name("芝1200");
            Map(x => x.芝1400).Index(3).Name("芝1400");
            Map(x => x.芝1600).Index(4).Name("芝1600");
            Map(x => x.芝1800).Index(5).Name("芝1800");
            Map(x => x.芝2000).Index(6).Name("芝2000");
            Map(x => x.芝2200).Index(7).Name("芝2200");
            Map(x => x.芝2400).Index(8).Name("芝2400");
            Map(x => x.芝2500).Index(9).Name("芝2500");
            Map(x => x.芝3000).Index(10).Name("芝3000");
            Map(x => x.ダ1200).Index(11).Name("ダ1200");
            Map(x => x.ダ1400).Index(12).Name("ダ1400");
            Map(x => x.ダ1600).Index(13).Name("ダ1600");
            Map(x => x.ダ1800).Index(14).Name("ダ1800");
        }
    }

    public class 要素別着順一覧出力用マッピング : ClassMap<レース分析データ格納クラス>
    {
        private 要素別着順一覧出力用マッピング()
        {
            Map(x => x.馬名).Index(0).Name("馬名");
            Map(x => x.芝1000).Index(1).Name("芝1000");
            Map(x => x.芝1200).Index(2).Name("芝1200");
            Map(x => x.芝1400).Index(3).Name("芝1400");
            Map(x => x.芝1600).Index(4).Name("芝1600");
            Map(x => x.芝1800).Index(5).Name("芝1800");
            Map(x => x.芝2000).Index(6).Name("芝2000");
            Map(x => x.芝2200).Index(7).Name("芝2200");
            Map(x => x.芝2400).Index(8).Name("芝2400");
            Map(x => x.芝2500).Index(9).Name("芝2500");
            Map(x => x.芝3000).Index(10).Name("芝3000");
            Map(x => x.ダ1200).Index(11).Name("ダ1200");
            Map(x => x.ダ1400).Index(12).Name("ダ1400");
            Map(x => x.ダ1600).Index(13).Name("ダ1600");
            Map(x => x.ダ1800).Index(14).Name("ダ1800");
            Map(x => x.東京).Index(15).Name("東京");
            Map(x => x.中山).Index(16).Name("中山");
            Map(x => x.京都).Index(17).Name("京都");
            Map(x => x.阪神).Index(18).Name("阪神");
            Map(x => x.中京).Index(19).Name("中京");
            Map(x => x.札幌).Index(20).Name("札幌");
            Map(x => x.函館).Index(21).Name("函館");
            Map(x => x.福島).Index(22).Name("福島");
            Map(x => x.新潟).Index(23).Name("新潟");
            Map(x => x.小倉).Index(24).Name("小倉");
            Map(x => x.良).Index(25).Name("良");
            Map(x => x.稍).Index(26).Name("稍");
            Map(x => x.重).Index(27).Name("重");
            Map(x => x.不).Index(28).Name("不");





        }
    }






}
