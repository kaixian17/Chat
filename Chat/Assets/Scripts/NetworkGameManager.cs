using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using TMPro;

public class NetworkGameManager : NetworkManager
{

    public void ConnectHost()
    {
        NetworkManager.Singleton.StartHost();
    }

    public void ConnectClient()
    {
        NetworkManager.Singleton.StartClient();
    }

    public void DisconnectHost()
    {
        NetworkManager.Singleton.Shutdown();
    }

    public void DisconnectChatClient(ulong obj)
    {
        NetworkManager.Singleton.DisconnectClient(obj);
    }

}
