using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace Season.Net
{
    public class SSprotocolServer
    {

        #region events
        public delegate void OnAcceptHandler(ClientBean client);
        public event OnAcceptHandler OnAccept;
        public delegate void OnRecvHandler(ClientBean client, byte[] recvbuff);
        public event OnRecvHandler OnRecv;
        public delegate void OnDisconnectHandler(ClientBean client);
        public event OnDisconnectHandler OnDisconnect;
        #endregion

        #region defines
        public const int RECV_BUFF_SIZE = (128 * 1024);

        static byte[] HEAD = new byte[] { 0xCC, 0xBB, 0xAA };
        static byte[] TAIL = new byte[] { 0xAA, 0xBB, 0xCC };
        #endregion


        public void Start(int port, int backlog = 10)
        {
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress.Any, port));
            listener.Listen(backlog);
            listener.BeginAccept(AcceptCallBack, listener);
        }

        private byte[] packMsg(byte[] msg, int offset, int size)
        {
            byte[] packedMsg = new byte[HEAD.Length + sizeof(int) + size + TAIL.Length];
            int p = 0;
            Array.Copy(HEAD, 0, packedMsg, p, HEAD.Length);
            p += HEAD.Length;
            byte[] bSize = BitConverter.GetBytes(size);
            Array.Copy(bSize, 0, packedMsg, p, bSize.Length);
            p += bSize.Length;
            Array.Copy(msg, offset, packedMsg, p, size);
            p += size;
            Array.Copy(TAIL, 0, packedMsg, p, TAIL.Length);
            p += TAIL.Length;
            return packedMsg;
        }
        public void Send(ClientBean cb, byte[] msg, int offset, int size)
        {
            byte[] packedMsg = packMsg(msg, offset, size);
            try { cb.client.BeginSend(packedMsg, 0, packedMsg.Length, SocketFlags.None, SendCallBack, cb); }
            catch { this.close(cb); }
        }
        public void Send(ClientBean cb, byte[] msg)
        {
            this.Send(cb, msg, 0, msg.Length);
        }
        public void Send(ClientBean cb, String msg)
        {
            this.Send(cb, Encoding.Default.GetBytes(msg));
        }

        protected void AcceptCallBack(IAsyncResult iar)
        {
            Socket listener = (Socket)iar.AsyncState;
            Socket client = listener.EndAccept(iar);
            Debug.WriteLine("Accepted.");

            ClientBean cb = new ClientBean(client);
            if (OnAccept != null)
            {
                OnAccept(cb);
            }
            client.BeginReceive(cb.recvBuff, 0, RECV_BUFF_SIZE, SocketFlags.None, RecvCallBack, cb);
            listener.BeginAccept(AcceptCallBack, listener);
        }

        protected void SendCallBack(IAsyncResult iar)
        {
            ClientBean cb = (ClientBean)iar.AsyncState;
            int bytesent;
            try { bytesent = cb.client.EndSend(iar); }
            catch { bytesent = 0; }
            if (bytesent != 0)
            {
                Debug.WriteLine("Send " + bytesent);
            }
            else
            {
                Debug.WriteLine("Send Err. Bad Net.");
            }
        }


        protected byte[] findValidMsg(ClientBean cb, int bytesRecved)
        {
            cb.recvBuffOffset += bytesRecved;

            byte[] msg = cb.recvBuff;

            //check head
            if (cb.recvBuffOffset < HEAD.Length)
                return null;
            for (int i = 0; i < HEAD.Length; i++)
                if (HEAD[i] != msg[i])
                {
                    //error head
                    cb.recvBuffOffset = 0;
                    return null;
                }

            //check size
            if (cb.recvBuffOffset < HEAD.Length + sizeof(int))
                return null;
            int msgSize = BitConverter.ToInt32(msg, HEAD.Length);


            //check tail
            int expectedLen = HEAD.Length + sizeof(int) + msgSize + TAIL.Length;
            if (expectedLen > cb.recvBuffOffset)
                return null;
            for (int i = 0; i < TAIL.Length; i++)
                if (TAIL[i] != msg[HEAD.Length + sizeof(int) + msgSize + i])
                {
                    //error tail
                    cb.recvBuffOffset = 0;
                    return null;
                }


            //copy checked msg
            byte[] result;
            if (msgSize > 0)
            {
                result = new byte[msgSize];
                Array.Copy(msg, HEAD.Length + sizeof(int), result, 0, msgSize);
            }
            else
                result = null;


            //format buffer if neccessary
            if (cb.recvBuffOffset > expectedLen)
            {
                Array.Copy(msg, expectedLen, msg, 0, cb.recvBuffOffset - expectedLen);
                cb.recvBuffOffset -= expectedLen;
            }
            else
                cb.recvBuffOffset = 0;

            return result;

        }


        protected void RecvCallBack(IAsyncResult iar)
        {
            ClientBean cb = (ClientBean)iar.AsyncState;
            int bytesRecved = 0;

            try { bytesRecved = cb.client.EndReceive(iar); }
            catch { bytesRecved = 0; }


            if (bytesRecved > 0)
            {
                byte[] msg = findValidMsg(cb, bytesRecved);
                while (msg != null)
                {
                    if (OnRecv != null)
                    {
                        OnRecv(cb, msg);
                    }
                    msg = findValidMsg(cb, 0);
                }

                try { cb.client.BeginReceive(cb.recvBuff, cb.recvBuffOffset, RECV_BUFF_SIZE - cb.recvBuffOffset, SocketFlags.None, RecvCallBack, cb); }
                catch { this.close(cb); }

            }
            else
            {
                //抢救一下
                Debug.WriteLine("RECV ERR");
                if (!IsOnline(cb.client))
                {
                    this.close(cb);
                }
                else
                {
                    try { cb.client.BeginReceive(cb.recvBuff, cb.recvBuffOffset, RECV_BUFF_SIZE - cb.recvBuffOffset, SocketFlags.None, RecvCallBack, cb); }
                    catch { this.close(cb); }
                }

            }
        }



        public void close(ClientBean cb)
        {
            if (OnDisconnect != null)
            {
                OnDisconnect(cb);
            }
            cb.client.Close();
            Debug.WriteLine("Socket Closed");
        }

        private bool IsOnline(Socket client)
        {
            return !((client.Poll(1000, SelectMode.SelectRead) && (client.Available == 0)) || !client.Connected);
        }
    }
}