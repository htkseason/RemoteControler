using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Season.Net
{
    public class ClientBean
    {
        public Socket client { get; protected set; }
        internal byte[] recvBuff;
        internal int recvBuffOffset;
        public ClientBean(Socket client)
        {
            this.client = client;
            recvBuff = new byte[SSprotocolServer.RECV_BUFF_SIZE];
            recvBuffOffset = 0;
        }

    }
}
