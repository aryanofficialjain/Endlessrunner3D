using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform player;
    public float spawnZDistance = 50f;       
    public float spawnInterval = 10f;        
    public float laneWidth = 4f;             

    private float lastSpawnZ;
    private ObjectPooler pooler;

    void Start()
    {

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
            else
                Debug.LogError(" Player tag not found.");
        }

        pooler = GetComponent<ObjectPooler>();
        lastSpawnZ = player.position.z;
    }

    void Update()
    {
        if (player == null || pooler == null) return;

        if (player.position.z + spawnZDistance > lastSpawnZ)
        {
            SpawnObstacle();
            SpawnCoinRow(); 
            lastSpawnZ += spawnInterval;
        }
    }

    void SpawnObstacle()
    {
        GameObject obstacle = pooler.GetPooledObstacle();
        if (obstacle != null)
        {
            float randomX = Random.Range(-laneWidth, laneWidth);
            Vector3 spawnPos = new Vector3(randomX, 1.30f, lastSpawnZ + spawnInterval); 
            obstacle.transform.position = spawnPos;
            obstacle.SetActive(true);
        }
    }

    void SpawnCoinRow()
    {
        int coinCount = Random.Range(3, 6); 
        float startX = -laneWidth;
        float spacing = (laneWidth * 2) / (coinCount - 1);

        for (int i = 0; i < coinCount; i++)
        {
            GameObject coin = pooler.GetPooledCoin();
            if (coin != null)
            {
                float x = startX + i * spacing;
                Vector3 coinPos = new Vector3(x, 1.5f, lastSpawnZ + spawnInterval + 2f); 
                coin.transform.position = coinPos;
                coin.SetActive(true);
            }
        }
    }
}