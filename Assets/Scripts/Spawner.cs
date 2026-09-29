using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float minInterval = 1f;
    public float maxInterval = 2.5f;
    float timer = 1f;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Instantiate(obstaclePrefab, new Vector3(0, 0.5f, 12f), Quaternion.identity);
            timer = Random.Range(minInterval, maxInterval);
        }
    }
}
