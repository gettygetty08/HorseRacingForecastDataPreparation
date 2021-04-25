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
                var 距離リスト = new string[] { "芝1000", "芝1200", "芝1400", "芝1600", "芝1800", "芝2000", "芝2400", "ダ1200", "ダ1400", "ダ1600", "ダ1800" };
                var 距離別タイム出力用 = new List<距離別タイム格納クラス>();

                var befor1Years = DateTime.Now.AddYears(-1).ToString();

                //foreach (var item in horseRaceList)
                //{
                //    var list = CSV操作.GetCsv(item.FullName).Where(x => x.日付.CompareTo(befor1Years) > 0).ToList();
                //    var list2 = new List<レース情報格納クラス>();

                //    foreach (var item2 in list.GroupBy(x => x.距離))
                //    {
                //        var test = list.Where(x => x.距離 == item2.Key).OrderByDescending(x => x.日付);
                //        list2.Add(list.Where(x => x.距離 == item2.First().距離).OrderByDescending(x => x.日付).FirstOrDefault());
                //    }

                //    list2.ForEach(x => x.馬 = Path.GetFileNameWithoutExtension(item.FullName));

                //    joinRaceInfoList.AddRange(list2);
                //}

                foreach (var item in horseRaceList)
                {
                    var list = CSV操作.GetCsv(item.FullName).Where(x => x.日付.CompareTo(befor1Years) > 0).ToList();


                    foreach (var 馬場状態 in list.GroupBy(x => x.馬場))
                    {
                        var wk2 = new 距離別タイム格納クラス() { 馬名 = Path.GetFileNameWithoutExtension(item.FullName) };
                        wk2.馬場状態 = 馬場状態.Key;
                        foreach (var item2 in 距離リスト)
                        {
                            var wk1 = list.Where(x => x.距離 == item2 && x.馬場 == 馬場状態.Key).OrderByDescending(x => x.日付).FirstOrDefault();

                            if (wk1 == null) continue;

                            var 距離設定 = typeof(距離別タイム格納クラス).GetProperty($"{item2}");
                            距離設定.SetValue(wk2, wk1.タイム);
                        }

                        距離別タイム出力用.Add(wk2);
                    }

                }

                //string ファイル名 = $"{raceDirectoryInfomation.Name}予想用ファイル.csv";
                //CSV操作.CSV出力<レース予想用ファイル出力マッピング, レース情報格納クラス>(Path.Combine(outDirectoryInfomation.FullName, ファイル名), joinRaceInfoList);
                string ファイル名 = $"{raceDirectoryInfomation.Name}距離別タイム.csv";
                CSV操作.CSV出力<距離別タイム出力用マッピング, 距離別タイム格納クラス>(Path.Combine(outDirectoryInfomation.FullName, ファイル名), 距離別タイム出力用);

                MessageBox.Show("処理完了。\nファイルのパスをクリップボードにコピーしています。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clipboard.SetData(DataFormats.Text, Path.Combine(outDirectoryInfomation.FullName, ファイル名));

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
