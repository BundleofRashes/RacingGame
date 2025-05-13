using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] carPrefabs;
    public Transform spawnPoint;

    public GameObject SpawnedCar { get; private set; } // ✅ define this!

    void Start()
    {
        int selectedCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);

        if (selectedCarIndex < carPrefabs.Length)
        {
            SpawnedCar = Instantiate(carPrefabs[selectedCarIndex], spawnPoint.position, spawnPoint.rotation);
            Camera.main.GetComponent<FollowCar>().target = SpawnedCar.transform;
        }
    }
}
