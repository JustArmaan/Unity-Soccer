using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
 
    public bool isPlayerDefendingGoal = true;
    private GameManager gameManager;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (gameManager != null)
            {
                if (isPlayerDefendingGoal)
                {
                    gameManager.AddOpponentScore();
                    Debug.Log("Ball entered player's goal - Opponent scored!");
                }
                else
                {
                    gameManager.AddPlayerScore();
                    Debug.Log("Ball entered opponent's goal - Player scored!");
                }
            }
        }
    }
}