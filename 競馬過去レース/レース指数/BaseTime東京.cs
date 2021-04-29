using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 競馬過去レース.レース指数
{
    public class BaseTime東京 : BaseTime
    {
       internal BaseTime東京()
        {
            レース開催場所 = "東京";
            芝1000 = 544;
            芝1200 = 683;
            芝1400 = 816;
            芝1600 = 948;
            芝1800 = 1094;
            芝2000 = 1216;
            芝2400 = 1492;
            芝2500 = 1547;
            芝3000 = 1886;
            ダ1200 = 729;
            ダ1400 = 861;
            ダ1600 = 994;
            ダ1800 = 1139;
        }

    }
}
