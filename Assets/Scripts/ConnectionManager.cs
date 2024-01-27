using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine.SceneManagement;

public class ConnectionManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField ipText;
    public TMP_InputField portText;

    NetworkManager m_NetworkManager;
    private UnityTransport m_Transport;

    string m_PortString = "7777";
    string m_ConnectAddress = "127.0.0.1";
    //string ipAuxiliar = "127.0.0.1";

    private void Awake()
    {
        m_NetworkManager = GetComponent<NetworkManager>();
        m_Transport = GetComponent<UnityTransport>();
    }
    void Start()
    {
        ipText.text = "127.0.0.1";
    }

    public void StartClient()
    {
        getConnectionData();
        this.m_NetworkManager.StartClient();
    }

    public void StartHost()
    {
        Debug.Log("Should start host");
        getConnectionData();
        this.m_NetworkManager.StartHost();
        m_NetworkManager.SceneManager.LoadScene("WaitingScene", LoadSceneMode.Single);
    }

    public void getConnectionData()
    {
        m_PortString = this.portText.text.ToString();
        m_ConnectAddress = (string)this.ipText.text.ToString().Trim();
        m_Transport.ConnectionData.ServerListenAddress = "0.0.0.0";

        if (ushort.TryParse(m_PortString, out ushort port))
        {
            m_Transport.SetConnectionData(m_ConnectAddress, port);
        }
        else
        {
            m_Transport.SetConnectionData(m_ConnectAddress, 7777);
        }
    }
}
