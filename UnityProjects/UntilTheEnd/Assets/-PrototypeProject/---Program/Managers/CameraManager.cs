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
            // �ʱ� fieldOfView ���� ����
            _initialFieldOfView = thisCamera.fieldOfView;
        }

        void Update()
        {
            float scrollWheel = -Input.GetAxis("Mouse ScrollWheel") * _scrollSpeed;

            // ���콺 �� Ŭ��, �ʱⰪ : 60
            if (Input.GetMouseButtonDown(2))
            {
                thisCamera.fieldOfView = _initialFieldOfView;
            }
            else
            {
                // �ִ� �� �� : 20
                if (thisCamera.fieldOfView <= 20.0f && scrollWheel < 0)
                {
                    thisCamera.fieldOfView = 20.0f;
                }

                // �ִ� �� �ƿ� : 100
                else if (thisCamera.fieldOfView >= 100.0f && scrollWheel > 0)
                {
                    thisCamera.fieldOfView = 100.0f;
                }

                // "���� �ܾƿ�" ����
                else
                {
                    thisCamera.fieldOfView += scrollWheel;
                }
            }
        }
    }
}