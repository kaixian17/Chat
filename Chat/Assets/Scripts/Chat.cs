using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chat : MonoBehaviour
{
    public string nombre;
    public string ip;
    public string mensaje;
    public string receivedMensaje;
    public ulong userID=0;
    public TMP_InputField inputNombre;
    public TMP_InputField inputIP;
    public TMP_InputField inputMensaje;
    public ChatManager chatmanager;
    public NetworkGameManager NGM;
    public GameObject menuInicial;
    public GameObject btnDesconectar;
    private void Start()
    {
        NGM.OnClientConnectedCallback += UpdatePlayerListClient;

        NGM.OnServerStarted += UpdatePlayerList;
    }

    private void OnDisable()
    {
        if (Unity.Netcode.NetworkManager.Singleton != null)
        {
            NGM.OnClientConnectedCallback -= UpdatePlayerListClient;

            NGM.OnServerStarted -= UpdatePlayerList;
        }
    }
    public void ReadNombreInput()
    {
        nombre = inputNombre.text;
        //Debug.Log(nombre);
    }

    public void ReadIPInput()
    {
        ip = inputIP.text;
        //Debug.Log(ip);
    }

    public void SendChatMessage()
    {
        mensaje = inputMensaje.text;
        Debug.Log(mensaje);
        chatmanager.SendChatMessageServerRPC(mensaje, nombre);
    }

    public void UpdatePlayerList()
    {
        chatmanager.UpdatePlayerListServerRPC(nombre);
    }

    public void UpdatePlayerListClient(ulong obj)
    {
        if (!NGM.IsHost)
        {
            chatmanager.UpdatePlayerListServerRPC(nombre);
            userID = obj;
        }

    }


    //Connection to server
    public void ConnectServer()
    {
        NGM.ConnectHost();
        menuInicial.SetActive(false);
        btnDesconectar.SetActive(true);

    }

    public void ConnectClient()
    {
        NGM.ConnectClient();
        menuInicial.SetActive(false);
        btnDesconectar.SetActive(true);
    }

    public void Disconnect()
    {
        NGM.Disconnect();
      
        chatmanager.RemoveUserFromListServerRPC(nombre);
        Debug.Log("Cliente desconectado");

        menuInicial.SetActive(true);
        btnDesconectar.SetActive(false);
    }

    public void RemoveUserFromList()
    {
        chatmanager.RemoveUserFromListServerRPC(nombre);
    }

}
