using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game1.Scripts
{
    public class LobbyManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Button btnRoom, btnQuit;
        [SerializeField] private TMP_InputField userNameIputFeild;
        private int minimumPlayerCount = 2;
        void Start()
        {
            btnRoom.onClick.AddListener(JoinOrCreateRoom);
            btnQuit.onClick.AddListener(OnQuitButtonPressed);
        }
        private void OnDestroy()
        {
            btnRoom.onClick.RemoveAllListeners();
            btnQuit.onClick.RemoveAllListeners();
        }

        public void JoinOrCreateRoom()
        {
            if (userNameIputFeild.text.Length > 0)
            {
                PhotonNetwork.NickName = userNameIputFeild.text;
                PhotonNetwork.JoinRandomRoom();
            }
        }
        public override void OnJoinRandomFailed(short returnCode , string messege)
        {
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });
        }

        public override void OnJoinedRoom()
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount >= minimumPlayerCount)
            {
                PhotonNetwork.LoadLevel("Game");
                //PlayerWaitingPanel.Instance.BringOut();
            }
            else
            {
                // Debug.Log("Waiting for another player to join...");
                PlayerWaitingPanel.Instance.BringIn();
            }
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount >= minimumPlayerCount)
            {
                PhotonNetwork.LoadLevel("Game");
                //PlayerWaitingPanel.Instance.BringOut();
            }
        }

        private void OnQuitButtonPressed()
        {
            Application.Quit();
        }
    }
}
