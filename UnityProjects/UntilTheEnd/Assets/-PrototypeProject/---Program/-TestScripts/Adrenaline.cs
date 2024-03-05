using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 주사기 오브젝트에 들어갈 스크립트
public class Adrenaline : MonoBehaviour
{
    // 꿈에서 깨는 시간이 4초
    // 아드레날린 적용하자마자 4초 흐르게 하고
    // 주사기 꼽는 애니메이션을 3초 정도 보여주고
    // 주사기 끝나면 1초 뒤 풀리는걸로 하면 될거같음 .. = "애니메이션 동작 3초"



    void Start()
    {
        
    }

    void Update()
    {
        TakeShots();
    }

    // 장비창을 먼저 열고 E 를 한번 누르면 열린다고 치고
    // 주사기가 보일텐데 그걸 눌러야함, 주사기 누르는 키를 만드는거지
    // 주사기 누를 때 함수 ↓
    public void TakeShots()
    {
        // 타이머를 초기화시켜준다고 생각하면 될듯함
        // 예시 테스트용

        // Layer가 다시 Awake가 될 때
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DreamManager.instance.ForAdrenaline();
        }
    }

}
