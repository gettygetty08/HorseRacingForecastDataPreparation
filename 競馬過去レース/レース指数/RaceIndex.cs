using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 競馬過去レース.レース指数
{
    public class RaceIndex
    {
        private string RacePlaceName { get; set; }
        private string RaceRange { get; set; }
        private double RunTime { get; set; }
        private double Baba { get; set; }
        private double Weight { get; set; }
        private const double RaceRangeIndex = 5.7;
        private Dictionary<string, double> BabaIndex = new Dictionary<string, double>()
        {
            {"良",0.0 },
            {"稍",0.9 },
            {"重",-0.5 },
            {"不",-0.9 }
        };
        private Dictionary<string, double> WeightIndex = new Dictionary<string, double>()
        {
            {"51",2.9 },
            {"52",0.7 },
            {"53",0.9 },
            {"54",0.9 },
            {"55",0.0 },
            {"56.5",-5.0 },
            {"57",-1.3 },
            {"58",-2.2 },
            {"58.5",-8.1 },
            {"59",-6.3 }
        };
        private List<BaseTime> ListBaseTime = new List<BaseTime>()
        {
            new BaseTime東京(),
            new BaseTime中山(),
            new BaseTime京都(),
            new BaseTime阪神(),
            new BaseTime中京(),
            new BaseTime札幌(),
            new BaseTime函館(),
            new BaseTime福島(),
            new BaseTime新潟(),
            new BaseTime小倉()
        };

        public RaceIndex(string racePlaceName,string raceRange, double runTime,string baba,string weight)
        {
            this.RacePlaceName = racePlaceName;
            this.RaceRange = raceRange;
            this.RunTime = runTime;
            this.Baba = BabaIndex[baba];
            this.Weight = WeightIndex.ContainsKey(baba)? WeightIndex[weight] : 0.0;

        }

        public double OutSpeedIndex()
        {
            var btime = ListBaseTime.SingleOrDefault(x => x.Get開催場所() == RacePlaceName).Get基準タイム(RaceRange);
            return (btime - RunTime) * RaceRangeIndex + 80 + Baba + Weight;
        }

    }
}
