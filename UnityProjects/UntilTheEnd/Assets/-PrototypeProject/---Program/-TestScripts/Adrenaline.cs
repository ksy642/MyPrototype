using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ֻ�� ������Ʈ�� �� ��ũ��Ʈ
public class Adrenaline : MonoBehaviour
{
    // �޿��� ���� �ð��� 4��
    // �Ƶ巹���� �������ڸ��� 4�� �帣�� �ϰ�
    // �ֻ�� �Ŵ� �ִϸ��̼��� 3�� ���� �����ְ�
    // �ֻ�� ������ 1�� �� Ǯ���°ɷ� �ϸ� �ɰŰ��� .. = "�ִϸ��̼� ���� 3��"



    void Start()
    {
        
    }

    void Update()
    {
        TakeShots();
    }

    // ���â�� ���� ���� E �� �ѹ� ������ �����ٰ� ġ��
    // �ֻ�Ⱑ �����ٵ� �װ� ��������, �ֻ�� ������ Ű�� ����°���
    // �ֻ�� ���� �� �Լ� ��
    public void TakeShots()
    {
        // Ÿ�̸Ӹ� �ʱ�ȭ�����شٰ� �����ϸ� �ɵ���
        // ���� �׽�Ʈ��

        // Layer�� �ٽ� Awake�� �� ��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DreamManager.instance.ForAdrenaline();
        }
    }

}
