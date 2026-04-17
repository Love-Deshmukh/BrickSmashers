// GameOverZone.cs — attach to the bottom trigger zone
using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ball"))
            GameManager.instance.TriggerGameOver();
    }
}