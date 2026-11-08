using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private PlayerExperience playerExp;
    [SerializeField] private Slider expSlider;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text timeText;
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
    private void UpdateExperienceUI()
    {
        expSlider.value = playerExp.CurrentExp;
        levelText.text = "LEVEL : " + playerExp.Level;
    }
    private void UpdateTimeText(float time)
    {
        int min = Mathf.FloorToInt(time / 60);
        int sec = Mathf.FloorToInt(time % 60);
        timeText.text = $"{min:00}:{sec:00}";
    }
    private void OnEnable()
    {
        if (gameManager != null)
            gameManager.OnSurvivalTimeChanged += UpdateTimeText;
        if (playerExp != null)
            playerExp.OnExperienceChanged += UpdateExperienceUI;

        if (playerExp != null)
        {
            expSlider.value = playerExp.CurrentExp;
            levelText.text = "LEVEL : " + playerExp.Level;
        }
        if (gameManager != null)
        {
            timeText.text = "00:00";
        }
    }
    private void OnDisable()
    {
        if (playerExp != null)
            playerExp.OnExperienceChanged -= UpdateExperienceUI;
        if (gameManager != null)
            gameManager.OnSurvivalTimeChanged -= UpdateTimeText;
    }
}
