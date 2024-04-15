using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        // �÷��̾ Ư������ ����� �� �����ϴ� �ڵ�
        if (other.CompareTag("Player") && !hasTriggered)
        {
            // �ó׸ӽ� ������ �־ ī�޶� ������ ���񱺴� ������ ��ȯ�ϰ� �ϴ°� ��¦ �����ִ°� �����ٰ� ������

            Debug.Log("�÷��̾ Ʈ���Ÿ� ���� ����");


            hasTriggered = true;
        }
    }
}
