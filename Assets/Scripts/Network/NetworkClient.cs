using System.Collections;
using System.Collections.Generic;
using Lidgren.Network;
using Starload.UI;
using Starload.UI.Menus;
using StarloadCommons.Network;
using UI.Menus;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Starload.Network
{
    public class NetworkClient : NetworkSystem
    {
        public NetClient Client;
        private NetworkConnection _connection;
        public UserProfile Profile;
    
        public NetworkClient(NetClient client) : base(client)
        {
            Client = client;
        }

        public static NetworkClient Create()
        {
            NetPeerConfiguration configuration = new NetPeerConfiguration("Starload");
            NetClient client = new NetClient(configuration);
            client.Start();
            
            return new NetworkClient(client);
        }

        public void Connect(string host, int port)
        {
            _connection = new NetworkConnection(null);
            _connection.AddNetworkChannel(NetworkChannel.LOGIN, new NetHandlerLoginClient(this, _connection));
            Client.Connect(host, port);
        }
    
        public override NetworkConnection GetConnection(NetworkSystem system, NetIncomingMessage message)
        {
            return _connection;
        }

        public override void OnConnectionCreate(NetworkSystem system, NetConnection netConnection)
        {
            _connection.SetConnection(netConnection);
        }

        public override void OnDisconnect(NetworkSystem system, NetworkConnection connection, NetIncomingMessage message)
        {
            string reason = message.PeekString();

            if ("MANUAL_DISCONNECT".Equals(reason))
                return;
            StatusMenu statusMenu = GameManager.Instance.menus.SelectMenu<StatusMenu>(1);
            statusMenu.SetStatus("Disconnected", reason);
            statusMenu.SetAction("Main Menu", () => StatusMenu.GoToMain());
        }
        
        
    }
}
