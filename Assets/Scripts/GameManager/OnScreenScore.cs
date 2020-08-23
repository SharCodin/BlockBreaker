using TMPro;
using UnityEngine;

public class OnScreenScore : MonoBehaviour
{
    // Configs and Parameters
    private static int currentScore = 0;
    [SerializeField] private TextMeshProUGUI scoreText = null;


    private void Awake()
    {
        scoreText.text = currentScore.ToString();
    }

}