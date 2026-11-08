using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerHealth pH; //플레이어 사망 확인을 위해서 사용

    private GameState currentState = GameState.Playing; //현재 게임 상태

    [SerializeField] private UIManager uIManager;

    private float checkTime = 1f;
    private float survivalTime = 0;
    public float SurvivalTime => survivalTime;
    public event Action<float> OnSurvivalTimeChanged;
    private void Update()
    {
        if (currentState == GameState.Playing)
        {
            survivalTime += Time.deltaTime;
            if (survivalTime >= checkTime)
            {
                checkTime += 1;
                OnSurvivalTimeChanged?.Invoke(survivalTime);
            }
        }
    }
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
