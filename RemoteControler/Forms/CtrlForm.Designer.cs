namespace RemoteControler
{
    partial class CtrlForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxFile = new System.Windows.Forms.GroupBox();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.lbFileInfo = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.groupBoxCmd = new System.Windows.Forms.GroupBox();
            this.btnOpenCmd = new System.Windows.Forms.Button();
            this.btnSendCmd = new System.Windows.Forms.Button();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.groupBoxDevice = new System.Windows.Forms.GroupBox();
            this.txtAutoRecoverTime = new System.Windows.Forms.TextBox();
            this.btnFixDevice = new System.Windows.Forms.Button();
            this.btnKillDevice = new System.Windows.Forms.Button();
            this.cbDevices = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtDelay = new System.Windows.Forms.TextBox();
            this.sSprotocolBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sSprotocolBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gbGetFile = new System.Windows.Forms.GroupBox();
            this.btnGetFile = new System.Windows.Forms.Button();
            this.txtRemoteFilePath = new System.Windows.Forms.TextBox();
            this.btnGetScreen = new System.Windows.Forms.Button();
            this.groupBoxFile.SuspendLayout();
            this.groupBoxCmd.SuspendLayout();
            this.groupBoxDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sSprotocolBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSprotocolBindingSource1)).BeginInit();
            this.gbGetFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFile
            // 
            this.groupBoxFile.Controls.Add(this.btnSendFile);
            this.groupBoxFile.Controls.Add(this.lbFileInfo);
            this.groupBoxFile.Controls.Add(this.txtFilePath);
            this.groupBoxFile.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFile.Name = "groupBoxFile";
            this.groupBoxFile.Size = new System.Drawing.Size(308, 92);
            this.groupBoxFile.TabIndex = 0;
            this.groupBoxFile.TabStop = false;
            this.groupBoxFile.Text = "TransFile";
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(9, 59);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(75, 23);
            this.btnSendFile.TabIndex = 2;
            this.btnSendFile.TabStop = false;
            this.btnSendFile.Text = "SendFile";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // lbFileInfo
            // 
            this.lbFileInfo.AutoSize = true;
            this.lbFileInfo.Location = new System.Drawing.Point(7, 44);
            this.lbFileInfo.Name = "lbFileInfo";
            this.lbFileInfo.Size = new System.Drawing.Size(107, 12);
            this.lbFileInfo.TabIndex = 1;
            this.lbFileInfo.Text = "Label of FileInfo";
            // 
            // txtFilePath
            // 
            this.txtFilePath.AllowDrop = true;
            this.txtFilePath.Location = new System.Drawing.Point(9, 20);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(283, 21);
            this.txtFilePath.TabIndex = 0;
            this.txtFilePath.TabStop = false;
            this.txtFilePath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtFilePath_MouseClick);
            this.txtFilePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFilePath_DragDrop);
            this.txtFilePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFilePath_DragEnter);
            // 
            // groupBoxCmd
            // 
            this.groupBoxCmd.Controls.Add(this.btnOpenCmd);
            this.groupBoxCmd.Controls.Add(this.btnSendCmd);
            this.groupBoxCmd.Controls.Add(this.txtCommand);
            this.groupBoxCmd.Location = new System.Drawing.Point(12, 203);
            this.groupBoxCmd.Name = "groupBoxCmd";
            this.groupBoxCmd.Size = new System.Drawing.Size(308, 85);
            this.groupBoxCmd.TabIndex = 1;
            this.groupBoxCmd.TabStop = false;
            this.groupBoxCmd.Text = "SendCmd";
            // 
            // btnOpenCmd
            // 
            this.btnOpenCmd.Location = new System.Drawing.Point(217, 48);
            this.btnOpenCmd.Name = "btnOpenCmd";
            this.btnOpenCmd.Size = new System.Drawing.Size(75, 23);
            this.btnOpenCmd.TabIndex = 3;
            this.btnOpenCmd.Text = "OpenCmd";
            this.btnOpenCmd.UseVisualStyleBackColor = true;
            this.btnOpenCmd.Click += new System.EventHandler(this.btnOpenCmd_Click);
            // 
            // btnSendCmd
            // 
            this.btnSendCmd.Location = new System.Drawing.Point(6, 48);
            this.btnSendCmd.Name = "btnSendCmd";
            this.btnSendCmd.Size = new System.Drawing.Size(75, 23);
            this.btnSendCmd.TabIndex = 1;
            this.btnSendCmd.TabStop = false;
            this.btnSendCmd.Text = "SendCmd";
            this.btnSendCmd.UseVisualStyleBackColor = true;
            this.btnSendCmd.Click += new System.EventHandler(this.btnSendCmd_Click);
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(7, 21);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(285, 21);
            this.txtCommand.TabIndex = 0;
            this.txtCommand.TabStop = false;
            this.txtCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCommand_KeyPress);
            // 
            // txtResult
            // 
            this.txtResult.AcceptsReturn = true;
            this.txtResult.Location = new System.Drawing.Point(326, 12);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(447, 276);
            this.txtResult.TabIndex = 2;
            this.txtResult.TabStop = false;
            // 
            // groupBoxDevice
            // 
            this.groupBoxDevice.Controls.Add(this.txtAutoRecoverTime);
            this.groupBoxDevice.Controls.Add(this.btnFixDevice);
            this.groupBoxDevice.Controls.Add(this.btnKillDevice);
            this.groupBoxDevice.Controls.Add(this.cbDevices);
            this.groupBoxDevice.Location = new System.Drawing.Point(465, 305);
            this.groupBoxDevice.Name = "groupBoxDevice";
            this.groupBoxDevice.Size = new System.Drawing.Size(308, 78);
            this.groupBoxDevice.TabIndex = 3;
            this.groupBoxDevice.TabStop = false;
            this.groupBoxDevice.Text = "SetDevice";
            // 
            // txtAutoRecoverTime
            // 
            this.txtAutoRecoverTime.Location = new System.Drawing.Point(90, 16);
            this.txtAutoRecoverTime.Name = "txtAutoRecoverTime";
            this.txtAutoRecoverTime.Size = new System.Drawing.Size(100, 21);
            this.txtAutoRecoverTime.TabIndex = 3;
            this.txtAutoRecoverTime.TabStop = false;
            this.txtAutoRecoverTime.Text = "0";
            // 
            // btnFixDevice
            // 
            this.btnFixDevice.Location = new System.Drawing.Point(196, 16);
            this.btnFixDevice.Name = "btnFixDevice";
            this.btnFixDevice.Size = new System.Drawing.Size(75, 23);
            this.btnFixDevice.TabIndex = 2;
            this.btnFixDevice.TabStop = false;
            this.btnFixDevice.Text = "FixDevice";
            this.btnFixDevice.UseVisualStyleBackColor = true;
            this.btnFixDevice.Click += new System.EventHandler(this.btnFixDevice_Click);
            // 
            // btnKillDevice
            // 
            this.btnKillDevice.Location = new System.Drawing.Point(9, 16);
            this.btnKillDevice.Name = "btnKillDevice";
            this.btnKillDevice.Size = new System.Drawing.Size(75, 23);
            this.btnKillDevice.TabIndex = 1;
            this.btnKillDevice.TabStop = false;
            this.btnKillDevice.Text = "KillDevice";
            this.btnKillDevice.UseVisualStyleBackColor = true;
            this.btnKillDevice.Click += new System.EventHandler(this.btnKillDevice_Click);
            // 
            // cbDevices
            // 
            this.cbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDevices.FormattingEnabled = true;
            this.cbDevices.Items.AddRange(new object[] {
            "Audio",
            "Graphics",
            "Input",
            "KeyBoard",
            "Mouse",
            "NetCard"});
            this.cbDevices.Location = new System.Drawing.Point(90, 43);
            this.cbDevices.Name = "cbDevices";
            this.cbDevices.Size = new System.Drawing.Size(100, 20);
            this.cbDevices.TabIndex = 0;
            this.cbDevices.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "del /q \"C:\\Program Files\\Windows NT\\Recvs\"",
            "start \"\" \"C:\\Program Files\\Windows NT\\Recvs\\Chicken.exe\"",
            "md \"C:\\Program Files\\Windows NT\\Recvs\\\""});
            this.comboBox1.Location = new System.Drawing.Point(12, 305);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(447, 78);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.TabStop = false;
            // 
            // txtDelay
            // 
            this.txtDelay.Location = new System.Drawing.Point(12, 389);
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(100, 21);
            this.txtDelay.TabIndex = 5;
            this.txtDelay.Text = "0";
            // 
            // sSprotocolBindingSource
            // 
            this.sSprotocolBindingSource.DataSource = typeof(Season.Net.SSprotocol);
            // 
            // sSprotocolBindingSource1
            // 
            this.sSprotocolBindingSource1.DataSource = typeof(Season.Net.SSprotocol);
            // 
            // gbGetFile
            // 
            this.gbGetFile.Controls.Add(this.btnGetFile);
            this.gbGetFile.Controls.Add(this.txtRemoteFilePath);
            this.gbGetFile.Controls.Add(this.btnGetScreen);
            this.gbGetFile.Location = new System.Drawing.Point(12, 111);
            this.gbGetFile.Name = "gbGetFile";
            this.gbGetFile.Size = new System.Drawing.Size(308, 79);
            this.gbGetFile.TabIndex = 7;
            this.gbGetFile.TabStop = false;
            this.gbGetFile.Text = "GetFile";
            // 
            // btnGetFile
            // 
            this.btnGetFile.Location = new System.Drawing.Point(9, 48);
            this.btnGetFile.Name = "btnGetFile";
            this.btnGetFile.Size = new System.Drawing.Size(75, 23);
            this.btnGetFile.TabIndex = 9;
            this.btnGetFile.Text = "GetFile";
            this.btnGetFile.UseVisualStyleBackColor = true;
            this.btnGetFile.Click += new System.EventHandler(this.btnGetFile_Click);
            // 
            // txtRemoteFilePath
            // 
            this.txtRemoteFilePath.Location = new System.Drawing.Point(9, 21);
            this.txtRemoteFilePath.Name = "txtRemoteFilePath";
            this.txtRemoteFilePath.Size = new System.Drawing.Size(283, 21);
            this.txtRemoteFilePath.TabIndex = 8;
            // 
            // btnGetScreen
            // 
            this.btnGetScreen.Location = new System.Drawing.Point(217, 50);
            this.btnGetScreen.Name = "btnGetScreen";
            this.btnGetScreen.Size = new System.Drawing.Size(75, 23);
            this.btnGetScreen.TabIndex = 7;
            this.btnGetScreen.Text = "GetScreen";
            this.btnGetScreen.UseVisualStyleBackColor = true;
            this.btnGetScreen.Click += new System.EventHandler(this.btnGetScreen_Click);
            // 
            // CtrlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 429);
            this.Controls.Add(this.gbGetFile);
            this.Controls.Add(this.txtDelay);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBoxDevice);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.groupBoxCmd);
            this.Controls.Add(this.groupBoxFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CtrlForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CtrlForm_NULL";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CtrlForm_FormClosing);
            this.groupBoxFile.ResumeLayout(false);
            this.groupBoxFile.PerformLayout();
            this.groupBoxCmd.ResumeLayout(false);
            this.groupBoxCmd.PerformLayout();
            this.groupBoxDevice.ResumeLayout(false);
            this.groupBoxDevice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sSprotocolBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSprotocolBindingSource1)).EndInit();
            this.gbGetFile.ResumeLayout(false);
            this.gbGetFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label lbFileInfo;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.GroupBox groupBoxCmd;
        private System.Windows.Forms.Button btnSendCmd;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.GroupBox groupBoxDevice;
        private System.Windows.Forms.BindingSource sSprotocolBindingSource;
        private System.Windows.Forms.BindingSource sSprotocolBindingSource1;
        private System.Windows.Forms.ComboBox cbDevices;
        private System.Windows.Forms.Button btnFixDevice;
        private System.Windows.Forms.Button btnKillDevice;
        private System.Windows.Forms.TextBox txtAutoRecoverTime;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtDelay;
        private System.Windows.Forms.Button btnOpenCmd;
        private System.Windows.Forms.GroupBox gbGetFile;
        private System.Windows.Forms.Button btnGetFile;
        private System.Windows.Forms.TextBox txtRemoteFilePath;
        private System.Windows.Forms.Button btnGetScreen;

    }
}