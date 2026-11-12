using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    //클래스 가져오기
    [SerializeField] private PlayerHealth playerHealth; //플레이어 사망 확인을 위해서 사용
    [SerializeField] private PlayerExperience playerExperience;
    [SerializeField] private UIManager UIManager;

    //현재 게임 상태
    private GameState currentState = GameState.Playing;

    //레벨업 횟수 저장
    private int pendingLevelUp = 0;


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
        if (playerHealth != null)
            playerHealth.OnPlayerDead += HandlePlayerDeath;
        if (playerExperience != null)
            playerExperience.OnLevelUp += HandleLevelUp;
    }
    private void HandlePlayerDeath()
    {
        if (currentState == GameState.GameOver) return;
        currentState = GameState.GameOver;
        Time.timeScale = 0f;
        UIManager.ShowGameOver();
    }
    private void HandleLevelUp(int level)
    {
        pendingLevelUp++;
        if (currentState != GameState.Playing)
            return;
        currentState = GameState.LevelUp;
        Time.timeScale = 0f;
        UIManager.ShowUpgradePanel();
    }
    public void ResumeGame()
    {
        if (currentState != GameState.LevelUp)
            return;
        pendingLevelUp--;
        if (pendingLevelUp > 0)
        {
            UIManager.ShowUpgradePanel();
            return;
        }
        currentState = GameState.Playing;
        Time.timeScale = 1f;
    }
    private void OnDestroy()
    {
        if (playerHealth != null)
            playerHealth.OnPlayerDead -= HandlePlayerDeath;
        if (playerExperience != null)
            playerExperience.OnLevelUp -= HandleLevelUp;
    }
}
