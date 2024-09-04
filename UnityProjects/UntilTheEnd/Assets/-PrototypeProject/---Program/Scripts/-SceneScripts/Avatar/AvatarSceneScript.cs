using UnityEngine;
using static UntilTheEnd.GameManager;

namespace UntilTheEnd
{
    public class AvatarSceneScript : MonoBehaviour
    {
        public UIAvatar uIAvatar;
        public GameObject player1;
        public GameObject player2;

        private bool _isDragging = false;
        private Vector3 _lastMousePosition;

        Ray ray;
        RaycastHit hit;

        void Start()
        {
            GameManager.instance.ChangeState(GameState.Lobby);
            uIAvatar.StartAvatarCostume();

            // �׽�Ʈ��
            //Loading.LoadScene(StringValues.Scene.login);
            //Loading.LoadScene(StringValues.Scene.inGame);
        }

        void Update()
        {
            // ĳ���� ȸ���� ���� �巡�� ����
            if (Input.GetMouseButtonDown(0))
            {
                _isDragging = true;
                _lastMousePosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(0) && _isDragging)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 delta = Input.mousePosition - _lastMousePosition;
                    float rotationY = delta.x * 0.5f; // ȸ�� �ӵ� ����

                    if (hit.transform != null)
                    {
                        if (hit.transform.gameObject == player1)
                        {
                            player1.transform.Rotate(0, -rotationY, 0);
                        }
                    }
                    else if (hit.transform != null)
                    {
                        if (hit.transform.gameObject == player2)
                        {
                            player2.transform.Rotate(0, -rotationY, 0);
                        }
                    }
                    _lastMousePosition = Input.mousePosition;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isDragging = false;
            }
        }
    }
}