using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameTextMeshProUGUI;
    private Rigidbody2D _rb;
    private float MoveSpeed = 200f;
    private float _dirX, _dirY;
    private string playerName;
    void Start()
    {
        playerName = GetComponentInParent<PhotonView>().Owner.NickName;
        playerNameTextMeshProUGUI.text = playerName;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetComponentInParent<PhotonView>().IsMine)
        {
#if UNITY_EDITOR
            _dirX = Input.GetAxis("Horizontal") * Time.deltaTime;
            _dirY = Input.GetAxis("Vertical") * Time.deltaTime;
#else
            _dirX = Input.acceleration.x*Time.deltaTime;
            _dirY = Input.acceleration.y*Time.deltaTime;
#endif

            Vector2 velocityVector = new Vector2(_dirX * MoveSpeed, _dirY * MoveSpeed);
            _rb.velocity = velocityVector;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (LevelPanel.Instance.levelName == "Receiving" && subLevelNumber == other.gameObject.GetComponent<SubLevelName>().subLevelNumber)
        if (other.gameObject.GetComponent<GoalName>().name=="One" || other.gameObject.GetComponent<GoalName>().name == "Two"
            ||other.gameObject.GetComponent<GoalName>().name == "Three" || other.gameObject.GetComponent<GoalName>().name == "Four"
            || other.gameObject.GetComponent<GoalName>().name == "Five")
        {
            other.gameObject.SetActive(false);
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        PlayerScore.Instance.UpdateScore(1);

        if (PlayerScore.Instance.GetScore() >= 3)
        {
            Debug.Log("Player Win");
            GameWinPanel.Instance.BringIn(playerName);
        }
    }

   }
