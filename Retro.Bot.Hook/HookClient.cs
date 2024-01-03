using EasyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Hook
{
    public class HookClient : MarshalByRefObject, IEntryPoint
    {
        private LocalHook _hook;
        private delegate int ConnectDelegate(IntPtr socket, IntPtr addr, int addrLen);

        [DllImport("ws2_32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int connect(IntPtr socket, IntPtr addr, int addrLen);

        [StructLayout(LayoutKind.Sequential)]
        public struct sockaddr_in
        {
            public short sin_family;
            public ushort sin_port;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] sin_addr;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] sin_zero;
        }

        // Le constructeur est utilisé pour transmettre des données du processus hôte
        public HookClient(RemoteHooking.IContext context, string channelName)
        {

        }

        // La méthode Run est appelée une fois que le hook est installé
        public void Run(RemoteHooking.IContext context, string channelName)
        {
            // Installer le hook
            _hook = LocalHook.Create(
                LocalHook.GetProcAddress("ws2_32.dll", "connect"),
                new ConnectDelegate(ConnectHook),
                this);

            // Configurer l'ACL
            _hook.ThreadACL.SetExclusiveACL(new int[] { 0 });

            // Boucle pour garder le hook actif
            try
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(100);
                }
            }
            catch
            {
                // Nettoyage en cas d'exception
                _hook.Dispose();
            }
        }

        // Méthode de Hook
        private static int ConnectHook(IntPtr socket, IntPtr addr, int addrLen)
        {
            // Ici, vous pouvez rediriger la connexion vers votre proxy MITM
            // en utilisant les informations d'adresse et de port de votre proxy.
            var proxyIP = "127.0.0.1";
            var proxyPort = 5555;
            var proxyEndpoint = new IPEndPoint(IPAddress.Parse(proxyIP), proxyPort);
            var proxyAddr = Marshal.AllocHGlobal(Marshal.SizeOf(proxyEndpoint));
            Marshal.StructureToPtr(proxyEndpoint, proxyAddr, false);

            // Par exemple :
            // var proxyIP = "127.0.0.1"; // Adresse IP de votre proxy MITM
            // var proxyPort = 5555; // Port de votre proxy MITM
            // var proxyEndpoint = new IPEndPoint(IPAddress.Parse(proxyIP), proxyPort);
            // var proxyAddr = Marshal.AllocHGlobal(Marshal.SizeOf(proxyEndpoint));
            // Marshal.StructureToPtr(proxyEndpoint, proxyAddr, false);
            // return connect(socket, proxyAddr, addrlen);
            // Pour éviter toute modification non autorisée du client Dofus,
            // nous ne ferons rien ici et appellerons simplement la fonction connect() originale.
            return connect(socket, addr, addrLen);
        }
    }
}
