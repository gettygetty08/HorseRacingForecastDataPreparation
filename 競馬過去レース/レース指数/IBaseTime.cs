using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 競馬過去レース.レース指数
{
    interface IBaseTime
    {
        string Get開催場所();
        int Get基準タイム(string 距離);

    }
}
