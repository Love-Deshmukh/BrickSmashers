using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;
    public float boundary = 7.5f;

    void Update()
    {
        if (GameManager.instance.state != GameState.Playing)
            return;

        float move = InputManager.instance.GetHorizontalInput();

        Vector3 pos = transform.position;
        pos.x += move * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -boundary, boundary);
        transform.position = pos;
    }
}