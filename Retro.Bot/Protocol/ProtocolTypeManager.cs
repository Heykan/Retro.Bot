using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Protocol
{
    public static class ProtocolTypeManager
    {

        static ProtocolTypeManager()
        {
        }

        /// <summary>
        ///   Gets instance of the type defined by id.
        /// </summary>
        /// <typeparam name = "T">Type.</typeparam>
        /// <param name = "id">id.</param>
        /// <returns></returns>
        public static T GetInstance<T>(string id) where T : class
        {
            return ProtocolManager.GetTypeInstance<T>(id);
        }
    }
}
