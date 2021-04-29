using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 競馬過去レース.レース指数
{
    public abstract class BaseTime : IBaseTime
    {
        public string レース開催場所 { get; set; }
        public int 芝1000 { get; set; }
        public int 芝1200 { get; set; }
        public int 芝1400 { get; set; }
        public int 芝1600 { get; set; }
        public int 芝1800 { get; set; }
        public int 芝2000 { get; set; }
        public int 芝2400 { get; set; }
        public int 芝2500 { get; set; }
        public int 芝3000 { get; set; }
        public int ダ1200 { get; set; }
        public int ダ1400 { get; set; }
        public int ダ1600 { get; set; }
        public int ダ1800 { get; set; }



        public string Get開催場所()
        {
            return レース開催場所;
        }

        public int Get基準タイム(string 距離)
        {
            Dictionary<string, int> 距離別基準タイム = new Dictionary<string, int>()
            {
               {"芝1000",芝1000 },
               {"芝1200",芝1200 },
               {"芝1400",芝1400 },
               {"芝1600",芝1600 },
               {"芝1800",芝1800 },
               {"芝2000",芝2000 },
               {"芝2400",芝2400 },
               {"芝2500",芝2500 },
               {"芝3000",芝3000 },
               {"ダ1200",ダ1200 },
               {"ダ1400",ダ1400 },
               {"ダ1600",ダ1600 },
               {"ダ1800",ダ1800 },
            };

            return 距離別基準タイム[距離];

        }

    }
}
