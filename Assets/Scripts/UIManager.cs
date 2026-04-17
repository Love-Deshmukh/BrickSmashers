using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI gameOverTitleText;
    private CanvasGroup panelGroup;
    private Image panelImage;

    void Awake() { instance = this; }

    void Start()
    {
        panelGroup = gameOverPanel.GetComponent<CanvasGroup>();
        if (panelGroup == null)
            panelGroup = gameOverPanel.AddComponent<CanvasGroup>();
        panelGroup.alpha = 0f;
        gameOverPanel.SetActive(false);
        UpdateScore(0);
        UpdateLevel(1);
    }

    public void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public void UpdateLevel(int level)
    {
        if (levelText != null)
            levelText.text = "Level: " + level;
    }

    public void ShowGameOver(int finalScore)
    {
        gameOverPanel.SetActive(true);
        if (finalScoreText != null)
            finalScoreText.text = "Final Score: " + finalScore;
        if (gameOverTitleText != null)
            gameOverTitleText.text = "GAME OVER";
        StartCoroutine(AnimateGameOver());
    }

    IEnumerator AnimateGameOver()
    {
        // Fade in dark overlay
        float t = 0f;
        while (t < 1f)
        {
            t += Time.unscaledDeltaTime * 1.5f;
            panelGroup.alpha = Mathf.Clamp01(t);
            yield return null;
        }

        // Flash the title 3 times
        for (int i = 0; i < 3; i++)
        {
            if (gameOverTitleText != null)
                gameOverTitleText.gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime(0.15f);
            if (gameOverTitleText != null)
                gameOverTitleText.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(0.15f);
        }
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}