using UnityEngine;
using TMPro;

public class LapCounter : MonoBehaviour
{
    public int totalLaps = 3;
    private int currentLap = 0;

    public TextMeshProUGUI lapText;
    public GameObject raceEndPanel;

    private void Start()
    {
        UpdateLapText();
        if (raceEndPanel != null)
            raceEndPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentLap++;
            Debug.Log("Lap increased to: " + currentLap);
            UpdateLapText();

            if (currentLap >= totalLaps)
            {
                Debug.Log("Race finished!");
                if (raceEndPanel != null)
                    raceEndPanel.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Entered by: " + other.name + " (Tag: " + other.tag + ")");
        }
    }

    void UpdateLapText()
    {
        if (lapText != null)
            lapText.text = "Lap: " + currentLap + "/" + totalLaps;
    }
}
