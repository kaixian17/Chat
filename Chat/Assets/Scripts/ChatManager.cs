using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using TMPro;

public class ChatManager : NetworkBehaviour
{
    public string chatText;
    public string listText;
    public TMP_Text Chat;
    public TMP_Text playerList;
    private List<string> userList=new List<string>();


    [ServerRpc(RequireOwnership = false)]
    public void SendChatMessageServerRPC(string mensajeServer, string userServer)
    {
        SendChatMessageClientRPC(mensajeServer, userServer);
    }

    [ClientRpc]
    public void SendChatMessageClientRPC(string mensajeClient, string userClient)
    {
        chatText = chatText + userClient + ": " + mensajeClient + "\n";
        Chat.text = chatText;
    }

    [ServerRpc(RequireOwnership = false)]
    public void UpdatePlayerListServerRPC(string user)
    {
        listText = "";
        userList.Add(user);
        for (int i = 0; i < userList.Count; i++)
        {      
            listText += userList[i] + "\n";
            Debug.Log(i);
        }

        SendChatMessageUserJoinedClientRPC(user);
        UpdatePlayerListClientRPC(listText);
    }



    [ClientRpc]
    public void UpdatePlayerListClientRPC(string list)
    {
        playerList.text = list;
    }


    [ServerRpc(RequireOwnership = false)]

    public void RemoveUserFromListServerRPC(string user)
    {
        listText = "";
        userList.Remove(user);
        for (int i = 0; i < userList.Count; i++)
        {
            listText += userList[i] + "\n";
            Debug.Log(i);
        }

        SendChatMessageUserLeftClientRPC(user);
        UpdatePlayerListClientRPC(listText);
    }

    [ClientRpc]

    public void SendChatMessageUserJoinedClientRPC(string userClient)
    {
        chatText = chatText + userClient + " has joined the lobby.\n";
        Chat.text = chatText;
    }

    [ClientRpc]

    public void SendChatMessageUserLeftClientRPC(string userClient)
    {
        chatText = chatText + userClient + " has left the lobby.\n";
        Chat.text = chatText;
    }

    public void Salir()
    {
        Application.Quit();
    }
}

