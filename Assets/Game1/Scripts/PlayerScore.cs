using TMPro;
using UnityEngine;
using Utilities;

namespace Game1.Scripts
{
    public class PlayerScore : MonoSingleton<PlayerScore>
    {
        [SerializeField] private TextMeshProUGUI scoreTextMeshProUGUI;
        private int score;
        void Start()
        {
            ResetScore();
        }
        internal void ResetScore()
        {
            score = 0;
            scoreTextMeshProUGUI.text = "Score: " + score.ToString();
        }
        internal void UpdateScore(int s)
        {

            score += s;
            scoreTextMeshProUGUI.text = "Score: " + score.ToString();

        }

        internal int GetScore()
        {
            return score;
        }
    }
}
