using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    //클래스 가져오기
    [SerializeField] private GameManager gameManager;
    [SerializeField] private PlayerExperience playerExp;
    [SerializeField] private UpgradeManager upgradeManager;

    //UI 오브젝트 가져오기
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Slider expSlider;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private GameObject upgradePanel;
    //게임오버 패널 켜기
    public void ShowGameOver()
    {
        upgradePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }
    //재시작 버튼
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    //경험치 UI(Slider, text) 갱신
    private void UpdateExperienceUI(float exp, int level)
    {
        expSlider.value = exp;
        levelText.text = "LEVEL : " + level;
    }
    //시간 텍스트 갱신
    private void UpdateTimeText(float time)
    {
        int min = Mathf.FloorToInt(time / 60);
        int sec = Mathf.FloorToInt(time % 60);
        timeText.text = $"{min:00}:{sec:00}";
    }

    //스탯 업그레이드 패널 켜기
    public void ShowUpgradePanel()
    {
        upgradePanel.SetActive(true);
    }
    //업그레이드 버튼 클릭 시 작동. 능력치 업그레이드 기능
    public void StatUpgrade(int index)
    {
        upgradeManager.ApplyUpgrade(index);
        upgradePanel.SetActive(false);
        gameManager.ResumeGame();
    }
    private void OnEnable()
    {
        if (gameManager != null)
            gameManager.OnSurvivalTimeChanged += UpdateTimeText;
        if (playerExp != null)
        {
            playerExp.OnExperienceChanged += UpdateExperienceUI;
        }

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
        if (gameManager != null)
            gameManager.OnSurvivalTimeChanged -= UpdateTimeText;
        if (playerExp != null)
        {
            playerExp.OnExperienceChanged -= UpdateExperienceUI;
        }
    }
}
