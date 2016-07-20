using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void LoadAScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadAScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
