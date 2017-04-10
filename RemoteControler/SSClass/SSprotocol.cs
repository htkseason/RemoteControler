using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Season.Net
{
    static class SSprotocol
    {
        public const string GUID_NetCardClass = "{4d36e972-e325-11ce-bfc1-08002be10318}";
        public const string GUID_KeyBoardClass = "{4d36e96b-e325-11ce-bfc1-08002be10318}";
        public const string GUID_MouseClass = "{4d36e96f-e325-11ce-bfc1-08002be10318}";
        public const string GUID_GraphicsClass = "{4d36e968-e325-11ce-bfc1-08002be10318}";
        public const string GUID_AudioClass = "{c166523c-fe0c-4a94-a586-f1a80cfbbf3e}";
        public const string GUID_InputClass = "{745a17a0-74d3-11d0-b6fe-00a0c90f57da}";


        public const int CMD_FILE = 1;
        public const int CMD_SYSTEM = 2;
        public const int CMD_DEVICE = 3;
        public const int CMD_OPENCMD = 4;
        public const int CMD_GETFILE = 5;
        public const int CMD_GETSCREEN = 6;
        public const uint CMD_BEAT = 0xFFFFFFFF;

        public const int FILE_MSG_MAX_LEN = (64 * 1024);


        public static byte[] makeOpencmdMessage()
        {
            int p = 0;
            byte[] tmp;
            byte[] result = new byte[sizeof(int)];

            tmp = BitConverter.GetBytes(CMD_OPENCMD);
            Array.Copy(tmp, 0, result, p, tmp.Length);
            p += sizeof(int);

            return result;
        }

        public static byte[] makeDeviceMessage(bool state,string GUID, int autoRecover)
        {
            int p = 0;
            byte[] tmp;
            byte[] result = new byte[sizeof(int) + sizeof(bool) + sizeof(int) + 64];

            tmp = BitConverter.GetBytes(CMD_DEVICE);
            Array.Copy(tmp, 0, result, p, tmp.Length);
            p += sizeof(int);

            tmp = BitConverter.GetBytes(state);
            Array.Copy(tmp, 0, result, p, tmp.Length);
            p += sizeof(bool);

            tmp = BitConverter.GetBytes(autoRecover);
            Array.Copy(tmp, 0, result, p, tmp.Length);
            p += sizeof(int);

            tmp = Encoding.Default.GetBytes(GUID);
            Array.Copy(tmp, 0, result, p, tmp.Length);
            p += 64;

            return result;
        }

        public static byte[] makeSysMessage(string command)
        {
            int p = 0;
            byte[] tmp;
            byte[] result = new byte[sizeof(int) + 255];

            tmp = BitConverter.GetBytes(CMD_SYSTEM);
            Array.Copy(tmp, 0, result, p, tmp.Length);
            p += sizeof(int);

            tmp = Encoding.Default.GetBytes(command);
            Array.Copy(tmp, 0, result, p, tmp.Length);
            p += 255;

            return result;

        }
        public static byte[] makeGetFileMessage(string remoteFilePath)
        {
            int p = 0;
            byte[] tmp;
            byte[] result = new byte[sizeof(int) + 255];

            tmp = BitConverter.GetBytes(CMD_GETFILE);
            Array.Copy(tmp, 0, result, p, tmp.Length);
            p += sizeof(int);

            tmp = Encoding.Default.GetBytes(remoteFilePath);
            Array.Copy(tmp, 0, result, p, tmp.Length);
            p += 255;

            return result;
        }

        public static byte[] makeGetScreenMessage()
        {
            int p = 0;
            byte[] tmp;
            byte[] result = new byte[sizeof(int)];

            tmp = BitConverter.GetBytes(CMD_GETSCREEN);
            Array.Copy(tmp, 0, result, p, tmp.Length);
            p += sizeof(int);

            return result;
        }

        public static byte[] makeFileMessage(string filePath, string targetFileName, int offset, int counts)
        {

            FileStream file = new FileStream(filePath, FileMode.Open);
            byte[] msgData = new byte[counts];
            file.Seek(offset, SeekOrigin.Begin);
            file.Read(msgData, 0, counts);
            file.Close();

            int p = 0;
            byte[] tmp;
            byte[] result = new byte[sizeof(int) + 255 + sizeof(int) + sizeof(int) + msgData.Length];

            tmp = BitConverter.GetBytes(CMD_FILE);
            Array.Copy(tmp, 0, result, p, tmp.Length);
            p += sizeof(int);

            tmp = Encoding.Default.GetBytes(targetFileName);
            Array.Copy(tmp, 0, result, p, tmp.Length);
            p += 255;

            tmp = BitConverter.GetBytes(offset);
            Array.Copy(tmp, 0, result, p, tmp.Length);
            p += sizeof(int);

            tmp = BitConverter.GetBytes(msgData.Length);
            Array.Copy(tmp, 0, result, p, tmp.Length);
            p += sizeof(int);

            tmp = msgData;
            Array.Copy(tmp, 0, result, p, tmp.Length);
            p += msgData.Length;

            return result;

        }

    }
}
