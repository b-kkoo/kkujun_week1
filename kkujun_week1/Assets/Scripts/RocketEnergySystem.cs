using UnityEngine;
using UnityEngine.UI;

public class RocketEnergySystem : MonoBehaviour
{
    public float fuel = 100f;
    public float maxFuel;

    public Image fuelBar;

    public void SetFuelBar()
    {
        fuelBar.fillAmount = fuel / maxFuel;
    }

    public void RestoreFuel()
    {
        fuel += 0.1f;
        if (fuel >= maxFuel)
        {
            fuel = maxFuel;
        }
    }
}
