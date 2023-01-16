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
    public TMP_InputField inputNombre;
    public TMP_InputField inputIP;
    public TMP_InputField inputMensaje;
    public ChatManager chatmanager;

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
}
