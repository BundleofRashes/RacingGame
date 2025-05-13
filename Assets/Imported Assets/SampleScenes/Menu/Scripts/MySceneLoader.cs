using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneLoader : MonoBehaviour
{
    public void LoadSceneByName(string sceneName)
    {
        Debug.Log("Loading scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
