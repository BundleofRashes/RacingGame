using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadTrackSelectionScene()
    {
        SceneManager.LoadScene("TrackSelectionScene"); // use your actual scene name here
    }
}
