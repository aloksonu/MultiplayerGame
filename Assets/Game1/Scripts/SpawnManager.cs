using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, transform.position, transform.rotation);
    }
}
