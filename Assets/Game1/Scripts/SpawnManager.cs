using Photon.Pun;
using UnityEngine;

namespace Game1.Scripts
{
    public class SpawnManager : MonoBehaviourPunCallbacks
    {
        public GameObject playerPrefab;
        void Start()
        {
            PhotonNetwork.Instantiate(playerPrefab.name, transform.position, transform.rotation);
        }
    }
}
