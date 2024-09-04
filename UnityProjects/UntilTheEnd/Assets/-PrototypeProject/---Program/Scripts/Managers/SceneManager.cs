using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;
using UnityEngine.SceneManagement;

namespace UntilTheEnd
{
    public class SceneManager : DontDestroySingleton<SceneManager>
    {
        // ���� �ε��ϴ� �Լ�
        public void LoadScene(string sceneName)
        {
            UnitySceneManager.LoadScene(sceneName);
        }

        // ���� Ȱ��ȭ�� ���� �̸��� ��ȯ�ϴ� �Լ�
        public string GetActiveSceneName()
        {
            return UnitySceneManager.GetActiveScene().name;
        }

        /// <summary>
        /// ���� Ȱ��ȭ�� ���� ������ ��ȯ�ϴ� �Լ� �ڡڡ�
        /// </summary>
        public Scene GetActiveScene()
        {
            return UnitySceneManager.GetActiveScene();
        }
    }
}