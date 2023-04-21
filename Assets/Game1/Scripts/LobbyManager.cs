using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Button btnRoom, btnQuit;
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
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode , string messege)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
    private void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
