using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;
using System.Windows;
using System.Data;
using System.Reflection;
using 競馬過去レース.レース指数;

namespace 競馬過去レース
{
    public partial class レース予想用ファイル作成ツール : Form
    {
        public レース予想用ファイル作成ツール()
        {
            InitializeComponent();

            取込フォルダボタン.Click += SetFolderPath(InFolderPathTextBox, "取込フォルダを選択してください。");
            出力フォルダボタン.Click += SetFolderPath(OutFolderPathTextBox, "出力フォルダを選択してください。");

        }


        private EventHandler SetFolderPath(TextBox txtbox, string Title)
            => (_, __)
            =>
            {
                using (openFileDialog1)
                {
                    openFileDialog1.Title = Title;
                    openFileDialog1.InitialDirectory = txtbox.Text == string.Empty ? $@"C:\Users\getty\Desktop\競馬レース情報" : txtbox.Text;

                    if (openFileDialog1.ShowDialog() == DialogResult.OK) txtbox.Text = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
                }
            };

        private void 終了ボタン_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 処理開始ボタン_Click(object sender, EventArgs e)
        {

            try
            {
                if (Directory.Exists(InFolderPathTextBox.Text) == false) MessageBox.Show("取込フォルダが存在しません。","エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
                if (Directory.Exists(OutFolderPathTextBox.Text) == false) MessageBox.Show("出力フォルダが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                var raceDirectoryInfomation = new DirectoryInfo(InFolderPathTextBox.Text);
                var outDirectoryInfomation = new DirectoryInfo(OutFolderPathTextBox.Text);
                var horseRaceList = raceDirectoryInfomation.GetFiles().ToList();
                var joinRaceInfoList = new List<レース情報格納クラス>();
                var 距離リスト = new string[] { "芝1000", "芝1200", "芝1400", "芝1600", "芝1800", "芝2000","芝2200", "芝2400","芝2500","芝3000", "ダ1200", "ダ1400", "ダ1600", "ダ1800" };
                var コースリスト = new string[] { "東京", "中山", "京都", "阪神", "中京", "札幌", "函館", "福島", "新潟", "小倉" };
                var 馬場リスト = new string[] { "良", "稍", "重", "不" };
                var 距離別スピード指数出力用 = new List<レース分析データ格納クラス>();
                var 要素別着順出力用 = new List<レース分析データ格納クラス>();
                var ハイペース要素別3F出力用 = new List<レース分析データ格納クラス>();
                var スローペース要素別3F出力用 = new List<レース分析データ格納クラス>();
                var ミドルペース要素別3F出力用 = new List<レース分析データ格納クラス>();


                //1年前まで
                var befor1Years = DateTime.Now.AddYears(-1).ToString();


                foreach (var RaceResults in horseRaceList)
                {
                   
                    var raceResultsByHorse = CSV操作.GetCsv(RaceResults.FullName).ToList();

                    //ここ１年以内のレール結果のみ抽出
                    var workList = raceResultsByHorse.Where(x => x.日付.CompareTo(befor1Years) > 0).ToList();
                    var horseName = Path.GetFileNameWithoutExtension(RaceResults.FullName);

                    距離別スピード指数出力用.Add(GetSpeedIndex(workList, horseName,距離リスト));
                    要素別着順出力用.Add(Get要素別着順(raceResultsByHorse, horseName, 距離リスト, コースリスト,馬場リスト));
                    ハイペース要素別3F出力用.Add(Get要素別3F(workList.Where(x => ペース判定(x.ペース) == "ハイペース").ToList(), horseName, 距離リスト, コースリスト, 馬場リスト));
                    スローペース要素別3F出力用.Add(Get要素別3F(workList.Where(x => ペース判定(x.ペース) == "スローペース").ToList(), horseName, 距離リスト, コースリスト, 馬場リスト));
                    ミドルペース要素別3F出力用.Add(Get要素別3F(workList.Where(x => ペース判定(x.ペース) == "ミドルペース").ToList(), horseName, 距離リスト, コースリスト, 馬場リスト));
                }


                //string ファイル名 = $"{raceDirectoryInfomation.Name}予想用ファイル.csv";
                //CSV操作.CSV出力<レース予想用ファイル出力マッピング, レース情報格納クラス>(Path.Combine(outDirectoryInfomation.FullName, ファイル名), joinRaceInfoList);
                string ファイル名 = $"{raceDirectoryInfomation.Name}距離別スピード指数.csv";
                CSV操作.CSV出力<距離別スピード指数出力マッピング, レース分析データ格納クラス>(Path.Combine(outDirectoryInfomation.FullName, ファイル名), 距離別スピード指数出力用);

                string ファイル名2 = $"{raceDirectoryInfomation.Name}要素別着順.csv";
                CSV操作.CSV出力<要素別着順一覧出力用マッピング, レース分析データ格納クラス>(Path.Combine(outDirectoryInfomation.FullName, ファイル名2), 要素別着順出力用);

                string ファイル名3 = $"{raceDirectoryInfomation.Name}上がり3Fハイペース.csv";
                CSV操作.CSV出力<要素別着順一覧出力用マッピング, レース分析データ格納クラス>(Path.Combine(outDirectoryInfomation.FullName, ファイル名3), ハイペース要素別3F出力用);
                string ファイル名4 = $"{raceDirectoryInfomation.Name}上がり3Fスローペース.csv";
                CSV操作.CSV出力<要素別着順一覧出力用マッピング, レース分析データ格納クラス>(Path.Combine(outDirectoryInfomation.FullName, ファイル名4), スローペース要素別3F出力用);
                string ファイル名5 = $"{raceDirectoryInfomation.Name}上がり3Fミドルペース.csv";
                CSV操作.CSV出力<要素別着順一覧出力用マッピング, レース分析データ格納クラス>(Path.Combine(outDirectoryInfomation.FullName, ファイル名5), ミドルペース要素別3F出力用);

                MessageBox.Show("処理完了。\nファイルのパスをクリップボードにコピーしています。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clipboard.SetData(DataFormats.Text, Path.Combine(outDirectoryInfomation.FullName, ファイル名));
                Clipboard.SetData(DataFormats.Text, Path.Combine(outDirectoryInfomation.FullName, ファイル名2));

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        #region[---GetSpeedIndex  距離別スピード指数算出]
        private レース分析データ格納クラス GetSpeedIndex(List<レース情報格納クラス>raceResults ,string horceName,string[] racingDistance)
        {
            var wk2 = new レース分析データ格納クラス() { 馬名 = horceName };
            foreach (var distance in racingDistance)
            {
                var wk1 = raceResults.Where(x => x.距離 == distance).OrderByDescending(x => x.日付).FirstOrDefault();

                if (wk1 == null || string.IsNullOrEmpty(wk1.タイム) || wk1.開催.Length < 4) continue;

                string time = wk1.タイム;
                int min = int.Parse(time.Substring(0, 1));
                int sec = int.Parse(time.Substring(2, 2));
                int msec = int.Parse(time.Substring(5, 1)) * 100;
                var timespan = new TimeSpan(0, 0, min, sec, msec);
                double 走破Time = Double.Parse($"{timespan.TotalSeconds * 10:####}");

                var スピード指数 = new RaceIndex(wk1.開催.Substring(1, 2), wk1.距離, 走破Time, wk1.馬場, wk1.斤量);

                var 距離設定 = typeof(レース分析データ格納クラス).GetProperty($"{distance}");
                距離設定.SetValue(wk2, スピード指数.OutSpeedIndex(wk1.レース名).ToString("###.#"));
            }

            return wk2;

        }
        #endregion

        #region[---Get要素別着順]
        private レース分析データ格納クラス Get要素別着順(List<レース情報格納クラス> raceResults, string horceName, string[] racingDistance,string[] courseList,string[] babaList)
        {
            var wk = new レース分析データ格納クラス() { 馬名 = horceName };
            //距離別着順集計
            foreach(var distance in racingDistance)
            {
                var wk1 = raceResults.Where(x => x.距離 == distance).ToList();

                var 保存先設定 = typeof(レース分析データ格納クラス).GetProperty($"{distance}");
                保存先設定.SetValue(wk, 着順集計結果(wk1));
            }

            //コース別着順集計
            foreach (var course in courseList)
            {
                var wk1 = raceResults.Where(x => x.開催.Contains(course)).ToList();

                var 保存先設定 = typeof(レース分析データ格納クラス).GetProperty($"{course}");
                保存先設定.SetValue(wk, 着順集計結果(wk1));
            }

            //馬場状態別
            foreach (var baba in babaList)
            {
                var wk1 = raceResults.Where(x => x.馬場.Contains(baba)).ToList();

                var 保存先設定 = typeof(レース分析データ格納クラス).GetProperty($"{baba}");
                保存先設定.SetValue(wk, 着順集計結果(wk1));
            }

            return wk;
        }
        #endregion

        #region[---Get要素別3F]
        private レース分析データ格納クラス Get要素別3F(List<レース情報格納クラス> raceResults, string horceName, string[] racingDistance, string[] courseList, string[] babaList)
        {
            var wk = new レース分析データ格納クラス() { 馬名 = horceName };
            //距離別着順集計
            foreach (var distance in racingDistance)
            {
                var wk1 = raceResults.Where(x => x.距離 == distance).ToList();

                var 保存先設定 = typeof(レース分析データ格納クラス).GetProperty($"{distance}");
                保存先設定.SetValue(wk, Get最速上がり3F(wk1));
            }

            //コース別着順集計
            foreach (var course in courseList)
            {
                var wk1 = raceResults.Where(x => x.開催.Contains(course)).ToList();

                var 保存先設定 = typeof(レース分析データ格納クラス).GetProperty($"{course}");
                保存先設定.SetValue(wk, Get最速上がり3F(wk1));
            }

            //馬場状態別
            foreach (var baba in babaList)
            {
                var wk1 = raceResults.Where(x => x.馬場.Contains(baba)).ToList();

                var 保存先設定 = typeof(レース分析データ格納クラス).GetProperty($"{baba}");
                保存先設定.SetValue(wk, Get最速上がり3F(wk1));
            }

            return wk;
        }
        #endregion

        private string 着順集計結果(List<レース情報格納クラス> list)
        {
            string results = "";
            int first = list.Count(x => x.着順 == "1");
            int second = list.Count(x => x.着順 == "2");
            int third = list.Count(x => x.着順 == "3");
            int outside = list.Count(x => x.着順 != "1" || x.着順 != "2" || x.着順 != "3");

            return results = $"({first}-{second}-{third}-{outside})";
        } 

        private string Get最速上がり3F(List<レース情報格納クラス> list)
        {
            double conv = 0;
            if (list.Count() == 0) return "";

            return list.OrderBy(x => x.上り).FirstOrDefault().上り;
        }

        private string ペース判定(string value)
        {
            var ペース = value.Split('-');
            if (ペース.Length < 2) return "判定不能";
            foreach (var item in ペース)
            {
                if (!double.TryParse(item, out var i)) return "判定不能";
            }

            double result = double.Parse(ペース[0]) - double.Parse(ペース[1]);

            if (result >= 1) return "スローペース";
            if (result >= -1) return "ハイペース";
            if (result < 1 && result < -1) return "ミドルペース";

            return "判定不能";


        }
    }
}
