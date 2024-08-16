using UnityEngine;

public class MoveSky : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2.0f; // ȸ�� �ӵ� (�ʴ� ����)

    void Update()
    {
        // ���� �ð��� ���� ȸ�� ���� ���
        float degree = Time.time * rotationSpeed;

        // ������ 360�� ���� ���� ����
        degree %= 360;

        // Skybox�� _Rotation �Ӽ� ����
        RenderSettings.skybox.SetFloat("_Rotation", degree);
    }
}