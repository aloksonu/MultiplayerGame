using Photon.Pun;
using UnityEngine;

namespace Game1.Scripts
{
    public class ConnectToServer : MonoBehaviourPunCallbacks
    {
  
        void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("We are Connected To Server");
            PhotonNetwork.JoinLobby();
        }
        public override void OnJoinedLobby()
        {
            PhotonNetwork.LoadLevel("Lobby");
        }
    }
}
