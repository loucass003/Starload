using Starload;
using Starload.UI.Menus;
using StarloadCommons.Network;
using UnityEngine;
using UnityEngine.UI;

namespace Starload.UI
{
    public class ConnectMenu : UIMenu
    {
        public InputField hostField;
        public InputField playerNameField;
        
        public void Connect()
        {
            if (string.IsNullOrEmpty(hostField.text) || string.IsNullOrEmpty(playerNameField.text))
                return;
            Debug.Log("Connect button pressed host: " + hostField.text);
            GameManager.Instance.network.Profile = new UserProfile();
            GameManager.Instance.network.Profile.name = playerNameField.text;
            GameManager.Instance.network.Connect(hostField.text, 4242);
        }
    }
}
