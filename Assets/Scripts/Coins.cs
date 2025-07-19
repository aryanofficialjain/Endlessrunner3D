using UnityEngine;

public class Coins : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(1);
            gameObject.SetActive(false);
        }
    }
}
