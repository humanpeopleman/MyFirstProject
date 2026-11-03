using UnityEngine;
public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerHealth pH;
    private GameState currentState = GameState.Playing;
    private void Awake()
    {
        if (pH != null)
            pH.OnPlayerDead += HandlePlayerDeath;
    }
    private void HandlePlayerDeath()
    {
        currentState = GameState.GameOver;
        Debug.Log("---게임 오버---");
    }
    private void OnDestroy()
    {
        if (pH != null)
        {
            pH.OnPlayerDead -= HandlePlayerDeath;
        }
    }
}
