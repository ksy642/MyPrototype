using UnityEngine;
using UnityEngine.UI;

namespace MenteBacata.ScivoloCharacterControllerDemo
{
    public class LevelRotator : MonoBehaviour
    {
        public GameObject menuPanel;

        public Text xRotText, yRotText, zRotText;

        public Slider xRotSlider, yRotSlider, zRotSlider;

        public KeyCode showHideMenuKey;

        private Vector3 originalGravity;

        private void Start()
        {
            SetRotationText();
            menuPanel.SetActive(false);
            originalGravity = Physics.gravity;
#if !UNITY_EDITOR
            Cursor.lockState = CursorLockMode.Locked;
#endif
        }

        private void LateUpdate()
        {
            if (Input.GetKeyDown(showHideMenuKey))
                ToggleMenuVisibility();
        }

        public void ToggleMenuVisibility()
        {
            menuPanel.SetActive(!menuPanel.activeSelf);
            SetEnableComponents(!menuPanel.activeSelf);
            Time.timeScale = menuPanel.activeSelf ? 0f : 1f;
#if !UNITY_EDITOR
            Cursor.lockState = menuPanel.activeSelf ? CursorLockMode.Confined : CursorLockMode.Locked;
#endif
        }

        public void HandleRotationChange()
        {
            SetRotationText();
            Quaternion newRot = Quaternion.Euler(xRotSlider.value, yRotSlider.value, zRotSlider.value);
            transform.rotation = newRot;
            Physics.gravity = newRot * originalGravity;
        }

        private void SetRotationText()
        {
            xRotText.text = $"X: {Mathf.RoundToInt(xRotSlider.value)}°";
            yRotText.text = $"Y: {Mathf.RoundToInt(yRotSlider.value)}°";
            zRotText.text = $"Z: {Mathf.RoundToInt(zRotSlider.value)}°";
        }

        private void SetEnableComponents(bool enabled)
        {
            Camera.main.GetComponent<OrbitingCamera>().enabled = enabled;

            //FindObjectOfType<SimpleCharacterController>().enabled = enabled;
            FindFirstObjectByType<SimpleCharacterController>().enabled = enabled;

            //일단 오류나서 주석처리해둠, 추후 사용할 때 풀 예정
            //foreach (var m in FindObjectsOfType<MovingPlatform>())
            //{
            //    m.enabled = enabled;
            //}

            /*
             Unity에서 FindObjectsOfType<T>() 메서드가 더 이상 권장되지 않으며, 대신 FindObjectsByType<T>()를 사용해야 합니다. FindObjectsByType<T>()는 씬에 존재하는 모든 T 타입의 오브젝트를 찾는 메서드로, 성능이 개선된 대안입니다.

따라서 코드에서 FindObjectsOfType<MovingPlatform>()을 FindObjectsByType<MovingPlatform>()으로 바꾸는 것이 적절합니다. 또한, 이미 FindFirstObjectByType<T>()을 사용하여 단일 오브젝트를 찾고 있으므로 이는 문제가 없습니다.
             */
        }
    } 
}
