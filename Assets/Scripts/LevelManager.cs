using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public GameObject brickPrefab;
    public int rows = 4;
    public int columns = 8;
    public float brickWidth = 1.2f;
    public float brickHeight = 0.5f;
    public float topOffset = 3f;
    public int currentLevel = 1;

    void Awake() { instance = this; }

    void Start() { GenerateLevel(); }

    // Add these methods to LevelManager.cs
    private int activeBricks = 0;

    // Replace GenerateLevel() in LevelManager.cs with this version
    public void GenerateLevel()
    {
        activeBricks = 0;
        int pattern = UnityEngine.Random.Range(0, 3);
        float startX = -(columns - 1) * brickWidth / 2f;
        float startY = topOffset;

        Color[] rowColors = new Color[]
        {
        new Color(1f, 0.2f, 0.2f),
        new Color(1f, 0.6f, 0f),
        new Color(1f, 1f, 0f),
        new Color(0f, 1f, 0.4f),
        new Color(0f, 0.8f, 1f),
        new Color(0.6f, 0.2f, 1f),
        new Color(1f, 0.2f, 0.8f),
        new Color(1f, 1f, 1f),
        };

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                bool spawn = true;

                if (pattern == 1)
                    spawn = (r + c) % 2 == 0;
                else if (pattern == 2)
                    spawn = UnityEngine.Random.value > 0.25f;

                if (spawn)
                {
                    Vector3 pos = new Vector3(
                        startX + c * brickWidth,
                        startY - r * brickHeight, 0);
                    GameObject b = BrickPool.instance.GetBrick(pos);

                    SpriteRenderer sr = b.GetComponent<SpriteRenderer>();
                    if (sr != null)
                        sr.color = rowColors[r % rowColors.Length];

                    activeBricks++;
                }
            }
        }
    }

    public void BrickDestroyed()
    {
        activeBricks--;
        if (activeBricks <= 0)
            GameManager.instance.NextLevel();
    }
    // Add to LevelManager.cs
    public void ApplyDifficulty()
    {
        // Add a row every 2 levels, max 8 rows
        rows = Mathf.Min(4 + (currentLevel / 2), 8);

        // Speed up the ball every level
        BallController ball = FindObjectOfType<BallController>();
        if (ball != null)
            ball.speed = 8f + (currentLevel * 0.5f);

        Debug.Log("Level " + currentLevel +
                  " | Rows: " + rows +
                  " | Ball speed: " + ball.speed);
    }
}