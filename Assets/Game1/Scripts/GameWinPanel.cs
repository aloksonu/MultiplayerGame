using TMPro;
using UnityEngine;
using Utilities;
using Photon.Pun;
using UnityEngine.UI;

public class GameWinPanel : MonoBehaviourPunCallbacks
{
   // public static GameWinPanel Instance;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Button btnLeaveRoom;
    [SerializeField] private TextMeshProUGUI panelText;
    private float _fadeDuration = 0.2f;
    private int winAppearCoundown;

     void Awake()
    {
        //if(Instance==null)
        //Instance = this;
    }
    void Start()
    {
        btnLeaveRoom.onClick.AddListener(OnLeavePressed);
        winAppearCoundown = 0;
        _canvas.transform.gameObject.SetActive(false);
    }
    internal void BringIn(string name)
    {
         panelText.text = name + "Won!";
        _canvas.transform.gameObject.SetActive(true);
    }
    internal void BringOut()
    {
        _canvas.transform.gameObject.SetActive(false);
    }

    internal void OnLeavePressed()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }

    internal void UpdateWinAppearCoundown()
    {
        winAppearCoundown++;
    }
    internal int GetWinAppearCoundown()
    {
        return winAppearCoundown;
    }
}
