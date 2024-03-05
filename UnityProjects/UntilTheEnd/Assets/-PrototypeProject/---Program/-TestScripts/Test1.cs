using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test1 : MonoBehaviour
{
    //public Button button1;

    void Start()
    {
        Debug.Log(StringValues.Text.test1);
        Debug.Log(StringValues.test2);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursorAndMenu();
        }
    }

    private void ToggleCursorAndMenu()
    {
        // ���콺 Ŀ���� ���̴� ���¿��� ESC�� ������
        if (Cursor.visible)
        {
            Cursor.visible = false; // ���콺 Ŀ�� �����
                                    // �޴� ǥ�� ���� ���� �߰�
        }
        else // ���콺 Ŀ���� ������ ���¿��� ESC�� ������
        {
            Cursor.visible = true; // ���콺 Ŀ�� ���̱�
                                   // �޴� ����� ���� ���� �߰�
        }
    }
}