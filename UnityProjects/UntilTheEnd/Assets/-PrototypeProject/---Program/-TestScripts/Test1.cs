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
        // 마우스 커서가 보이는 상태에서 ESC를 누르면
        if (Cursor.visible)
        {
            Cursor.visible = false; // 마우스 커서 숨기기
                                    // 메뉴 표시 등의 동작 추가
        }
        else // 마우스 커서가 숨겨진 상태에서 ESC를 누르면
        {
            Cursor.visible = true; // 마우스 커서 보이기
                                   // 메뉴 숨기기 등의 동작 추가
        }
    }
}