using System.Collections;
using UnityEngine;
using Cinemachine;
using Photon.Realtime;

public class TrapController : MonoBehaviour
{
    public CinemachineVirtualCamera cameraPlayer; // 11번 카메라
    public CinemachineVirtualCamera cameraTest1; // 9번 카메라

    bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        // 플레이어가 특정 구간 밟았을 때 동작하는 코드
        if (other.CompareTag("Player") && !hasTriggered)
        {
            // 플레이어가 트리거를 밟은 상태일 때 실행할 코드
            Debug.Log("플레이어가 트리거를 밟은 상태");

            ChangeView();

            hasTriggered = true; // 트리거가 한 번만 발동하도록 설정
        }
    }

    void ChangeView()
    {
        cameraPlayer.gameObject.SetActive(false);
        cameraTest1.gameObject.SetActive(true);

        StartCoroutine(ChangeCameraForSeconds()); // 11번 카메라로 변경 후 5초 후 9번 카메라로 변경
    }

    IEnumerator ChangeCameraForSeconds()
    {
        yield return new WaitForSeconds(5.0f);

        cameraTest1.gameObject.SetActive(false);
        cameraPlayer.gameObject.SetActive(true);
    }
}
