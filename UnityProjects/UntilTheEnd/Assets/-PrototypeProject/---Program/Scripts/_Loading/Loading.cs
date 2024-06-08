using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UntilTheEnd
{
    public class Loading : MonoBehaviour
    {
        public static string nextScene;

        [SerializeField] private Image _loadingBar;

        void Start()
        {
            StartCoroutine(_LoadScene());
        }

        public static void LoadScene(string sceneName)
        {
            nextScene = sceneName;
            UnityEngine.SceneManagement.SceneManager.LoadScene(StringValues.Scene.loading);
        }

        private IEnumerator _LoadScene()
        {
            yield return null;

            // Async�� ���ؼ� �񵿱��� ���ε��� ����
            AsyncOperation op = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(nextScene);

            op.allowSceneActivation = false;
            float timer = 0.0f;

            while (!op.isDone)
            {
                yield return null;
                timer += Time.deltaTime;

                //if (op.progress < 0.9f) // 90%���� �Ϸ� �� �������� Ȱ��ȭ
                //{
                //    _loadingBar.fillAmount = Mathf.Lerp(_loadingBar.fillAmount, op.progress, timer);
                //    Debug.Log("�̰� ���;���1111");

                //    if (_loadingBar.fillAmount >= op.progress)
                //    {
                //        Debug.Log("�̰� ���;���2222");
                //        timer = 0f;
                //    }
                //}
                //else
                //{ }

                _loadingBar.fillAmount = Mathf.Lerp(_loadingBar.fillAmount, 1.0f, timer);

                // �ε� �������� 30% ~ 60% ������ �� �ӵ� ������ ��
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
    }
}