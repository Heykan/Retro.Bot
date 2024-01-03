using Retro.Bot.Extension;
using Retro.Bot.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Retro.Bot.Network
{
    public class HandlerManager
    {
        #region Declarations

        private static Dictionary<string, List<Action<NetworkMessage>>> methods;
        private static bool methodsInitializd = false;

        #endregion

        #region Metode public

        private static Mutex mutex = new Mutex();

        public static void GetHandlers(NetworkMessage msg, string header)
        {
            mutex.WaitOne();
            if (!methodsInitializd)
                InitializeHandler();

            if (methods.TryGetValue(header, out var handlers))
            {
                foreach (var handler in handlers)
                {
                    // Vérifiez si le type de 'msg' est compatible avec la méthode 'handler'
                    if (handler.Method.GetParameters().FirstOrDefault()?.ParameterType.IsInstanceOfType(msg) ?? false)
                    {
                        handler(msg);
                    }
                }
            }
            else
            {
                //Console.WriteLine("Warning, protocolManager can't find packet " + header);
                mutex.ReleaseMutex();
            }
        }

        public static void GetHandlers(NetworkMessage msg)
        {
            GetHandlers(msg, msg.MessageHeader);
        }

        #endregion

        #region Private methods

        private static void InitializeHandler()
        {
            methodsInitializd = true;
            methods = new Dictionary<string, List<Action<NetworkMessage>>>();
            Assembly assembly = Assembly.GetExecutingAssembly();

            foreach (Type t in assembly.GetTypes())
            {
                // Vérifiez si le type n'est pas abstrait et a des méthodes annotées
                if (!t.IsAbstract && t.GetMethods().Any(m => m.GetCustomAttribute<PacketReceiveAttribute>() != null))
                {
                    var instance = Activator.CreateInstance(t); // Créez une instance des gestionnaires

                    foreach (var method in t.GetMethods())
                    {
                        var attribute = method.GetCustomAttribute<PacketReceiveAttribute>();
                        if (attribute != null)
                        {
                            if (!methods.ContainsKey(attribute.Header))
                            {
                                methods[attribute.Header] = new List<Action<NetworkMessage>>();
                            }

                            methods[attribute.Header].Add((msg) =>
                            {
                                method.Invoke(instance, new object[] { msg }); // Utilisez l'instance ici
                            });
                        }
                    }
                }
            }
        }

        #endregion
    }
}
