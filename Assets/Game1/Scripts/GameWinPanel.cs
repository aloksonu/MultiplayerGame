using TMPro;
using UnityEngine;
using Utilities;
using Photon.Pun;
using UnityEngine.UI;

public class GameWinPanel : MonoBehaviourPunCallbacks
{
    public static GameWinPanel Instance;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button btnLeaveRoom;
    [SerializeField] private TextMeshProUGUI panelText;
    private float _fadeDuration = 0.2f;
    private int winAppearCoundown;

     void Awake()
    {
        if(Instance==null)
        Instance = this;
    }
    void Start()
    {
        btnLeaveRoom.onClick.AddListener(OnLeavePressed);
        winAppearCoundown = 0;
        _canvasGroup.UpdateState(false, 0);
    }
    internal void BringIn(string name)
    {
         panelText.text = name + "Won!";
        _canvasGroup.UpdateState(true, _fadeDuration);
    }
    internal void BringOut()
    {
        _canvasGroup.UpdateState(false, _fadeDuration);
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
