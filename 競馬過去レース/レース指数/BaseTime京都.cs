using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 競馬過去レース.レース指数
{
    public class BaseTime京都 : BaseTime
    {
        internal BaseTime京都()
        {
            レース開催場所 = "京都";
            芝1000 = 543;
            芝1200 = 682;
            芝1400 = 815;
            芝1600 = 947;
            芝1800 = 1093;
            芝2000 = 1214;
            芝2400 = 1491;
            芝2500 = 1545;
            芝3000 = 1885;
            ダ1200 = 727;
            ダ1400 = 860;
            ダ1600 = 993;
            ダ1800 = 1138;
        }
    }
}
