using Retro.Bot.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //private static Dictionary<uint, Type> types;
        private static Dictionary<string, Type> messages;
        //private static bool typesInitialized = false;
        private static bool messagesInitializd = false;

        #endregion

        #region Metode public

        private static Mutex mutex = new Mutex();

        /*public static T GetTypeInstance<T>(uint ProtocolId) where T : class
        {
            return getTypeInstance<T>(ProtocolId);
        }*/

        /*public static T GetTypeInstance<T>(string ProtocolHeader) where T : class
        {
            return getTypeInstance<T>(ProtocolHeader);
        }*/

        public static NetworkMessage GetPacket(byte[] data, string header)
        {
            mutex.WaitOne();
            if (!messagesInitializd)
                InitializeMessages();

            if (header != null && messages.ContainsKey(header))
            {
                NetworkMessage message = (NetworkMessage)Activator.CreateInstance(messages[header]);
                message.Data = data;
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
            string header = null;
            Regex regex = new Regex(@"^([A-Z]+)");
            Match match = regex.Match(buffer.ToReadable());
            if (match.Success)
            {
                header = match.Groups[1].Value;
            }
            return GetPacket(buffer, header);
        }

        #endregion

        #region Metode privée

        /*private static T getTypeInstance<T>(string ProtocolHeader) where T : class
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
        }*/


        /*private static void InitializeTypes()
        {
            typesInitialized = true;
            types = new Dictionary<uint, Type>();
            Assembly assembly = Assembly.GetAssembly(typeof(NetworkType));
            foreach (Type t in assembly.GetTypes())
            {
                if (t.IsSubclassOf(typeof(NetworkType)))
                {
                    FieldInfo f = t.GetField("Id");
                    if (f != null)
                    {
                        uint id = (uint)f.GetValue(t);
                        types.Add(id, t);
                    }
                }
            }
        }*/

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
}
