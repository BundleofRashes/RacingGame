using UnityEngine;
using System.Collections.Generic;
using UnityStandardAssets.Utility;

public class RivalsSpawner : MonoBehaviour
{
    public GameObject[] rivalPrefabs;       // Assign enemy car prefabs
    public Transform[] spawnPoints;         // Spawn locations
    public GameObject waypointCircuit;      // Your circuit object with WaypointCircuit.cs

    public GameObject[] SpawnRivals()
    {
        List<GameObject> spawned = new();

        for (int i = 0; i < rivalPrefabs.Length; i++)
        {
            GameObject rival = Instantiate(rivalPrefabs[i], spawnPoints[i].position, spawnPoints[i].rotation);

            var tracker = rival.GetComponent<WaypointProgressTracker>();
            if (tracker != null && waypointCircuit != null)
            {
                tracker.SetCircuit(waypointCircuit.GetComponent<WaypointCircuit>());
            }

            spawned.Add(rival);
        }

        return spawned.ToArray();
    }
}
