using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.Utility;

public class RaceCountdown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;            // UI text for countdown
    public CarSpawner carSpawner;                    // Drag your CarSpawner object here
    public GameObject[] existingRivals;              // Drag rival cars from the scene

    private CarUserControl playerControl;
    private Rigidbody playerRb;
    private List<WaypointProgressTracker> rivalTrackers = new();
    private List<Rigidbody> rivalRigidbodies = new();

    private void Start()
    {
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        // Wait until the player car is spawned
        yield return new WaitUntil(() => carSpawner.SpawnedCar != null);

        GameObject playerCar = carSpawner.SpawnedCar;

        // Disable player car
        playerControl = playerCar.GetComponent<CarUserControl>();
        playerRb = playerCar.GetComponent<Rigidbody>();

        if (playerControl != null) playerControl.enabled = false;
        if (playerRb != null) playerRb.isKinematic = true;

        // Disable all existing rivals
        foreach (GameObject rival in existingRivals)
        {
            var tracker = rival.GetComponent<WaypointProgressTracker>();
            var rb = rival.GetComponent<Rigidbody>();

            if (tracker != null)
            {
                tracker.enabled = false;
                rivalTrackers.Add(tracker);
            }

            if (rb != null)
            {
                rb.isKinematic = true;
                rivalRigidbodies.Add(rb);
            }
        }

        // Countdown UI
        string[] countdown = { "3", "2", "1", "GO!" };
        foreach (string num in countdown)
        {
            countdownText.text = num;
            yield return new WaitForSeconds(1f);
        }

        countdownText.text = "";

        // Enable player
        if (playerControl != null) playerControl.enabled = true;
        if (playerRb != null) playerRb.isKinematic = false;

        // Enable rivals
        foreach (var tracker in rivalTrackers)
            if (tracker != null) tracker.enabled = true;

        foreach (var rb in rivalRigidbodies)
            if (rb != null) rb.isKinematic = false;
    }
}
