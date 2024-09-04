using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;
using UnityEngine.SceneManagement;

namespace UntilTheEnd
{
    public class SceneManager : DontDestroySingleton<SceneManager>
    {
        // 씬을 로드하는 함수
        public void LoadScene(string sceneName)
        {
            UnitySceneManager.LoadScene(sceneName);
        }

        // 현재 활성화된 씬의 이름을 반환하는 함수
        public string GetActiveSceneName()
        {
            return UnitySceneManager.GetActiveScene().name;
        }

        /// <summary>
        /// 현재 활성화된 씬의 정보를 반환하는 함수 ★★★
        /// </summary>
        public Scene GetActiveScene()
        {
            return UnitySceneManager.GetActiveScene();
        }
    }
}