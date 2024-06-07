using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : DontDestroySingleton<SceneManager>
{
    public void LoadScene(string sceneName) 
    {
        UnitySceneManager.LoadScene(sceneName); 
    }
}