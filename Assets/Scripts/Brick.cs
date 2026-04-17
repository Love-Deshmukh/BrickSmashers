using UnityEngine;

public class Brick : MonoBehaviour
{
    public int pointValue = 10;
    public GameObject explosionPrefab;

    void OnCollisionEnter2D(Collision2D col)
    {
        GameManager.instance.AddScore(pointValue);
        LevelManager.instance.BrickDestroyed();

        if (explosionPrefab != null)
        {
            GameObject fx = Instantiate(explosionPrefab,
                transform.position, Quaternion.identity);
            Destroy(fx, 1f);
        }

        CameraShake.instance.Shake(0.1f, 0.08f);
        AudioManager.instance.PlayBrickHit();
        BrickPool.instance.ReturnBrick(gameObject);
    }
}