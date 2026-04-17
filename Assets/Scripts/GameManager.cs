using UnityEngine;

public enum GameState { Start, Playing, GameOver, Win }

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState state = GameState.Start;
    public int score = 0;

    void Awake() { instance = this; }

    void Update()
    {
        if (state == GameState.Start && Input.GetKeyDown(KeyCode.Space))
            StartGame();
    }

    public void StartGame()
    {
        state = GameState.Playing;
        FindObjectOfType<BallController>().Launch();
    }

    public void AddScore(int pts)
    {
        score += pts;
        UIManager.instance.UpdateScore(score);
    }

    public void TriggerGameOver()
    {
        state = GameState.GameOver;
        UIManager.instance.ShowGameOver(score);
    }

    public void NextLevel()
    {
        LevelManager.instance.currentLevel++;
        LevelManager.instance.ApplyDifficulty();
        LevelManager.instance.GenerateLevel();
        UIManager.instance.UpdateLevel(LevelManager.instance.currentLevel);
    }
}