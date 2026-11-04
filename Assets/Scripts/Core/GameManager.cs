using UnityEngine;
public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerHealth pH;
    private GameState currentState = GameState.Playing;
    [SerializeField] private UIManager uIManager;
    private void Awake()
    {
        if (pH != null)
            pH.OnPlayerDead += HandlePlayerDeath;
    }
    private void HandlePlayerDeath()
    {
        if (currentState == GameState.GameOver) return;
        currentState = GameState.GameOver;
        Debug.Log("---게임 오버---");
        Time.timeScale = 0f;
        uIManager.ShowGameOver();
    }
    private void OnDestroy()
    {
        if (pH != null)
        {
            pH.OnPlayerDead -= HandlePlayerDeath;
        }
    }
}
