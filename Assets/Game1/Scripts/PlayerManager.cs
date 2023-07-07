using Photon.Pun;
using TMPro;
using UnityEngine;

namespace Game1.Scripts
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playerNameTextMeshProUGUI;
        private Rigidbody2D _rb;
        private float MoveSpeed = 200f;
        private float _dirX, _dirY;
        private string playerName;
        public TMP_Text scoreText;
        int score;
        private GameWinPanel gameWinPanel;
        void Start()
        {
            score = 0;
            scoreText.text = score.ToString();
            playerName = GetComponentInParent<PhotonView>().Owner.NickName;
            playerNameTextMeshProUGUI.text = playerName;
            _rb = GetComponent<Rigidbody2D>();
            gameWinPanel = GameObject.FindObjectOfType<GameWinPanel>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (GetComponentInParent<PhotonView>().IsMine)
            {
                //#if UNITY_EDITOR
                //            _dirX = Input.GetAxis("Horizontal") * Time.deltaTime;
                //            _dirY = Input.GetAxis("Vertical") * Time.deltaTime;
                //#else
                //            _dirX = Input.acceleration.x*Time.deltaTime;
                //            _dirY = Input.acceleration.y*Time.deltaTime;
                //#endif

                _dirX = Input.GetAxis("Horizontal") * Time.deltaTime;
                _dirY = Input.GetAxis("Vertical") * Time.deltaTime;
                Vector2 velocityVector = new Vector2(_dirX * MoveSpeed, _dirY * MoveSpeed);
                _rb.velocity = velocityVector;

                //CheckWinCondition();
            }
       
        }
        private void Update()
        {
            if (score >= 3 && gameWinPanel.GetWinAppearCoundown() >= 5)
            {
                Debug.Log("Player Win");
                gameWinPanel.BringIn(playerName);
            }
        }
        void OnTriggerEnter2D(Collider2D other)
        { 
            if (other.gameObject.GetComponent<GoalName>().name=="One" || other.gameObject.GetComponent<GoalName>().name == "Two"
                                                                      ||other.gameObject.GetComponent<GoalName>().name == "Three" || other.gameObject.GetComponent<GoalName>().name == "Four"
                                                                      || other.gameObject.GetComponent<GoalName>().name == "Five")
            {
                // other.gameObject.SetActive(false);
                gameWinPanel.UpdateWinAppearCoundown();
                // if (GetComponentInParent<PhotonView>().IsMine)
                //  PlayerScore.Instance.UpdateScore(1);
            }
        }

        internal void CheckWinCondition()
        {
            score++;
            scoreText.text = score.ToString();

            if (score >= 3 && gameWinPanel.GetWinAppearCoundown()>=5)
            {
                Debug.Log("Player Win");
                gameWinPanel.BringIn(playerName);
            }
        }

    }
}
