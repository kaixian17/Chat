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

    [ServerRpc(RequireOwnership = false)]
    public void UpdatePlayerListServerRPC(string user)
    {
        userList.Add(user);
        for (int i = 0; i < userList.Count; i++)
        {
            listText = listText + userList[i] + "\n";
            Debug.Log(userList.Count);
        }

        UpdatePlayerListClientRPC(listText);
    }

    [ClientRpc]
    public void SendChatMessageClientRPC(string mensajeClient, string userClient)
    {
        chatText = chatText + userClient + ": " + mensajeClient + "\n";
        Chat.text = chatText;
    }

    [ClientRpc]
    public void UpdatePlayerListClientRPC(string list)
    {
        playerList.text = list;
    }



}

