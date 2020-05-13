using Starload.Network;
using Starload.UI.Menus;
using UnityEngine;

namespace Starload
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        public NetworkClient network;
        
        public Menus menus;
        
        public void Awake()
        {
            if (Instance != null)
                Destroy(this.gameObject);
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
            network = NetworkClient.Create();
            Debug.Log("GameManagerInit");
            // network.Connect("127.0.0.1", 4242);
        }

        public void Update()
        {
            network.Update();
        }
    }
}