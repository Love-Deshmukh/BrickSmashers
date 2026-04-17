// BrickPool.cs
using UnityEngine;
using System.Collections.Generic;

public class BrickPool : MonoBehaviour
{
    public static BrickPool instance;
    public GameObject brickPrefab;
    public int poolSize = 64;
    private Queue<GameObject> pool = new Queue<GameObject>();

    void Awake()
    {
        instance = this;
        for (int i = 0; i < poolSize; i++)
        {
            GameObject b = Instantiate(brickPrefab);
            b.SetActive(false);
            pool.Enqueue(b);
        }
    }

    public GameObject GetBrick(Vector3 pos)
    {
        GameObject b = pool.Count > 0
            ? pool.Dequeue()
            : Instantiate(brickPrefab);
        b.transform.position = pos;
        b.SetActive(true);
        return b;
    }

    public void ReturnBrick(GameObject b)
    {
        b.SetActive(false);
        pool.Enqueue(b);
    }
}