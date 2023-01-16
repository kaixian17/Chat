using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using TMPro;

public class ChatManager : NetworkBehaviour
{
    public string text;
    public TMP_Text Chat;

    [ServerRpc(RequireOwnership = false)]
    public void SendChatMessageServerRPC(string mensajeServer,string userServer)
    {
        SendChatMessageClientRPC(mensajeServer, userServer);
    }

    [ClientRpc]
    public void SendChatMessageClientRPC(string mensajeClient, string userClient)
    {
        text=text + userClient+ ": " + mensajeClient + "\n";
        Chat.text = text;
    }
}
