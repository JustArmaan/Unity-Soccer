using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int playerScore = 0;
    public int opponentScore = 0;
    
    public GameObject ball;
    public Vector3 ballStartPosition = new Vector3(0f, 0.5f, 0f);
    
    public TextMeshProUGUI scoreboardText;
    
    private bool isResetting = false;
    
    void Start()
    {
        if (scoreboardText == null)
        {
            scoreboardText = GameObject.Find("ScoreboardText").GetComponent<TextMeshProUGUI>();
        }
        
        UpdateScoreboard();
    }
    
    public void AddPlayerScore()
    {
        if (!isResetting)
        {
            isResetting = true;
            playerScore++;
            Debug.Log("Player score is now: " + playerScore);
            UpdateScoreboard();
            Invoke("ResetBallWithDelay", 1.0f); 
        }
    }
    
    public void AddOpponentScore()
    {
        if (!isResetting)
        {
            isResetting = true;
            opponentScore++;
            Debug.Log("Opponent score is now: " + opponentScore);
            UpdateScoreboard();
            Invoke("ResetBallWithDelay", 1.0f); 
        }
    }
    
    private void ResetBallWithDelay()
    {
        ResetBall();
        isResetting = false; 
    }
    
    private void UpdateScoreboard()
    {
        if (scoreboardText != null)
        {
            scoreboardText.text = $"Player: {playerScore} - Opponent: {opponentScore}";
        }
    }
    
    public void ResetBall()
    {
        if (ball != null)
        {
            ball.transform.position = ballStartPosition;
            Rigidbody ballRb = ball.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                ballRb.linearVelocity = Vector3.zero;
                ballRb.angularVelocity = Vector3.zero;
            }
        }
    }
}