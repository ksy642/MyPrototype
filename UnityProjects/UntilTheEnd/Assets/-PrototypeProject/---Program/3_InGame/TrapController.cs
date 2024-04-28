using System.Collections;
using UnityEngine;
using Cinemachine;
using Photon.Realtime;

public class TrapController : MonoBehaviour
{
    public CinemachineVirtualCamera cameraPlayer; // 11�� ī�޶�
    public CinemachineVirtualCamera cameraTest1; // 9�� ī�޶�

    bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        // �÷��̾ Ư�� ���� ����� �� �����ϴ� �ڵ�
        if (other.CompareTag("Player") && !hasTriggered)
        {
            // �÷��̾ Ʈ���Ÿ� ���� ������ �� ������ �ڵ�
            Debug.Log("�÷��̾ Ʈ���Ÿ� ���� ����");

            ChangeView();

            hasTriggered = true; // Ʈ���Ű� �� ���� �ߵ��ϵ��� ����
        }
    }

    void ChangeView()
    {
        cameraPlayer.gameObject.SetActive(false);
        cameraTest1.gameObject.SetActive(true);

        StartCoroutine(ChangeCameraForSeconds()); // 11�� ī�޶�� ���� �� 5�� �� 9�� ī�޶�� ����
    }

    IEnumerator ChangeCameraForSeconds()
    {
        yield return new WaitForSeconds(5.0f);

        cameraTest1.gameObject.SetActive(false);
        cameraPlayer.gameObject.SetActive(true);
    }
}
