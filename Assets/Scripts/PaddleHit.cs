using UnityEngine;

public class PaddleHit : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
            AudioManager.instance.PlayPaddleHit();
    }
}
