using UnityEngine;

public class FuelPickup : MonoBehaviour
{
    public float fuelAmount = 30f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FuelSystem fs = other.GetComponent<FuelSystem>();
            if (fs != null)
            {
                fs.AddFuel(fuelAmount);
            }
            Destroy(gameObject);
        }
    }
}