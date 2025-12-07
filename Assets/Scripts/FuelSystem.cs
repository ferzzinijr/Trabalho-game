using UnityEngine;
using UnityEngine.UI;

public class FuelSystem : MonoBehaviour
{
    [Header("Configuração de Gasolina")]
    public float maxFuel = 100f;
    public float currentFuel;
    public float drainRate = 10f;

    [Header("UI")]
    public Slider fuelSlider;

    private bool acabouGasolina = false;

    void Start()
    {
        currentFuel = maxFuel;

        if (fuelSlider != null)
        {
            fuelSlider.maxValue = maxFuel;
            fuelSlider.value = currentFuel;
        }
    }

    void Update()
    {
        if (acabouGasolina) return;

        currentFuel -= drainRate * Time.deltaTime;
        currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel);

        if (fuelSlider != null)
            fuelSlider.value = currentFuel;

        if (currentFuel <= 0)
        {
            acabouGasolina = true;
            GameManager.Instance.GameOverPorGasolina();
        }
    }

    public void AddFuel(float amount)
    {
        currentFuel += amount;
        currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel);

        if (fuelSlider != null)
            fuelSlider.value = currentFuel;
    }
}