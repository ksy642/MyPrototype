using UnityEngine;

public class CameraView : MonoBehaviour
{
    private float _zoomSpeed = 10.0f;
    private float _minFOV = 30.0f;
    private float _maxFOV = 70.0f;
    private float _initialFOV = 50.0f; // 처음 시야 값

    void Update()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        if (scrollWheel != 0)
        {
            Camera mainCamera = GetComponent<Camera>();
            float newFOV = mainCamera.fieldOfView - scrollWheel * _zoomSpeed;
            newFOV = Mathf.Clamp(newFOV, _minFOV, _maxFOV);
            mainCamera.fieldOfView = newFOV;
        }

        // 처음 시야로 재설정
        if (Input.GetKeyDown(KeyCode.F))
        {
            Camera mainCamera = GetComponent<Camera>();
            mainCamera.fieldOfView = _initialFOV;
        }
    }
}
