using UnityEngine;

public class Preload : MonoBehaviour
{
    // 매니저들 체크
    // 없으면 생성시켜주는 식으로
    // 있으면 그대로 진행

    void Start()
    {
        SceneManager.instance.LoadScene("1_Lobby");
    }
}
