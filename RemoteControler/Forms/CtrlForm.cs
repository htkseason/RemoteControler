using Season.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RemoteControler
{
    public partial class CtrlForm : Form
    {
        public ClientBean cb;
        public SSprotocolServer server;
        public const string DEFAULT_FILERECV_PATH = @"C:\Program Files\Windows NT\Recvs\";
        public CtrlForm()
        {
            InitializeComponent();
        }

        public void FeedBack(string result)
        {
            txtResult.AppendText(result.Substring(7));
        }


        public void LoadClient(ClientBean cb, SSprotocolServer server, String title)
        {
            txtResult.Clear();
            this.cb = cb;
            this.server = server;
            this.Text = title;
        }



        private void btnGetFile_Click(object sender, EventArgs e)
        {
            if (txtRemoteFilePath.TextLength == 0)
            {
                MessageBox.Show("Choose File First");
                return;
            }
            server.Send(cb, SSprotocol.makeGetFileMessage(txtRemoteFilePath.Text));
        }
        private void btnGetScreen_Click(object sender, EventArgs e)
        {
            server.Send(cb, SSprotocol.makeGetScreenMessage());
        }
        private void btnSendFile_Click(object sender, EventArgs e)
        {

            if (txtFilePath.TextLength == 0)
            {
                MessageBox.Show("Choose File First");
                return;
            }
            btnSendFile.Enabled = false;

            try { sendFile(txtFilePath.Text, null); }
            catch { MessageBox.Show("Send File Fail"); }

            txtFilePath.Clear();
            lbFileInfo.ResetText();
            btnSendFile.Enabled = true;
        }
        private void btnOpenCmd_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Sure To Open A New Cmd?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                byte[] msgToSend = SSprotocol.makeOpencmdMessage();
                server.Send(cb, msgToSend);
            }

        }
        private void btnSendCmd_Click(object sender, EventArgs e)
        {
            if (txtCommand.Text.Length == 0)
            {
                MessageBox.Show("Input Command First");
                return;
            }
            new Thread(SendCmdCallBack).Start(new string[] { txtDelay.Text, txtCommand.Text });


        }
        private void btnKillDevice_Click(object sender, EventArgs e)
        {
            if (getDeviceGUID(cbDevices.Text) == null)
            {
                MessageBox.Show("Choose Device First");
                return;
            }
            try { new Thread(SetDeviceCallBack).Start(new string[] { txtDelay.Text, cbDevices.Text, txtAutoRecoverTime.Text, "false" }); }
            catch { }

        }
        private void btnFixDevice_Click(object sender, EventArgs e)
        {
            if (getDeviceGUID(cbDevices.Text) == null)
            {
                MessageBox.Show("Choose Device First");
                return;
            }
            try { new Thread(SetDeviceCallBack).Start(new string[] { txtDelay.Text, cbDevices.Text, txtAutoRecoverTime.Text, "true" }); }
            catch { }
        }







        #region otherevents
        private void txtCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSendCmd_Click(null, null);
                txtCommand.Clear();
            }
        }
        private void txtFilePath_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }
        private void CtrlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        private void txtFilePath_DragDrop(object sender, DragEventArgs e)
        {
            string filePath = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            txtFilePath.Text = filePath;
            txtFilePath.SelectionStart = txtFilePath.TextLength;
            try
            {
                FileInfo fi = new FileInfo(filePath);
                lbFileInfo.Text = fi.Name + " " + fi.Length + "Bytes";
            }
            catch
            {
                txtFilePath.Text = "";
            }
        }
        private void txtFilePath_MouseClick(object sender, MouseEventArgs e)
        {
            txtFilePath.SelectAll();
        }

        #endregion

        #region callbacks
        void SetDeviceCallBack(object param)
        {
            string[] infos = (string[])param;
            int delay = StringToInt(infos[0]);
            string guid = getDeviceGUID(infos[1]);
            int autoRecoverTime = StringToInt(infos[2]);
            bool state = Convert.ToBoolean(infos[3]);

            if (guid == null)
                return;
            Thread.Sleep(delay);
            setDevice(guid, state, autoRecoverTime);
        }
        void SendCmdCallBack(object param)
        {
            string[] infos = (string[])param;
            int delay = StringToInt(infos[0]);
            Thread.Sleep(delay);
            byte[] msgToSend = SSprotocol.makeSysMessage(infos[1]);
            server.Send(cb, msgToSend);
        }
        #endregion

        #region functions
        private string getDeviceGUID(string deviceName)
        {
            if ("NetCard".CompareTo(deviceName) == 0)
                return SSprotocol.GUID_NetCardClass;
            if ("Audio".CompareTo(deviceName) == 0)
                return SSprotocol.GUID_AudioClass;
            if ("Input".CompareTo(deviceName) == 0)
                return SSprotocol.GUID_InputClass;
            if ("Mouse".CompareTo(deviceName) == 0)
                return SSprotocol.GUID_MouseClass;
            if ("KeyBoard".CompareTo(deviceName) == 0)
                return SSprotocol.GUID_KeyBoardClass;
            if ("Graphics".CompareTo(deviceName) == 0)
                return SSprotocol.GUID_GraphicsClass;
            return null;
        }
        private int StringToInt(string str)
        {
            try { return Convert.ToInt32(str); }
            catch { return 0; }
        }
        private void setDevice(string guid, bool state, int autoRecoverTime)
        {
            if (guid.CompareTo(SSprotocol.GUID_NetCardClass) == 0 && autoRecoverTime == 0)
                autoRecoverTime = 1;
            server.Send(cb, SSprotocol.makeDeviceMessage(state, guid, autoRecoverTime));
        }
        private void sendFile(string filePath, string targetFileName)
        {
            FileInfo fi = new FileInfo(filePath); ;

            if (targetFileName == null)
                targetFileName = DEFAULT_FILERECV_PATH + fi.Name;

            int filePos = 0;
            int fileSize = (int)fi.Length;
            while (filePos < fileSize)
            {
                byte[] msgtosend;
                if ((fileSize - filePos) > SSprotocol.FILE_MSG_MAX_LEN)
                {
                    msgtosend = SSprotocol.makeFileMessage(filePath, targetFileName, filePos, SSprotocol.FILE_MSG_MAX_LEN);
                    filePos += SSprotocol.FILE_MSG_MAX_LEN;
                }
                else
                {
                    msgtosend = SSprotocol.makeFileMessage(filePath, targetFileName, filePos, fileSize - filePos);
                    filePos = fileSize;
                }

                server.Send(cb, msgtosend);

            }
        }

        #endregion








    }
}
