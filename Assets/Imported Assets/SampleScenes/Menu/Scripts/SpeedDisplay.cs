using UnityEngine;
using TMPro;
using UnityStandardAssets.Vehicles.Car;

public class SpeedDisplay : MonoBehaviour
{
    public CarSpawner carSpawner;
    public TextMeshProUGUI speedText;

    private CarController carController;

    void Update()
    {
        if (carController == null && carSpawner.SpawnedCar != null)
        {
            carController = carSpawner.SpawnedCar.GetComponent<CarController>();
        }

        if (carController != null && speedText != null)
        {
            float speed = carController.CurrentSpeed;
            speedText.text = "Speed: " + Mathf.RoundToInt(speed) + " km/h";
        }
    }
}
