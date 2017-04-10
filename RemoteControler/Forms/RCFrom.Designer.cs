namespace RemoteControler
{
    partial class RCForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RCForm));
            this.BtnStart = new System.Windows.Forms.Button();
            this.LstChickens = new System.Windows.Forms.ListBox();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(378, 46);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(75, 23);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.TabStop = false;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // LstChickens
            // 
            this.LstChickens.FormattingEnabled = true;
            this.LstChickens.ItemHeight = 12;
            this.LstChickens.Location = new System.Drawing.Point(12, 12);
            this.LstChickens.Name = "LstChickens";
            this.LstChickens.Size = new System.Drawing.Size(338, 136);
            this.LstChickens.TabIndex = 1;
            this.LstChickens.TabStop = false;
            this.LstChickens.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LstChickens_MouseDoubleClick);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Location = new System.Drawing.Point(378, 94);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(75, 23);
            this.BtnRefresh.TabIndex = 2;
            this.BtnRefresh.TabStop = false;
            this.BtnRefresh.Text = "ReFresh";
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Controler";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // RCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 186);
            this.Controls.Add(this.BtnRefresh);
            this.Controls.Add(this.LstChickens);
            this.Controls.Add(this.BtnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RCForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controler";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RCForm_FormClosed);
            this.Load += new System.EventHandler(this.RCForm_Load);
            this.SizeChanged += new System.EventHandler(this.RCForm_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.ListBox LstChickens;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

