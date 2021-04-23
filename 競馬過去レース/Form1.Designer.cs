namespace 競馬過去レース
{
    partial class レース予想用ファイル作成ツール
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(レース予想用ファイル作成ツール));
            this.InFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.OutFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.取込フォルダボタン = new System.Windows.Forms.Button();
            this.出力フォルダボタン = new System.Windows.Forms.Button();
            this.処理開始ボタン = new System.Windows.Forms.Button();
            this.終了ボタン = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // InFolderPathTextBox
            // 
            this.InFolderPathTextBox.Location = new System.Drawing.Point(65, 86);
            this.InFolderPathTextBox.Name = "InFolderPathTextBox";
            this.InFolderPathTextBox.Size = new System.Drawing.Size(298, 19);
            this.InFolderPathTextBox.TabIndex = 0;
            // 
            // OutFolderPathTextBox
            // 
            this.OutFolderPathTextBox.Location = new System.Drawing.Point(65, 160);
            this.OutFolderPathTextBox.Name = "OutFolderPathTextBox";
            this.OutFolderPathTextBox.Size = new System.Drawing.Size(298, 19);
            this.OutFolderPathTextBox.TabIndex = 1;
            // 
            // 取込フォルダボタン
            // 
            this.取込フォルダボタン.Location = new System.Drawing.Point(432, 84);
            this.取込フォルダボタン.Name = "取込フォルダボタン";
            this.取込フォルダボタン.Size = new System.Drawing.Size(75, 23);
            this.取込フォルダボタン.TabIndex = 2;
            this.取込フォルダボタン.Text = "取込フォルダ選択";
            this.取込フォルダボタン.UseVisualStyleBackColor = true;
            // 
            // 出力フォルダボタン
            // 
            this.出力フォルダボタン.Location = new System.Drawing.Point(432, 160);
            this.出力フォルダボタン.Name = "出力フォルダボタン";
            this.出力フォルダボタン.Size = new System.Drawing.Size(75, 23);
            this.出力フォルダボタン.TabIndex = 3;
            this.出力フォルダボタン.Text = "出力フォルダ";
            this.出力フォルダボタン.UseVisualStyleBackColor = true;
            // 
            // 処理開始ボタン
            // 
            this.処理開始ボタン.Location = new System.Drawing.Point(422, 254);
            this.処理開始ボタン.Name = "処理開始ボタン";
            this.処理開始ボタン.Size = new System.Drawing.Size(95, 42);
            this.処理開始ボタン.TabIndex = 4;
            this.処理開始ボタン.Text = "処理開始";
            this.処理開始ボタン.UseVisualStyleBackColor = true;
            this.処理開始ボタン.Click += new System.EventHandler(this.処理開始ボタン_Click);
            // 
            // 終了ボタン
            // 
            this.終了ボタン.Location = new System.Drawing.Point(65, 310);
            this.終了ボタン.Name = "終了ボタン";
            this.終了ボタン.Size = new System.Drawing.Size(100, 44);
            this.終了ボタン.TabIndex = 5;
            this.終了ボタン.Text = "終了";
            this.終了ボタン.UseVisualStyleBackColor = true;
            this.終了ボタン.Click += new System.EventHandler(this.終了ボタン_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.CheckFileExists = false;
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Folder |.";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // レース予想用ファイル作成ツール
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 389);
            this.Controls.Add(this.終了ボタン);
            this.Controls.Add(this.処理開始ボタン);
            this.Controls.Add(this.出力フォルダボタン);
            this.Controls.Add(this.取込フォルダボタン);
            this.Controls.Add(this.OutFolderPathTextBox);
            this.Controls.Add(this.InFolderPathTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "レース予想用ファイル作成ツール";
            this.Text = "レース予想用ファイル作成ツール";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InFolderPathTextBox;
        private System.Windows.Forms.TextBox OutFolderPathTextBox;
        private System.Windows.Forms.Button 取込フォルダボタン;
        private System.Windows.Forms.Button 出力フォルダボタン;
        private System.Windows.Forms.Button 処理開始ボタン;
        private System.Windows.Forms.Button 終了ボタン;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

