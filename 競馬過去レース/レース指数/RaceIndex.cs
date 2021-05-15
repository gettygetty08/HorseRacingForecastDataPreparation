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
        private double RunningTime { get; set; }
        private double Baba { get; set; }
        private double Weight { get; set; }
        private double RaceRangeIndex { get; set; }
        private Dictionary<string, double> BabaIndex = new Dictionary<string, double>()
        {
            {"良",0 },
            {"稍",9 },
            {"重",-5 },
            {"不",9 }
        };
        private Dictionary<string, double> WeightIndex = new Dictionary<string, double>()
        {
            {"51",29 },
            {"52",7 },
            {"53",9 },
            {"54",9 },
            {"55",0 },
            {"56.5",-50 },
            {"57",-13 },
            {"58",-22 },
            {"58.5",-81 },
            {"59",-63 }
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

        private Dictionary<string, double> RaceClassTimeCorrection = new Dictionary<string, double>()
        {
            {"G1",-13 },
            {"G2",-8 },
            {"G3",-6 },
            {"未勝利",35 },
            {"新馬",24 }
        };

        public RaceIndex(string racePlaceName,string raceRange, double runTime,string baba,string weight)
        {
            this.RacePlaceName = racePlaceName;
            this.RaceRange = raceRange;
            this.RunningTime = runTime;
            this.Baba = BabaIndex[baba];
            this.Weight = WeightIndex.ContainsKey(baba)? WeightIndex[weight] : 0.0;

        }

        public double OutSpeedIndex()
        {
            var baseTime = ListBaseTime.SingleOrDefault(x => x.Get開催場所() == RacePlaceName).Get基準タイム(RaceRange);
            var デバッグ確認用 = (baseTime - RunningTime) * RaceRangeIndex + 80 + Baba + Weight;
            return (baseTime - RunningTime) * RaceRangeIndex + 80 + Baba + Weight;
       
        }
        public double OutSpeedIndex(string raceName)
        {

            var baseTime = ListBaseTime.SingleOrDefault(x => x.Get開催場所() == RacePlaceName).Get基準タイム(RaceRange);

            RaceRangeIndex = (1.0 / baseTime) * 1000;

            double correctionTime = 0;
            foreach (var item in RaceClassTimeCorrection)
            {
                if (raceName.Contains(item.Key))
                {
                    correctionTime = RaceClassTimeCorrection[item.Key];
                    break;
                }

            }

            var デバッグ確認用 = (baseTime - RunningTime) * RaceRangeIndex + 80 + Baba + Weight;
            return ((baseTime+correctionTime) - RunningTime) * RaceRangeIndex + 80 + Baba + Weight;
        }

    }
}
