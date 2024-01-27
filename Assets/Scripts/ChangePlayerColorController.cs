using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using System.Collections.Generic;

public class ChangePlayerColorController : NetworkBehaviour
{

    public List<GameObject> colors;

    [SerializeField]
    private Renderer playerRenderer;

    private void Start()
    {
        foreach (var color in colors)
        {
            color.GetComponent<Button>().onClick.AddListener(() => ChangeColorServerRpc(color.GetComponent<RawImage>().color));
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void ChangeColorServerRpc(Color color, ServerRpcParams serverRPCParams = default)
    {
        var clientId = serverRPCParams.Receive.SenderClientId;
        var client = NetworkManager.ConnectedClients[clientId];
        var netId = client.PlayerObject.GetComponent<PlayerNetwork>().NetworkObjectId;
        ChangeColorClientRpc(color, netId);
    }

    [ClientRpc]
    private void ChangeColorClientRpc(Color color, ulong id)
    {
        foreach (PlayerNetwork player in CustomNetworkManager.instance.players)
        {
            if (player.NetworkObjectId == id)
            {
                ChangeColor(color, player);
                return;
            }
        }
    }

    public void ChangeColor(Color color, PlayerNetwork player)
    {
        Renderer renderer = player.GetComponentInChildren<Renderer>();
        Material material = new Material(renderer.sharedMaterial);
        material.color = color;
        renderer.sharedMaterial = material;
    }

}
