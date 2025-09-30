using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int value = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.BolaColetada(value);
            Destroy(gameObject);
        }
    }
}