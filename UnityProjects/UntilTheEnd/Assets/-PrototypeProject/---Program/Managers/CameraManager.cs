using UnityEngine;

namespace UntilTheEnd
{
    public class CameraManager : MonoBehaviour
    {
        public Camera thisCamera;

        private float _scrollSpeed = 10.0f;
        private float _initialFieldOfView;

        void Start()
        {
            // √ ±‚ fieldOfView ∞™¿ª ¿˙¿Â
            _initialFieldOfView = thisCamera.fieldOfView;
        }

        void Update()
        {
            float scrollWheel = -Input.GetAxis("Mouse ScrollWheel") * _scrollSpeed;

            // ∏∂øÏΩ∫ »Ÿ ≈¨∏Ø, √ ±‚∞™ : 60
            if (Input.GetMouseButtonDown(2))
            {
                thisCamera.fieldOfView = _initialFieldOfView;
            }
            else
            {
                // √÷¥Î ¡‹ ¿Œ : 20
                if (thisCamera.fieldOfView <= 20.0f && scrollWheel < 0)
                {
                    thisCamera.fieldOfView = 20.0f;
                }

                // √÷¥Î ¡‹ æ∆øÙ : 100
                else if (thisCamera.fieldOfView >= 100.0f && scrollWheel > 0)
                {
                    thisCamera.fieldOfView = 100.0f;
                }

                // "¡‹¿Œ ¡‹æ∆øÙ" ∞°¥…
                else
                {
                    thisCamera.fieldOfView += scrollWheel;
                }
            }
        }
    }
}