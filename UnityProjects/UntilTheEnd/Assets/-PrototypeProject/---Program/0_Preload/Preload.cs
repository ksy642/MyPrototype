using UnityEngine;

public class Preload : MonoBehaviour
{
    // �Ŵ����� üũ
    // ������ ���������ִ� ������
    // ������ �״�� ����

    void Start()
    {
        SceneManager.instance.LoadScene("1_Lobby");
    }
}
