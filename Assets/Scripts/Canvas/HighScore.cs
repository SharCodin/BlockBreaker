using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText = null;
    [SerializeField] private GameManager gameManager = null;

    private void Start()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            int savedHighScore = PlayerPrefs.GetInt("highScore");
            highScoreText.text = "High Score\n" + savedHighScore;
            gameManager.SetHighScore(savedHighScore);
        }
    }

}
