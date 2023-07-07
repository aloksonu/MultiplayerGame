using UnityEngine;

namespace Game1.Scripts
{
    public class GoalName : MonoBehaviour
    {
        public string name;
        private GameWinPanel gameWinPanel;
        void Start()
        {
            gameWinPanel = GameObject.FindObjectOfType<GameWinPanel>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            //gameWinPanel.UpdateWinAppearCoundown();
            other.GetComponent<PlayerManager>().CheckWinCondition();
            this.gameObject.SetActive(false);
        }

    }
}
