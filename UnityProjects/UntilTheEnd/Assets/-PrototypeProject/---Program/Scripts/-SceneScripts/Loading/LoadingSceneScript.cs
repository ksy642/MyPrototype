using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UntilTheEnd
{
    public class LoadingSceneScript : MonoBehaviour
    {
        public static string nextScene;

        [SerializeField] private Image _loadingBar;

        void Start()
        {
            if (SceneManager.instance.GetActiveScene().name == StringValues.Scene.loading)
            {
                StartCoroutine(_LoadScene());
            }
            else if (SceneManager.instance.GetActiveScene().name == StringValues.Scene.blackLoading)
            {
                StartCoroutine(_BlackLoadScene());
            }

        }

        public static void LoadScene(string sceneName)
        {
            nextScene = sceneName;
            UnityEngine.SceneManagement.SceneManager.LoadScene(StringValues.Scene.loading);
        }

        private IEnumerator _LoadScene()
        {
            yield return null;

            // Async를 통해서 비동기적 씬로딩을 진행
            AsyncOperation op = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(nextScene);

            op.allowSceneActivation = false;
            float timer = 0.0f;

            while (!op.isDone)
            {
                yield return null;
                timer += Time.deltaTime;

                //if (op.progress < 0.9f) // 90%까지 완료 후 수동으로 활성화
                //{
                //    _loadingBar.fillAmount = Mathf.Lerp(_loadingBar.fillAmount, op.progress, timer);
                //    Debug.Log("이게 나와야함1111");

                //    if (_loadingBar.fillAmount >= op.progress)
                //    {
                //        Debug.Log("이게 나와야함2222");
                //        timer = 0f;
                //    }
                //}
                //else
                //{ }

                _loadingBar.fillAmount = Mathf.Lerp(_loadingBar.fillAmount, 1.0f, timer);

                // 로딩 게이지가 30% ~ 60% 사이일 때 속도 딜레이 줌
                if (_loadingBar.fillAmount >= 0.3f && _loadingBar.fillAmount <= 0.6f)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                else if (_loadingBar.fillAmount == 1.0f)
                {
                    op.allowSceneActivation = true;

                    yield break;
                }
            }
        }


        private IEnumerator _BlackLoadScene() // 추가로 더 작성해야함!!!
        {
            yield return null;
        }
    }
}