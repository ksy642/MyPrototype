using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        // 플레이어가 특정구간 밟았을 때 동작하는 코드
        if (other.CompareTag("Player") && !hasTriggered)
        {
            // 시네머신 같은거 넣어서 카메라 돌리고 좀비군단 같은거 소환하게 하는거 살짝 보여주는거 괜찮다고 생각됨

            Debug.Log("플레이어가 트리거를 밟은 상태");


            hasTriggered = true;
        }
    }
}
