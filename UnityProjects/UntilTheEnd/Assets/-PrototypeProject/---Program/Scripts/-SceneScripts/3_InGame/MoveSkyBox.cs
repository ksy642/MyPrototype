using UnityEngine;

public class MoveSky : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2.0f; // 회전 속도 (초당 각도)

    void Update()
    {
        // 현재 시간에 따른 회전 각도 계산
        float degree = Time.time * rotationSpeed;

        // 각도를 360도 범위 내로 유지
        degree %= 360;

        // Skybox의 _Rotation 속성 설정
        RenderSettings.skybox.SetFloat("_Rotation", degree);
    }
}