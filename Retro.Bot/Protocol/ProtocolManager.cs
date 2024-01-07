using Retro.Bot.Ankama;
using Retro.Bot.Core;
using Retro.Bot.Extension;
using Retro.Bot.IO;
using Retro.Bot.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Retro.Bot.Protocol
{
    public class ProtocolManager
    {
        #region Declarations

        private static Dictionary<string, Type> types;
        private static Dictionary<string, Type> messages;
        private static bool typesInitialized = false;
        private static bool messagesInitializd = false;

        #endregion

        #region Metode public

        private static Mutex mutex = new Mutex();

        public static T GetTypeInstance<T>(string ProtcolHeader) where T : class
        {
            return getTypeInstance<T>(ProtcolHeader);
        }

        public static NetworkMessage GetPacket(byte[] data, string header)
        {
            mutex.WaitOne();
            if (!messagesInitializd)
                InitializeMessages();

            if (header != null && messages.ContainsKey(header))
            {
                PacketReader reader = new PacketReader();
                NetworkMessage message = (NetworkMessage)Activator.CreateInstance(messages[header]);
                message.Data = data;
                reader.Read(message.Data);
                message.Deserialize(reader);
                mutex.ReleaseMutex();
                return message;
            }
            else
            {
                //Console.WriteLine("Warning, protocolManager can't find packet " + header);
                mutex.ReleaseMutex();
                return null;
            }
        }

        public static NetworkMessage GetPacket(byte[] buffer)
        {
            mutex.WaitOne();
            if (!messagesInitializd)
                InitializeMessages();

            foreach(var entry in messages)
            {
                if (buffer.ToReadable().StartsWith(entry.Key))
                {
                    PacketReader reader = new PacketReader();
                    NetworkMessage message = (NetworkMessage)Activator.CreateInstance(entry.Value);
                    message.Data = buffer;
                    reader.Read(message.Data);
                    message.Deserialize(reader);
                    mutex.ReleaseMutex();
                    return message;
                }
            }

            mutex.ReleaseMutex();
            return null;
        }

        #endregion

        #region Metode privée

        private static T getTypeInstance<T>(string ProtocolHeader) where T : class
        {
            mutex.WaitOne();
            if (!typesInitialized)
                InitializeTypes();

            if (types.ContainsKey(ProtocolHeader))
            {
                T ins = Activator.CreateInstance(types[ProtocolHeader]) as T;
                mutex.ReleaseMutex();
                return ins;
            }
            else
            {
                Console.WriteLine("Warning, protocolManager can't find type " + ProtocolHeader);
                mutex.ReleaseMutex();
                return null;
            }
        }


        private static void InitializeTypes()
        {
            /*typesInitialized = true;
            types = new Dictionary<string, Type>();
            Assembly assembly = Assembly.GetAssembly(typeof(NetworkType));
            foreach (Type t in assembly.GetTypes())
            {
                if (t.IsSubclassOf(typeof(NetworkType)))
                {
                    FieldInfo f = t.GetField("Header");
                    if (f != null)
                    {
                        string id = (string)f.GetValue(t);
                        types.Add(id, t);
                    }
                }
            }*/
        }

        private static void InitializeMessages()
        {
            messagesInitializd = true;
            messages = new Dictionary<string, Type>();
            Assembly assembly = Assembly.GetAssembly(typeof(NetworkMessage));
            foreach (Type t in assembly.GetTypes())
            {
                if (t.IsSubclassOf(typeof(NetworkMessage)))
                {
                    FieldInfo f = t.GetField("Header");
                    if (f != null)
                    {
                        string header = (string)f.GetValue(t);
                        messages.Add(header, t);
                    }
                }
            }
        }

        #endregion

    }

    public class PacketData
    {
        public object Instance { get; set; }
        public string PacketName { get; set; }
        public MethodInfo Information { get; set; }

        public PacketData(object _instance, string _packetName, MethodInfo _information)
        {
            Instance = _instance;
            PacketName = _packetName;
            Information = _information;
        }
    }
}
