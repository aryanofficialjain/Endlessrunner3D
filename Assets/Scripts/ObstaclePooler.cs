using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    [Header("Obstacle Pooling")]
    public GameObject obstaclePrefab;
    public int obstaclePoolSize = 10;
    private List<GameObject> obstaclePool = new List<GameObject>();

    [Header("Coin Pooling")]
    public GameObject coinPrefab;
    public int coinPoolSize = 20;
    private List<GameObject> coinPool = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < obstaclePoolSize; i++)
        {
            GameObject obj = Instantiate(obstaclePrefab);
            obj.SetActive(false);
            obstaclePool.Add(obj);
        }


        for (int i = 0; i < coinPoolSize; i++)
        {
            GameObject coin = Instantiate(coinPrefab);
            coin.SetActive(false);
            coinPool.Add(coin);
        }
    }

    public GameObject GetPooledObstacle()
    {
        foreach (GameObject obj in obstaclePool)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }


        GameObject newObj = Instantiate(obstaclePrefab);
        newObj.SetActive(false);
        obstaclePool.Add(newObj);
        return newObj;
    }

    public GameObject GetPooledCoin()
    {
        foreach (GameObject coin in coinPool)
        {
            if (!coin.activeInHierarchy)
                return coin;
        }


        GameObject newCoin = Instantiate(coinPrefab);
        newCoin.SetActive(false);
        coinPool.Add(newCoin);
        return newCoin;
    }
}