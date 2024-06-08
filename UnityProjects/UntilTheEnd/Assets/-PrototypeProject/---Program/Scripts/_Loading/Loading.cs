using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UntilTheEnd
{
    public class Loading : MonoBehaviour
    {
        public static string nextScene;

        [SerializeField] Image progressBar;

        void Start()
        {
            StartCoroutine(LoadScene());
        }

        public static void LoadScene(string sceneName)
        {
            nextScene = sceneName;
            UnityEngine.SceneManagement.SceneManager.LoadScene(StringValues.Scene.loading);
        }

        IEnumerator LoadScene()
        {
            yield return null;
            AsyncOperation op = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(nextScene);
            op.allowSceneActivation = false;
            float timer = 0.0f;
            while (!op.isDone)
            {
                yield return null;
                timer += Time.deltaTime;
                if (op.progress < 0.9f)
                {
                    progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                    if (progressBar.fillAmount >= op.progress)
                    {
                        timer = 0f;
                    }
                }
                else
                {
                    progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
                    if (progressBar.fillAmount == 1.0f)
                    {
                        op.allowSceneActivation = true;
                        yield break;
                    }
                }
            }
        }
    }
}