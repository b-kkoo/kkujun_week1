using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private RocketEnergySystem _energySystem;
    //private float fuel = 100f;
    //private float maxFuel;

    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;

    //public Image fuelBar;
    
    void Awake()
    {
        // TODO : Rigidbody2D 컴포넌트를 가져옴(캐싱)
        _rb2d = GetComponent<Rigidbody2D>();
        _energySystem = GetComponent<RocketEnergySystem>();

        //maxFuel = fuel;
        _energySystem.maxFuel = _energySystem.fuel;
    }

    private void Update()
    {
        //fuelBar.fillAmount = fuel / maxFuel;
        _energySystem.SetFuelBar();

        //fuel += 0.1f;
        //if ( fuel >= 100f )
        //{
        //    fuel = 100f;
        //}
        _energySystem.RestoreFuel();
    }

    public void Shoot()
    {
        // TODO : fuel이 넉넉하면 윗 방향으로 SPEED만큼의 힘으로 점프, 모자라면 무시
        if ( _energySystem.fuel >= 10f)
        {
            Vector2 jump = new Vector2(0, SPEED);
            _rb2d.AddForce(jump, ForceMode2D.Impulse);

            _energySystem.fuel -= FUELPERSHOOT;
        }
    }
}
