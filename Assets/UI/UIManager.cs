using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private PlayerExperience playerExp;
    [SerializeField] private Slider expSlider;
    [SerializeField] private TMP_Text levelText;
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
    private void OnEnable()
    {
        if (playerExp != null)
            playerExp.OnExperienceChanged += UpdateExperienceUI;
        if (playerExp == null)
            return;
        expSlider.value = playerExp.CurrentExp;
        levelText.text = "LEVEL : " + playerExp.Level;
    }
    private void OnDisable()
    {
        if (playerExp != null)
            playerExp.OnExperienceChanged -= UpdateExperienceUI;
    }
}
