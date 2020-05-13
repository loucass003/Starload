using Lidgren.Network;
using Starload.UI.Menus;
using StarloadCommons.Network;
using StarloadCommons.Network.Login;
using StarloadCommons.Network.Login.Client;
using StarloadCommons.Network.Login.Server;
using UI.Menus;

namespace Starload.Network
{
    public class NetHandlerLoginClient : INetHandlerLoginClient
    {
        private NetworkClient _system;
        private NetworkConnection _connection;

        public NetHandlerLoginClient(NetworkSystem system, NetworkConnection connection)
        {
            _system = (NetworkClient)system;
            _connection = connection;
        }
        
        public void HandleLoginSuccess(SPacketLoginSuccess packetIn)
        {
            throw new System.NotImplementedException();
        }

        public void OnStatusChange(NetConnectionStatus status)
        {
            if (status == NetConnectionStatus.InitiatedConnect)
            {
                StatusMenu statusMenu = GameManager.Instance.menus.SelectMenu<StatusMenu>(1);
                statusMenu.SetStatus("Connecting....", "");
                statusMenu.SetAction("Cancel", () =>
                {
                    _system.Client.Disconnect("MANUAL_DISCONNECT");
                    GameManager.Instance.menus.SelectMenu<UIMenu>(0);
                });
            }

            if (status == NetConnectionStatus.Connected)
            {
                _connection.SendPacket(new CPacketLoginStart(_system.Profile), NetDeliveryMethod.ReliableOrdered);
            }
        }
    }
}